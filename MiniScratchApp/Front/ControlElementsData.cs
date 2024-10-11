using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniScratchApp.Front
{
    public class ControlElementsData
    {
        // Positions
        public Point TxtBoxInboundAddressPosition { get; set; }
        public Point TxtBoxInboundPortPosition { get; set; }
        public Point TxtBoxOutboundAddressPosition { get; set; }
        public Point TxtBoxOutboundPortPosition { get; set; }
        public Point TextBoxBodyPosition { get; set; }
        public Point TextBoxHeadersPosition {  get; set; }
        public Point TextBoxIncomingRequestsPosition { get; set; }

        // Values
        public string TxtBoxInboundAddressText { get; set; } = null!;
        public string TxtBoxInboundPortText { get; set; } = null!;
        public string TxtBoxOutboundAddressText { get; set; } = null!;
        public string TxtBoxOutboundPortText { get; set; } = null!;
        public string TextBoxBodyText { get; set; } = null!;
        public string TextBoxHeadersText { get; set; } = null!;
        public string TextBoxIncomingRequestsText { get; set; } = null!;
        public int ComboBoxSelectedIndex { get; set; }
    }
}
