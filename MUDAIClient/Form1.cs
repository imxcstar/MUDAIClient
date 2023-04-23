using EasyTcp4;
using EasyTcp4.ClientUtils;
using EasyTcp4.Protocols.Tcp;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using MUDAIClient.ANSIEC.RichTextBoxRenderDevice;
using MUDAIClient.OpenAI;
using MUDAIClient;
using System.Text.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const string _configFileName = "config.json";

        private EasyTcpClient _client;
        private RichTextBoxRenderDevice _vdevice;
        private OpenAIHandleService _openAIHandleService;
        private Config _config;

        private List<string> _command_history = new List<string>();
        private int _command_index = -1;

        private DateTime _refDate = DateTime.Now;
        private string _oldValue = "";
        private string _curValue = "";

        public Form1()
        {
            InitializeComponent();
            _client = new EasyTcpClient(new PlainTcpProtocol());
            _vdevice = new RichTextBoxRenderDevice(textbox_content);
            _openAIHandleService = new OpenAIHandleService();
            _config = new Config();
            textbox_command.KeyUp += Textbox_command_KeyUp;
            textbox_content.LinkClicked += Textbox_content_LinkClicked;
            if (File.Exists(_configFileName))
            {
                var config = JsonSerializer.Deserialize<Config>(File.ReadAllText(_configFileName));
                if (config != null)
                    _config = config;
            }
            File.WriteAllText(_configFileName, JsonSerializer.Serialize(_config));

            textBox2.Text = _config.Address;
            textBox3.Text = _config.Port.ToString();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(_config.Encoding);
            textBox4.Text = _config.OpenAIApiKey;
            textBox5.Text = _config.OpenAIProxy;
            checkBox1.Checked = _config.EnableAIParseGameMessage;
            checkBox2.Checked = _config.EnableAIParsePlayerCommand;
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void Textbox_content_LinkClicked(object? sender, LinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.LinkText))
                OpenUrl(e.LinkText);
        }

        private void Textbox_command_KeyUp(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (_command_index == -1)
                        _command_index = _command_history.Count() - 1;
                    textbox_command.Text = _command_history[_command_index];
                    if (_command_index - 1 >= 0)
                        _command_index--;
                    break;
                case Keys.Down:
                    if (_command_index == -1)
                        _command_index = _command_history.Count() - 1;
                    if (_command_index + 1 < _command_history.Count())
                    {
                        _command_index++;
                        textbox_command.Text = _command_history[_command_index];
                    }
                    else
                    {
                        textbox_command.Text = "";
                    }
                    break;
                case Keys.Enter:
                    if (!_client.IsConnected())
                        return;
                    var command = textbox_command.Text;
                    textbox_command.Enabled = false;
                    if (string.IsNullOrWhiteSpace(command))
                    {
                        textbox_command.Text = "";
                        _client.Send(command + "\n");
                        textbox_command.Enabled = true;
                        textbox_command.Focus();
                        break;
                    }

                    if (_config.EnableAIParsePlayerCommand)
                    {
                        _openAIHandleService.HandPlayerCommand(_curValue, command, newCommand =>
                        {
                            this.Invoke(() =>
                            {
                                var uvv = $"\r\n\r\n用户输入：{command}";
                                textBox1.SelectionStart = textBox1.TextLength;
                                textBox1.SelectionLength = 0;
                                textBox1.SelectedText = $"{uvv}\r\n\r\n";
                                textBox1.SelectionStart = textBox1.TextLength;
                                textBox1.ScrollToCaret();
                                textbox_content.SelectionStart = textbox_content.TextLength;
                                textbox_content.SelectionLength = 0;
                                textbox_content.SelectedText = $"{newCommand}\r\n";
                                textbox_content.SelectionStart = textbox_content.TextLength;
                                textbox_content.ScrollToCaret();
                                _command_history.Add(command);
                                textbox_command.Text = "";
                                _client.Send(newCommand + "\n");
                            });
                        });
                    }
                    else
                    {
                        if (_config.EnableAIParseGameMessage)
                        {
                            var uvv = $"\r\n\r\n用户输入：{command}";
                            textBox1.SelectionStart = textBox1.TextLength;
                            textBox1.SelectionLength = 0;
                            textBox1.SelectedText = $"{uvv}\r\n\r\n";
                            textBox1.SelectionStart = textBox1.TextLength;
                            textBox1.ScrollToCaret();
                        }
                        textbox_content.SelectionStart = textbox_content.TextLength;
                        textbox_content.SelectionLength = 0;
                        textbox_content.SelectedText = $"{command}\r\n";
                        textbox_content.SelectionStart = textbox_content.TextLength;
                        textbox_content.ScrollToCaret();
                        _command_history.Add(command);
                        textbox_command.Text = "";
                        _client.Send(command + "\n");
                    }
                    textbox_command.Enabled = true;
                    textbox_command.Focus();

                    break;
                default:
                    break;
            }
        }

        private void ClinetBindEvent()
        {
            _client.OnDataReceive += (o, e) =>
            {
                textbox_content.Invoke(() =>
                {
                    var d = e.Data;
                    foreach (var item in d)
                    {
                        _vdevice.Put(item);
                    }
                    textbox_content.SelectionStart = textbox_content.TextLength;
                    textbox_content.ScrollToCaret();
                    _refDate = DateTime.Now;
                    _curValue = textbox_content.Text;
                });
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseConnect();
        }

        private void Connect()
        {
            switch (comboBox1.SelectedText.ToLower())
            {
                case "gbk":
                    _vdevice.DEncoding = RichTextBoxRenderDeviceEncoding.GBK;
                    break;
                case "utf-8":
                    _vdevice.DEncoding = RichTextBoxRenderDeviceEncoding.UTF8;
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrWhiteSpace(textBox5.Text))
                HttpClient.DefaultProxy = new WebProxy(textBox5.Text);
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
                _openAIHandleService.SetOpenAIService(new OpenAIService(new OpenAiOptions()
                {
                    ApiKey = textBox4.Text
                }));
            if (_config.EnableAIParseGameMessage)
                timer1.Enabled = true;
            _client = new EasyTcpClient(new PlainTcpProtocol());
            ClinetBindEvent();
            try
            {
                if (!_client.Connect(Dns.GetHostEntry(textBox2.Text).AddressList.First(), Convert.ToUInt16(textBox3.Text)))
                {
                    MessageBox.Show("无法连接服务器");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CloseConnect();
                return;
            }
            button1.Enabled = false;
            button2.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            comboBox1.Enabled = false;
            File.WriteAllText(_configFileName, JsonSerializer.Serialize(_config));
        }

        private void CloseConnect()
        {
            timer1.Enabled = false;
            _client.BaseSocket?.Close();
            button2.Enabled = false;
            button1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            if (_config.EnableAIParseGameMessage || _config.EnableAIParsePlayerCommand)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            comboBox1.Enabled = true;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            var tvalue = textbox_content.Text;
            if (string.IsNullOrWhiteSpace(tvalue))
                return;
            timer1.Enabled = false;
            if ((DateTime.Now - _refDate).TotalSeconds > 3 && _oldValue != tvalue)
            {
                var cvalue = tvalue.Substring(_oldValue.Length);
                _curValue = tvalue;
                Debug.WriteLine(cvalue);
                _oldValue = tvalue;
                _refDate = DateTime.Now;
                await _openAIHandleService.HandleGameMessage(cvalue, newMessage =>
                {
                    this.Invoke(() =>
                    {
                        textBox1.SelectionStart = textBox1.TextLength;
                        textBox1.SelectionLength = 0;
                        textBox1.SelectedText = newMessage.Replace("\n", "\r\n");
                        textBox1.SelectionStart = textBox1.TextLength;
                        textBox1.ScrollToCaret();
                    });
                });
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.SelectionLength = 0;
                textBox1.SelectedText = "\r\n\r\n";
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
            timer1.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _config.EnableAIParseGameMessage = checkBox1.Checked;
            if (checkBox1.Checked)
            {
                this.Width = 1455;
                textbox_content.Parent = panel1;
                textBox1.Visible = true;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
            else
            {
                this.Width = button2.Left + button2.Width + 20;
                textbox_content.Parent = panel2;
                textBox1.Visible = false;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                if (!_config.EnableAIParsePlayerCommand)
                {
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            _config.EnableAIParsePlayerCommand = checkBox2.Checked;
            if (_config.EnableAIParsePlayerCommand)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
            else if (!_config.EnableAIParseGameMessage)
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _config.Address = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _config.Port = Convert.ToUInt16(textBox3.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.Encoding = comboBox1.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            _config.OpenAIApiKey = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            _config.OpenAIProxy = textBox5.Text;
        }
    }
}