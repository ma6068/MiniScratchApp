using Newtonsoft.Json;

namespace MiniScratchApp
{
    public partial class Form : System.Windows.Forms.Form
    {

        private string ConfigFilePath = "controlPositions.json";
        private bool IsDragging = false;
        private Point StartPoint = new Point(0, 0);

        public Form()
        {
            InitializeComponent();
            LoadControlPositions();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveControlPositions();
            base.OnFormClosing(e);
        }

        private void LoadControlPositions()
        {
            if (File.Exists(ConfigFilePath))
            {
                var json = File.ReadAllText(ConfigFilePath);
                var positions = JsonConvert.DeserializeObject<ControlPositions>(json);
                if (positions != null)
                {
                    txtBoxInboundAddress.Location = positions.TxtBoxInboundAddressPosition;
                    txtBoxInboundPort.Location = positions.TxtBoxInboundPortPosition;
                    txtBoxOutboundAddress.Location = positions.TxtBoxOutboundAddressPosition;
                    txtBoxOutboundPort.Location = positions.TxtBoxOutboundPortPosition;
                    textBoxSendingMessage.Location = positions.TextBoxSendingMessagePosition;
                    textBoxIncomingRequests.Location = positions.TextBoxIncomingRequestsPosition;
                }
            }
        }

        private void SaveControlPositions()
        {
            try
            {
                var positions = new ControlPositions
                {
                    TxtBoxInboundAddressPosition = txtBoxInboundAddress.Location,
                    TxtBoxInboundPortPosition = txtBoxInboundPort.Location,
                    TxtBoxOutboundAddressPosition = txtBoxOutboundAddress.Location,
                    TxtBoxOutboundPortPosition = txtBoxOutboundPort.Location,
                    TextBoxSendingMessagePosition = textBoxSendingMessage.Location,
                    TextBoxIncomingRequestsPosition = textBoxIncomingRequests.Location
                };
                var json = JsonConvert.SerializeObject(positions);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex) {
                MessageBox.Show("Error saving configuration: " + ex.Message);
            }  
        }

        private void txtBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsDragging = true; 
            StartPoint = new Point(e.X, e.Y);
        }

        private void txtBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                Control control = sender as Control;
                if (control != null)
                {
                    // Get the new position of the control
                    Point newLocation = control.Location;
                    newLocation.X += e.X - StartPoint.X;
                    newLocation.Y += e.Y - StartPoint.Y;

                    // Update the control's location
                    control.Location = newLocation;
                }
            }
        }

        private void txtBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = false; 
            }
        }
    }
}
