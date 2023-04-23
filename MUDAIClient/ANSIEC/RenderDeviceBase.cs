using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUDAIClient.ANSIEC
{
    public abstract class DeviceCBase
    {
        public virtual DeviceCBase? Parent { get; set; } = null;
        public virtual DeviceCBase? CurrentCommand { get; set; } = null;

        public virtual byte? Code => null;
        public virtual void OtherOut(byte data)
        {
            if (Parent != null)
                Parent.OtherOut(data);
        }
        public virtual void Put(byte data)
        {
        }
        public virtual void ResetCommand()
        {
            CurrentCommand = null;
            if (Parent != null)
                Parent.ResetCommand();
        }
        public virtual void Call(byte[] command)
        {
        }
    }
    public abstract class DeviceC0Base : DeviceCBase { }
    public abstract class DeviceC1Base : DeviceCBase { }

    /// <summary>
    /// null
    /// 0x00
    /// 空字符
    /// </summary>
    public abstract class DeviceC0_NULL : DeviceC0Base
    {
        public override byte? Code => 0x00;
    }
    /// <summary>
    /// start of headline
    /// 0x01
    /// 开始标题
    /// </summary>
    public abstract class DeviceC0_SOH : DeviceC0Base
    {
        public override byte? Code => 0x01;
    }
    /// <summary>
    /// start of text
    /// 0x02
    /// 文本开始
    /// </summary>
    public abstract class DeviceC0_STX : DeviceC0Base
    {
        public override byte? Code => 0x02;
    }
    /// <summary>
    /// end of text
    /// 0x03
    /// 文本结束
    /// </summary>
    public abstract class DeviceC0_ETX : DeviceC0Base
    {
        public override byte? Code => 0x03;
    }
    /// <summary>
    /// end of transmission
    /// 0x04
    /// 传输结束
    /// </summary>
    public abstract class DeviceC0_EOT : DeviceC0Base
    {
        public override byte? Code => 0x04;
    }
    /// <summary>
    /// enquiry
    /// 0x05
    /// 询问
    /// </summary>
    public abstract class DeviceC0_ENQ : DeviceC0Base
    {
        public override byte? Code => 0x05;
    }
    /// <summary>
    /// acknowledge
    /// 0x06
    /// 应答
    /// </summary>
    public abstract class DeviceC0_ACK : DeviceC0Base
    {
        public override byte? Code => 0x06;
    }
    /// <summary>
    /// bell
    /// 0x07
    /// 铃声
    /// </summary>
    public abstract class DeviceC0_BEL : DeviceC0Base
    {
        public override byte? Code => 0x07;
    }
    /// <summary>
    /// backspace
    /// 0x08
    /// 后退
    /// </summary>
    public abstract class DeviceC0_BS : DeviceC0Base
    {
        public override byte? Code => 0x08;
    }
    /// <summary>
    /// horizontal tab
    /// 0x09
    /// 水平制表
    /// </summary>
    public abstract class DeviceC0_HT : DeviceC0Base
    {
        public override byte? Code => 0x09;
    }
    /// <summary>
    /// line feed
    /// 0x0A
    /// 换行
    /// </summary>
    public abstract class DeviceC0_LF : DeviceC0Base
    {
        public override byte? Code => 0x0A;
    }
    /// <summary>
    /// vertical tab
    /// 0x0B
    /// 垂直制表
    /// </summary>
    public abstract class DeviceC0_VT : DeviceC0Base
    {
        public override byte? Code => 0x0B;
    }
    /// <summary>
    /// form feed
    /// 0x0C
    /// 换页
    /// </summary>
    public abstract class DeviceC0_FF : DeviceC0Base
    {
        public override byte? Code => 0x0C;
    }
    /// <summary>
    /// carriage return
    /// 0x0D
    /// 回车
    /// </summary>
    public abstract class DeviceC0_CR : DeviceC0Base
    {
        public override byte? Code => 0x0D;
    }
    /// <summary>
    /// shift out
    /// 0x0E
    /// 左移
    /// </summary>
    public abstract class DeviceC0_SO : DeviceC0Base
    {
        public override byte? Code => 0x0E;
    }
    /// <summary>
    /// shift in
    /// 0x0F
    /// 右移
    /// </summary>
    public abstract class DeviceC0_SI : DeviceC0Base
    {
        public override byte? Code => 0x0F;
    }
    /// <summary>
    /// data link escape
    /// 0x10
    /// 数据链路转义
    /// </summary>
    public abstract class DeviceC0_DLE : DeviceC0Base
    {
        public override byte? Code => 0x10;
    }
    /// <summary>
    /// device control 1
    /// 0x11
    /// 设备控制1
    /// </summary>
    public abstract class DeviceC0_DC1 : DeviceC0Base
    {
        public override byte? Code => 0x11;
    }
    /// <summary>
    /// device control 2
    /// 0x12
    /// 设备控制2
    /// </summary>
    public abstract class DeviceC0_DC2 : DeviceC0Base
    {
        public override byte? Code => 0x12;
    }
    /// <summary>
    /// device control 3
    /// 0x13
    /// 设备控制3
    /// </summary>
    public abstract class DeviceC0_DC3 : DeviceC0Base
    {
        public override byte? Code => 0x13;
    }
    /// <summary>
    /// device control 4
    /// 0x14
    /// 设备控制4
    /// </summary>
    public abstract class DeviceC0_DC4 : DeviceC0Base
    {
        public override byte? Code => 0x14;
    }
    /// <summary>
    /// negative acknowledge
    /// 0x15
    /// 否定应答
    /// </summary>
    public abstract class DeviceC0_NAK : DeviceC0Base
    {
        public override byte? Code => 0x15;
    }
    /// <summary>
    /// synchronous idle
    /// 0x16
    /// 同步空闲
    /// </summary>
    public abstract class DeviceC0_SYN : DeviceC0Base
    {
        public override byte? Code => 0x16;
    }
    /// <summary>
    /// end of transmission block
    /// 0x17
    /// 传输块结束
    /// </summary>
    public abstract class DeviceC0_ETB : DeviceC0Base
    {
        public override byte? Code => 0x17;
    }
    /// <summary>
    /// cancel
    /// 0x18
    /// 取消
    /// </summary>
    public abstract class DeviceC0_CAN : DeviceC0Base
    {
        public override byte? Code => 0x18;
    }
    /// <summary>
    /// end of medium
    /// 0x19
    /// 媒介结束
    /// </summary>
    public abstract class DeviceC0_EM : DeviceC0Base
    {
        public override byte? Code => 0x19;
    }
    /// <summary>
    /// substitute
    /// 0x1A
    /// 替换
    /// </summary>
    public abstract class DeviceC0_SUB : DeviceC0Base
    {
        public override byte? Code => 0x1A;
    }
    /// <summary>
    /// escape
    /// 0x1B
    /// 转义
    /// </summary>
    public abstract class DeviceC0_ESC : DeviceC0Base
    {
        public override byte? Code => 0x1B;
        public virtual DeviceC1_SS2? SS2 { get; set; } = null;
        public virtual DeviceC1_SS3? SS3 { get; set; } = null;
        public virtual DeviceC1_DCS? DCS { get; set; } = null;
        public virtual DeviceC1_CSI? CSI { get; set; } = null;
        public virtual DeviceC1_ST? ST { get; set; } = null;
        public virtual DeviceC1_OSC? OSC { get; set; } = null;
        public virtual DeviceC1_SOS? SOS { get; set; } = null;
        public virtual DeviceC1_PM? PM { get; set; } = null;
        public virtual DeviceC1_APC? APC { get; set; } = null;
        public virtual DeviceC1_RIS? RIS { get; set; } = null;

        public DeviceC0_ESC()
        {
        }

        public override void Put(byte data)
        {
            if (CurrentCommand != null)
            {
                CurrentCommand.Put(data);
                return;
            }
            if (CSI != null && (CSI.Code.Equals(data) || data == 0x5B))
            {
                CurrentCommand = CSI;
            }
            else
            {
                OtherOut(data);
            }
        }

        public override void ResetCommand()
        {
            CurrentCommand = null;
            if (Parent != null)
                Parent.ResetCommand();
        }
    }
    /// <summary>
    /// file separator
    /// 0x1C
    /// 文件分隔符
    /// </summary>
    public abstract class DeviceC0_FS : DeviceC0Base
    {
        public override byte? Code => 0x1C;
    }
    /// <summary>
    /// group separator
    /// 0x1D
    /// 组分隔符
    /// </summary>
    public abstract class DeviceC0_GS : DeviceC0Base
    {
        public override byte? Code => 0x1D;
    }
    /// <summary>
    /// record separator
    /// 0x1E
    /// 记录分隔符
    /// </summary>
    public abstract class DeviceC0_RS : DeviceC0Base
    {
        public override byte? Code => 0x1E;
    }
    /// <summary>
    /// unit separator
    /// 0x1F
    /// 单元分隔符
    /// </summary>
    public abstract class DeviceC0_US : DeviceC0Base
    {
        public override byte? Code => 0x1F;
    }
    /// <summary>
    /// space
    /// 0x20
    /// 空格
    /// </summary>
    public abstract class DeviceC0_SP : DeviceC0Base
    {
        public override byte? Code => 0x20;
    }
    /// <summary>
    /// delete
    /// 0x7F
    /// 删除
    /// </summary>
    public abstract class DeviceC0_DEL : DeviceC0Base
    {
        public override byte? Code => 0x7F;
    }

    /// <summary>
    /// ESC N
    /// single shift two
    /// 0x8e
    /// 单个移位2
    /// </summary>
    public abstract class DeviceC1_SS2 : DeviceC1Base
    {
        public override byte? Code => 0x8E;
    }
    /// <summary>
    /// ESC O
    /// single shift three
    /// 0x8f
    /// 单个移位3
    public abstract class DeviceC1_SS3 : DeviceC1Base
    {
        public override byte? Code => 0x8F;
    }
    /// <summary>
    /// ESC P
    /// device control string
    /// 0x90
    /// 设备控制字符串
    /// </summary>
    public abstract class DeviceC1_DCS : DeviceC1Base
    {
        public override byte? Code => 0x90;
    }
    /// <summary>
    /// ESC [
    /// control sequence introducer
    /// 0x9b
    /// 控制序列开始
    /// </summary>
    public abstract class DeviceC1_CSI : DeviceC1Base
    {
        public override byte? Code => 0x9B;

        public virtual Device_ESC_CSI_CUU? CUU { get; set; } = null;
        public virtual Device_ESC_CSI_CUD? CUD { get; set; } = null;
        public virtual Device_ESC_CSI_CUF? CUF { get; set; } = null;
        public virtual Device_ESC_CSI_CUB? CUB { get; set; } = null;
        public virtual Device_ESC_CSI_CNL? CNL { get; set; } = null;
        public virtual Device_ESC_CSI_CPL? CPL { get; set; } = null;
        public virtual Device_ESC_CSI_CHA? CHA { get; set; } = null;
        public virtual Device_ESC_CSI_CUP? CUP { get; set; } = null;
        public virtual Device_ESC_CSI_ED? ED { get; set; } = null;
        public virtual Device_ESC_CSI_EL? EL { get; set; } = null;
        public virtual Device_ESC_CSI_SU? SU { get; set; } = null;
        public virtual Device_ESC_CSI_SD? SD { get; set; } = null;
        public virtual Device_ESC_CSI_HVP? HVP { get; set; } = null;
        public virtual Device_ESC_CSI_SGR? SGR { get; set; } = null;
        public virtual Device_ESC_CSI_DSR? DSR { get; set; } = null;
        public virtual Device_ESC_CSI_SCP? SCP { get; set; } = null;
        public virtual Device_ESC_CSI_RCP? RCP { get; set; } = null;

        private List<byte> TmpParam = new List<byte>();
        public DeviceC1_CSI()
        {
        }

        public override void Put(byte data)
        {
            if (SGR != null && SGR.Code.Equals(data))
            {
                SGR.Call(TmpParam.ToArray());
                TmpParam.Clear();
                ResetCommand();
            }
            else
            {
                TmpParam.Add(data);
            }
        }
    }
    /// <summary>
    /// ESC \
    /// string terminator
    /// 0x9c
    /// 字符串终止
    /// </summary>
    public abstract class DeviceC1_ST : DeviceC1Base
    {
        public override byte? Code => 0x9C;
    }
    /// <summary>
    /// ESC ]
    /// operating system command
    /// 0x9d
    /// 操作系统命令
    /// </summary>
    public abstract class DeviceC1_OSC : DeviceC1Base
    {
        public override byte? Code => 0x9D;
    }
    /// <summary>
    /// ESC X
    /// start of string
    /// 0x98
    /// 字符串开始
    public abstract class DeviceC1_SOS : DeviceC1Base
    {
        public override byte? Code => 0x98;
    }
    /// <summary>
    /// ESC ^
    /// privacy message
    /// 0x9e
    /// 私密信息
    public abstract class DeviceC1_PM : DeviceC1Base
    {
        public override byte? Code => 0x9E;
    }
    /// <summary>
    /// ESC _
    /// application program command
    /// 0x9f
    /// 应用程序命令
    /// </summary>
    public abstract class DeviceC1_APC : DeviceC1Base
    {
        public override byte? Code => 0x9F;
    }
    /// <summary>
    /// ESC c
    /// reset to initial state
    /// 0x9a
    /// 重置到初始状态
    public abstract class DeviceC1_RIS : DeviceC1Base
    {
        public override byte? Code => 0x9A;
    }

    /// <summary>
    /// CSI n A
    /// cursor up
    /// 光标上移
    public abstract class Device_ESC_CSI_CUU : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('A');
    }
    /// <summary>
    /// CSI n B
    /// cursor down
    /// 光标下移
    public abstract class Device_ESC_CSI_CUD : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('B');
    }
    /// <summary>
    /// CSI n C
    /// cursor forward
    /// 光标前进
    public abstract class Device_ESC_CSI_CUF : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('C');
    }
    /// <summary>
    /// CSI n D
    /// cursor back
    /// 光标后退
    public abstract class Device_ESC_CSI_CUB : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('D');
    }
    /// <summary>
    /// CSI n E
    /// cursor next line
    /// 光标下一行
    public abstract class Device_ESC_CSI_CNL : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('E');
    }
    /// <summary>
    /// CSI n F
    /// cursor previous line
    /// 光标上一行
    public abstract class Device_ESC_CSI_CPL : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('F');
    }
    /// <summary>
    /// CSI n G
    /// cursor horizontal absolute
    /// 光标水平绝对位置
    public abstract class Device_ESC_CSI_CHA : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('G');
    }
    /// <summary>
    /// CSI n;mH
    /// cursor position
    /// 光标位置
    public abstract class Device_ESC_CSI_CUP : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('H');
    }
    /// <summary>
    /// CSI n J
    /// erase in display
    /// 清除屏幕
    public abstract class Device_ESC_CSI_ED : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('J');
    }
    /// <summary>
    /// CSI n K
    /// erase in line
    /// 清除行
    public abstract class Device_ESC_CSI_EL : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('K');
    }
    /// <summary>
    /// CSI n S
    /// scroll up
    /// 滚动上移
    public abstract class Device_ESC_CSI_SU : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('S');
    }
    /// <summary>
    /// CSI n T
    /// scroll down
    /// 滚动下移
    public abstract class Device_ESC_CSI_SD : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('T');
    }
    /// <summary>
    /// CSI n;mf
    /// horizontal and vertical position
    /// 水平和垂直位置
    public abstract class Device_ESC_CSI_HVP : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('f');
    }
    /// <summary>
    /// CSI n m
    /// select graphic rendition
    /// 选择图形呈现
    public abstract class Device_ESC_CSI_SGR : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('m');

        /// <summary>
        /// 重置
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// 粗体
        /// </summary>
        public abstract void Bold();

        /// <summary>
        /// 细体
        /// </summary>
        public abstract void Thin();

        /// <summary>
        /// 斜体
        /// </summary>
        public abstract void Italic();

        /// <summary>
        /// 下划线
        /// </summary>
        public abstract void Underline();

        /// <summary>
        /// 缓慢闪烁
        /// </summary>
        public abstract void BlinkSlow();

        /// <summary>
        /// 快速闪烁
        /// </summary>
        public abstract void BlinkFast();

        /// <summary>
        /// 反显
        /// </summary>
        public abstract void Inverse();

        /// <summary>
        /// 隐藏
        /// </summary>
        public abstract void Hidden();

        /// <summary>
        /// 划线
        /// </summary>
        public abstract void StrikeThrough();

        /// <summary>
        /// 主要字体
        /// </summary>
        public abstract void PrimaryFont();

        /// <summary>
        /// 替代字体
        /// </summary>
        public abstract void AlternateFont();

        /// <summary>
        /// 尖角体
        /// </summary>
        public abstract void ObliqueFont();

        /// <summary>
        /// 关闭粗体或双下划线
        /// </summary>
        public abstract void NoBoldOrUnderline();

        /// <summary>
        /// 非斜体、非尖角体
        /// </summary>
        public abstract void NotItalicOrObliqueFont();

        /// <summary>
        /// 关闭下划线
        /// </summary>
        public abstract void NoUnderline();

        /// <summary>
        /// 关闭闪烁
        /// </summary>
        public abstract void NoBlink();

        /// <summary>
        /// 关闭反显
        /// </summary>
        public abstract void NoInverse();

        /// <summary>
        /// 关闭隐藏
        /// </summary>
        public abstract void NoHidden();

        /// <summary>
        /// 关闭划线
        /// </summary>
        public abstract void NoStrikeThrough();

        /// <summary>
        /// 设置前景色
        /// </summary>
        public abstract void ForegroundColor(Color color);

        /// <summary>
        /// 设置背景色
        /// </summary>
        public abstract void BackgroundColor(Color color);

        /// <summary>
        /// Framed
        /// </summary>
        public abstract void Framed();

        /// <summary>
        /// Encircled
        /// </summary>
        public abstract void Encircled();

        /// <summary>
        /// 上划线
        /// </summary>
        public abstract void Overline();

        /// <summary>
        /// Not framed or encircled
        /// </summary>
        public abstract void NotFramedOrEncircled();

        /// <summary>
        /// 关闭上划线
        /// </summary>
        public abstract void NoOverline();

        /// <summary>
        /// 文字属性关闭
        /// </summary>
        public abstract void NoAttribute();

        public override void Call(byte[] command)
        {
            var commands = new List<byte[]>();
            var tc = new List<byte>();
            foreach (var item in command)
            {
                if(item == 0x3B)
                {
                    commands.Add(tc.ToArray());
                    tc.Clear();
                }
                else
                {
                    tc.Add(item);
                }
            }
            commands.Add(tc.ToArray());
            var length = commands.Count();
            for (int i = 0; i < length; i++)
            {
                var c = Encoding.ASCII.GetString(commands[i]);
                switch (c)
                {
                    case "0":
                        Reset();
                        break;
                    case "1":
                        Bold();
                        break;
                    case "2":
                        Thin();
                        break;
                    case "3":
                        Italic();
                        break;
                    case "4":
                        Underline();
                        break;
                    case "5":
                        BlinkSlow();
                        break;
                    case "6":
                        BlinkFast();
                        break;
                    case "7":
                        Inverse();
                        break;
                    case "8":
                        Hidden();
                        break;
                    case "9":
                        StrikeThrough();
                        break;
                    case "10":
                        PrimaryFont();
                        break;
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                    case "15":
                    case "16":
                    case "17":
                    case "18":
                    case "19":
                        AlternateFont();
                        break;
                    case "20":
                        ObliqueFont();
                        break;
                    case "21":
                        NoBoldOrUnderline();
                        break;
                    case "22":
                        ForegroundColor(Color.Black);
                        BackgroundColor(Color.White);
                        break;
                    case "23":
                        NotItalicOrObliqueFont();
                        break;
                    case "24":
                        NoUnderline();
                        break;
                    case "25":
                        NoBlink();
                        break;
                    case "27":
                        NoInverse();
                        break;
                    case "28":
                        NoHidden();
                        break;
                    case "29":
                        NoStrikeThrough();
                        break;
                    case "30":
                        ForegroundColor(Color.FromArgb(0, 0, 0));
                        break;
                    case "31":
                        ForegroundColor(Color.FromArgb(170, 0, 0));
                        break;
                    case "32":
                        ForegroundColor(Color.FromArgb(0, 170, 0));
                        break;
                    case "33":
                        ForegroundColor(Color.FromArgb(170, 85, 0));
                        break;
                    case "34":
                        ForegroundColor(Color.FromArgb(0, 0, 170));
                        break;
                    case "35":
                        ForegroundColor(Color.FromArgb(170, 0, 170));
                        break;
                    case "36":
                        ForegroundColor(Color.FromArgb(0, 170, 170));
                        break;
                    case "37":
                        ForegroundColor(Color.Black);
                        break;
                    case "38":
                        var v = Encoding.ASCII.GetString(commands[i + 1]);
                        if (v == "5")
                        {
                            ForegroundColor(Color.FromArgb(Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 3]))));
                            i += 4;
                        }
                        else if (v == "2")
                        {
                            ForegroundColor(Color.FromArgb(Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 2])), Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 3])), Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 4]))));
                            i += 5;
                        }
                        else
                            return;
                        break;
                    case "39":
                        ForegroundColor(Color.FromArgb(170, 170, 170));
                        break;
                    case "40":
                        BackgroundColor(Color.FromArgb(0, 0, 0));
                        break;
                    case "41":
                        BackgroundColor(Color.FromArgb(170, 0, 0));
                        break;
                    case "42":
                        BackgroundColor(Color.FromArgb(0, 170, 0));
                        break;
                    case "43":
                        BackgroundColor(Color.FromArgb(170, 85, 0));
                        break;
                    case "44":
                        BackgroundColor(Color.FromArgb(0, 0, 170));
                        break;
                    case "45":
                        BackgroundColor(Color.FromArgb(170, 0, 170));
                        break;
                    case "46":
                        BackgroundColor(Color.FromArgb(0, 170, 170));
                        break;
                    case "47":
                        BackgroundColor(Color.FromArgb(170, 170, 170));
                        break;
                    case "48":
                        var v2 = Encoding.ASCII.GetString(commands[i + 1]);
                        if (v2 == "5")
                        {
                            BackgroundColor(Color.FromArgb(Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 3]))));
                            i += 4;
                        }
                        else if (v2 == "2")
                        {
                            BackgroundColor(Color.FromArgb(Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 2])), Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 3])), Convert.ToInt16(Encoding.ASCII.GetString(commands[i + 4]))));
                            i += 5;
                        }
                        else
                            return;
                        break;
                    case "49":
                        BackgroundColor(Color.White);
                        break;
                    case "51":
                        Framed();
                        break;
                    case "52":
                        Encircled();
                        break;
                    case "53":
                        Overline();
                        break;
                    case "54":
                        NotFramedOrEncircled();
                        break;
                    case "55":
                        NoOverline();
                        break;
                    case "65":
                        NoAttribute();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    /// <summary>
    /// CSI 6n
    /// device status report
    /// 设备状态报告
    public abstract class Device_ESC_CSI_DSR : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('n');
    }
    /// <summary>
    /// CSI s
    /// save cursor position
    /// 保存光标位置
    public abstract class Device_ESC_CSI_SCP : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('s');
    }
    /// <summary>
    /// CSI u
    /// restore cursor position
    /// 恢复光标位置
    public abstract class Device_ESC_CSI_RCP : DeviceCBase
    {
        public override byte? Code => Convert.ToByte('u');
    }


    public abstract class RenderDeviceBase : DeviceCBase
    {
        public virtual DeviceC0_NULL? NULL { get; set; } = null;
        public virtual DeviceC0_SOH? SOH { get; set; } = null;
        public virtual DeviceC0_STX? STX { get; set; } = null;
        public virtual DeviceC0_ETX? ETX { get; set; } = null;
        public virtual DeviceC0_EOT? EOT { get; set; } = null;
        public virtual DeviceC0_ENQ? ENQ { get; set; } = null;
        public virtual DeviceC0_ACK? ACK { get; set; } = null;
        public virtual DeviceC0_BEL? BEL { get; set; } = null;
        public virtual DeviceC0_BS? BS { get; set; } = null;
        public virtual DeviceC0_HT? HT { get; set; } = null;
        public virtual DeviceC0_LF? LF { get; set; } = null;
        public virtual DeviceC0_VT? VT { get; set; } = null;
        public virtual DeviceC0_FF? FF { get; set; } = null;
        public virtual DeviceC0_CR? CR { get; set; } = null;
        public virtual DeviceC0_SO? SO { get; set; } = null;
        public virtual DeviceC0_SI? SI { get; set; } = null;
        public virtual DeviceC0_DLE? DLE { get; set; } = null;
        public virtual DeviceC0_DC1? DC1 { get; set; } = null;
        public virtual DeviceC0_DC2? DC2 { get; set; } = null;
        public virtual DeviceC0_DC3? DC3 { get; set; } = null;
        public virtual DeviceC0_DC4? DC4 { get; set; } = null;
        public virtual DeviceC0_NAK? NAK { get; set; } = null;
        public virtual DeviceC0_SYN? SYN { get; set; } = null;
        public virtual DeviceC0_ETB? ETB { get; set; } = null;
        public virtual DeviceC0_CAN? CAN { get; set; } = null;
        public virtual DeviceC0_EM? EM { get; set; } = null;
        public virtual DeviceC0_SUB? SUB { get; set; } = null;
        public virtual DeviceC0_ESC? ESC { get; set; } = null;
        public virtual DeviceC0_FS? FS { get; set; } = null;
        public virtual DeviceC0_GS? GS { get; set; } = null;
        public virtual DeviceC0_RS? RS { get; set; } = null;
        public virtual DeviceC0_US? US { get; set; } = null;
        public virtual DeviceC0_DEL? DEL { get; set; } = null;

        public override void OtherOut(byte data)
        {
        }

        public RenderDeviceBase()
        {
        }

        public override void Put(byte data)
        {
            if (CurrentCommand != null)
            {
                CurrentCommand.Put(data);
                return;
            }
            if (ESC != null && ESC.Code.Equals(data))
            {
                CurrentCommand = ESC;
            }
            else
            {
                OtherOut(data);
            }
        }

        public override void ResetCommand()
        {
            CurrentCommand = null;
            if (Parent != null)
                Parent.ResetCommand();
        }
    }
}
