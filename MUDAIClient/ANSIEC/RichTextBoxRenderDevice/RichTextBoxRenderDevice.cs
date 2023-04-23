using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUDAIClient.ANSIEC.RichTextBoxRenderDevice
{
    public enum RichTextBoxRenderDeviceEncoding
    {
        GBK,
        UTF8
    }

    public class RichTextBoxRenderDevice : RenderDeviceBase
    {
        private byte UTF8CharacterMask1Byte = 0b1000_0000;
        private byte Valid1Byte = 0b0000_0000;

        private byte UTF8CharacterMask2Byte = 0b1110_0000;
        private byte Valid2Byte = 0b1100_0000;

        private byte UTF8CharacterMask3Byte = 0b1111_0000;
        private byte Valid3Byte = 0b1110_0000;

        private byte UTF8CharacterMask4Byte = 0b1111_1000;
        private byte Valid4Byte = 0b1111_0000;

        private List<byte> _Ret = new List<byte>();
        private string _EncodingStr = "GBK";
        private RichTextBoxRenderDeviceEncoding _Encoding = RichTextBoxRenderDeviceEncoding.GBK;
        private RichTextBox _viewText;

        public string DEncodingStr => _EncodingStr;
        public RichTextBoxRenderDeviceEncoding DEncoding
        {
            get => _Encoding;
            set
            {
                _Encoding = value;
                switch (_Encoding)
                {
                    case RichTextBoxRenderDeviceEncoding.GBK:
                        _EncodingStr = "GBK";
                        break;
                    case RichTextBoxRenderDeviceEncoding.UTF8:
                        _EncodingStr = "UTF-8";
                        break;
                    default:
                        break;
                }
            }
        }

        private RichTextBoxRenderDevice_ESC _customEsc;

        public RichTextBoxRenderDevice(RichTextBox viewTextBox) : base()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _viewText = viewTextBox;
            _customEsc = new RichTextBoxRenderDevice_ESC(_viewText);
            ESC = _customEsc;
            ESC.Parent = this;
        }

        public override void OtherOut(byte data)
        {
            _Ret.Add(data);
            var f = _Ret.First();
            var l = _Ret.Count();
            switch (_Encoding)
            {
                case RichTextBoxRenderDeviceEncoding.GBK:
                    if (!(f <= 0x7F || l == 2))
                        return;
                    break;
                case RichTextBoxRenderDeviceEncoding.UTF8:
                    if (!((f & UTF8CharacterMask1Byte) == Valid1Byte && l == 1 ||
                        (f & UTF8CharacterMask2Byte) == Valid2Byte && l == 2 ||
                        (f & UTF8CharacterMask3Byte) == Valid3Byte && l == 3 ||
                        (f & UTF8CharacterMask4Byte) == Valid4Byte && l == 4 ||
                        l > 4))
                        return;
                    break;
                default:
                    break;
            }
            if (_customEsc.CustomCSI.CustomSGR.IsSetValue && !_customEsc.CustomCSI.CustomSGR.IsHindText)
            {
                _viewText.Invoke(() =>
                {
                    _viewText.SelectionStart = _viewText.TextLength;
                    _viewText.SelectedText = Encoding.GetEncoding(_EncodingStr).GetString(_Ret.ToArray());
                    if (_Ret.Contains(0x0D))
                    {
                        _viewText.SelectionStart = _viewText.TextLength;
                        _viewText.ScrollToCaret();
                    }
                });
            }
            _Ret.Clear();
        }
    }
}
