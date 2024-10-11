using MiniScratchApp.Front;
using MiniScratchApp.Server;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MiniScratchApp
{
    public partial class Form : System.Windows.Forms.Form
    {

        private string ConfigFilePath = "controlPositions.json";
        private bool IsDragging = false;
        private Point StartPoint = new Point(0, 0);
        private bool IsServerRunning = false;
        private ScratchHttpServer ScratchHttpServer = new ScratchHttpServer();

        public Form()
        {
            InitializeComponent();
            LoadControlData();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveControlData();
            base.OnFormClosing(e);
        }

        private void LoadControlData()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    var json = File.ReadAllText(ConfigFilePath);
                    var controlElementsData = JsonConvert.DeserializeObject<ControlElementsData>(json);
                    if (controlElementsData != null)
                    {
                        // Positions
                        TxtBoxInboundAddress.Location = controlElementsData.TxtBoxInboundAddressPosition;
                        TxtBoxInboundPort.Location = controlElementsData.TxtBoxInboundPortPosition;
                        TxtBoxOutboundAddress.Location = controlElementsData.TxtBoxOutboundAddressPosition;
                        TxtBoxOutboundPort.Location = controlElementsData.TxtBoxOutboundPortPosition;
                        TextBoxMessageBody.Location = controlElementsData.TextBoxMessageBodyPosition;
                        TextBoxIncomingRequests.Location = controlElementsData.TextBoxIncomingRequestsPosition;

                        // Values  
                        TxtBoxInboundAddress.Text = controlElementsData.TxtBoxInboundAddressText;
                        TxtBoxInboundPort.Text = controlElementsData.TxtBoxInboundPortText;
                        TxtBoxOutboundAddress.Text = controlElementsData.TxtBoxOutboundAddressText;
                        TxtBoxOutboundPort.Text = controlElementsData.TxtBoxOutboundPortText;
                        TextBoxMessageBody.Text = controlElementsData.TextBoxSeMessageBodyText;
                        TextBoxIncomingRequests.Text = controlElementsData.TextBoxIncomingRequestsText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                return;
            }      
        }

        private void SaveControlData()
        {
            try
            {
                var controlElementsData = new ControlElementsData
                {
                    // Positions
                    TxtBoxInboundAddressPosition = TxtBoxInboundAddress.Location,
                    TxtBoxInboundPortPosition = TxtBoxInboundPort.Location,
                    TxtBoxOutboundAddressPosition = TxtBoxOutboundAddress.Location,
                    TxtBoxOutboundPortPosition = TxtBoxOutboundPort.Location,
                    TextBoxMessageBodyPosition = TextBoxMessageBody.Location,
                    TextBoxIncomingRequestsPosition = TextBoxIncomingRequests.Location,

                    // Values
                    TxtBoxInboundAddressText = TxtBoxInboundAddress.Text,
                    TxtBoxInboundPortText = TxtBoxInboundPort.Text,
                    TxtBoxOutboundAddressText = TxtBoxOutboundAddress.Text,
                    TxtBoxOutboundPortText = TxtBoxOutboundPort.Text,
                    TextBoxSeMessageBodyText = TextBoxMessageBody.Text,
                    TextBoxIncomingRequestsText = TextBoxIncomingRequests.Text
                };
                var json = JsonConvert.SerializeObject(controlElementsData);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error saving data: " + ex.Message);
                return;
            }  
        }

        // Drag and drop functions
        private void TxtBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                IsDragging = true;
                StartPoint = new Point(e.X, e.Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void TxtBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
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

                        // Ensure the control doesn't go beyond the form's boundaries
                        int maxX = this.ClientSize.Width - control.Width;  // Right boundary
                        int maxY = this.ClientSize.Height - control.Height; // Bottom boundary

                        // Clamp the X and Y coordinates within the boundaries
                        newLocation.X = Math.Max(0, Math.Min(newLocation.X, maxX)); // Ensure it's between 0 and maxX
                        newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, maxY)); // Ensure it's between 0 and maxY

                        // Update the control's location
                        control.Location = newLocation;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }      
        }

        private void TxtBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    IsDragging = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Buttons functions
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveControlData();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsServerRunning)
                {
                    MessageBox.Show("The server is already running. If you have input changes, please stop it and start it again. ");
                    return;
                }
                string inboundAddress = TxtBoxInboundAddress.Text;
                string inboundPort = TxtBoxInboundPort.Text;
                if (string.IsNullOrEmpty(inboundAddress) || string.IsNullOrEmpty(inboundPort))
                {
                    MessageBox.Show("Please enter inboundAddress and inboundPort!");
                    return;
                }

                // Generate the full URL for the request
                var url = $"http://{inboundAddress}:{inboundPort}/";
                if (!IsValidUrl(url))
                {
                    MessageBox.Show("The final URL is not valid. Please check your inboundAddress and inboundPort");
                    return;
                }

                ScratchHttpServer.Start(url);
                IsServerRunning = true;
                MessageBox.Show("Server is listening on port: " + url);
                return;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            try
            {
                if (!IsServerRunning)
                {
                    MessageBox.Show("The server is not running!");
                    return;
                }

                ScratchHttpServer.Stop();
                IsServerRunning = false;
                MessageBox.Show("Server stopped");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Other private methods
        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
