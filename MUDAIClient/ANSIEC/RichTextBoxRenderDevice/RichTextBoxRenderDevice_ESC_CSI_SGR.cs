using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUDAIClient.ANSIEC.RichTextBoxRenderDevice
{
    public class RichTextBoxRenderDevice_ESC_CSI_SGR : Device_ESC_CSI_SGR
    {
        private RichTextBox _viewText;
        public bool IsHindText { get; set; }
        public bool IsSetStyle { get; set; }
        public bool IsSetValue { get; set; }

        public RichTextBoxRenderDevice_ESC_CSI_SGR(RichTextBox viewTextBox)
        {
            _viewText = viewTextBox;
            IsHindText = false;
            IsSetStyle = true;
            IsSetValue = true;
        }

        public override void AlternateFont()
        {
        }

        public override void BackgroundColor(Color color)
        {
            if (!IsSetStyle)
                return;
            _viewText.Invoke(() =>
            {
                _viewText.SelectionBackColor = color;
            });
        }

        public override void BlinkFast()
        {
        }

        public override void BlinkSlow()
        {
        }

        public override void Bold()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                _viewText.SelectionFont = new Font(_viewText.Font, _viewText.Font.Style);
            if (!_viewText.SelectionFont.Bold)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style | FontStyle.Bold);
        }

        public override void Encircled()
        {
        }

        public override void ForegroundColor(Color color)
        {
            if (!IsSetStyle)
                return;
            _viewText.Invoke(() =>
            {
                _viewText.SelectionColor = color;
            });
        }

        public override void Framed()
        {
        }

        public override void Hidden()
        {
            if (!IsSetStyle)
                return;
            IsHindText = true;
        }

        public override void Inverse()
        {
            if (!IsSetStyle)
                return;
            var color = _viewText.SelectionColor;
            _viewText.SelectionColor = _viewText.SelectionBackColor;
            _viewText.SelectionBackColor = color;
        }

        public override void Italic()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                _viewText.SelectionFont = new Font(_viewText.Font, _viewText.Font.Style);
            if (!_viewText.SelectionFont.Italic)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style | FontStyle.Italic);
        }

        public override void NoAttribute()
        {
        }

        public override void NoBlink()
        {
        }

        public override void NoBoldOrUnderline()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                return;
            if (_viewText.SelectionFont.Bold)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style ^ FontStyle.Bold);
        }

        public override void NoHidden()
        {
            if (!IsSetStyle)
                return;
            IsHindText = false;
        }

        public override void NoInverse()
        {
            Inverse();
        }

        public override void NoOverline()
        {
        }

        public override void NoStrikeThrough()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                return;
            if (_viewText.SelectionFont.Strikeout)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style ^ FontStyle.Strikeout);
        }

        public override void NotFramedOrEncircled()
        {
        }

        public override void NotItalicOrObliqueFont()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                return;
            if (_viewText.SelectionFont.Italic)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style ^ FontStyle.Italic);
        }

        public override void NoUnderline()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                return;
            if (_viewText.SelectionFont.Underline)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style ^ FontStyle.Underline);
        }

        public override void ObliqueFont()
        {
        }

        public override void Overline()
        {
        }

        public override void PrimaryFont()
        {
        }

        public override void Reset()
        {
            if (!IsSetStyle)
                return;
            _viewText.SelectionFont = new Font(_viewText.Font, _viewText.Font.Style);
            _viewText.SelectionColor = Color.Black;
            _viewText.SelectionBackColor = Color.White;
        }

        public override void StrikeThrough()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                _viewText.SelectionFont = new Font(_viewText.Font, _viewText.Font.Style);
            if (!_viewText.SelectionFont.Strikeout)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style | FontStyle.Strikeout);
        }

        public override void Thin()
        {
        }

        public override void Underline()
        {
            if (!IsSetStyle)
                return;
            if (_viewText.SelectionFont == null)
                _viewText.SelectionFont = new Font(_viewText.Font, _viewText.Font.Style);
            if (!_viewText.SelectionFont.Underline)
                _viewText.SelectionFont = new Font(_viewText.SelectionFont, _viewText.SelectionFont.Style | FontStyle.Underline);
        }
    }
}
