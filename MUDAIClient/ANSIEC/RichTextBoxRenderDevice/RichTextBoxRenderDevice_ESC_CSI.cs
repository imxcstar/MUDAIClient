using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUDAIClient.ANSIEC.RichTextBoxRenderDevice
{
    public class RichTextBoxRenderDevice_ESC_CSI : DeviceC1_CSI
    {
        private RichTextBox _viewText;
        public RichTextBoxRenderDevice_ESC_CSI_SGR CustomSGR { get; set; }

        public RichTextBoxRenderDevice_ESC_CSI(RichTextBox viewTextBox)
        {
            _viewText = viewTextBox;
            CustomSGR = new RichTextBoxRenderDevice_ESC_CSI_SGR(_viewText);
            SGR = CustomSGR;
            SGR.Parent = this;
        }
    }
}
