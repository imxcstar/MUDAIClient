using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUDAIClient.ANSIEC.RichTextBoxRenderDevice
{
    public class RichTextBoxRenderDevice_ESC : DeviceC0_ESC
    {
        private RichTextBox _viewText;
        public RichTextBoxRenderDevice_ESC_CSI CustomCSI { get; set; }

        public RichTextBoxRenderDevice_ESC(RichTextBox viewTextBox)
        {
            _viewText = viewTextBox;
            CustomCSI = new RichTextBoxRenderDevice_ESC_CSI(_viewText);
            CSI = CustomCSI;
            CSI.Parent = this;
        }
    }
}
