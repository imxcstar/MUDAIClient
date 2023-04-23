namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textbox_content = new RichTextBox();
            button1 = new Button();
            textbox_command = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            textBox4 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label5 = new Label();
            textBox5 = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            button2 = new Button();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // textbox_content
            // 
            textbox_content.BackColor = Color.White;
            textbox_content.BorderStyle = BorderStyle.None;
            textbox_content.Dock = DockStyle.Fill;
            textbox_content.Location = new Point(0, 0);
            textbox_content.Name = "textbox_content";
            textbox_content.ReadOnly = true;
            textbox_content.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            textbox_content.Size = new Size(680, 640);
            textbox_content.TabIndex = 0;
            textbox_content.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(655, 7);
            button1.Name = "button1";
            button1.Size = new Size(44, 50);
            button1.TabIndex = 1;
            button1.Text = "连接";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textbox_command
            // 
            textbox_command.Location = new Point(12, 629);
            textbox_command.Name = "textbox_command";
            textbox_command.Size = new Size(739, 23);
            textbox_command.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.MaxLength = 999999;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(739, 560);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(45, 7);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(130, 23);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(219, 6);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(64, 23);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 9);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 7;
            label1.Text = "地址";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 9);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 8;
            label2.Text = "端口";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 10);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 9;
            label3.Text = "编码";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "GBK", "UTF-8" });
            comboBox1.Location = new Point(327, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(90, 25);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 37);
            label4.Name = "label4";
            label4.Size = new Size(92, 17);
            label4.TabIndex = 11;
            label4.Text = "OpenAIApiKey";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(105, 34);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(216, 23);
            textBox4.TabIndex = 12;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(423, 9);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(111, 21);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "开启AI解析内容";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(538, 10);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(111, 21);
            checkBox2.TabIndex = 15;
            checkBox2.Text = "开启AI转译指令";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(325, 37);
            label5.Name = "label5";
            label5.Size = new Size(76, 17);
            label5.TabIndex = 16;
            label5.Text = "OpenAI代理";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(407, 34);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(242, 23);
            textBox5.TabIndex = 17;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(textbox_content);
            panel1.Location = new Point(757, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(680, 640);
            panel1.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(12, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(739, 560);
            panel2.TabIndex = 19;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(702, 7);
            button2.Name = "button2";
            button2.Size = new Size(44, 50);
            button2.TabIndex = 20;
            button2.Text = "断开";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(checkBox1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(checkBox2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(4, -2);
            panel3.Name = "panel3";
            panel3.Size = new Size(747, 59);
            panel3.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1439, 664);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(textbox_command);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MUDAIClient";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textbox_content;
        private Button button1;
        private TextBox textbox_command;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox textBox4;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label5;
        private TextBox textBox5;
        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Panel panel3;
    }
}