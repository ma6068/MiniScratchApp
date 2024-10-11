using MiniScratchApp.Client;
using MiniScratchApp.Front;
using MiniScratchApp.Server;
using Newtonsoft.Json;

namespace MiniScratchApp
{
    public partial class Form : System.Windows.Forms.Form
    {

        private string ConfigFilePath = "controlPositions.json";
        private bool IsDragging;
        private Point StartPoint;
        private bool IsServerRunning;
        private ScratchHttpServer ScratchHttpServer;
        private ScratchHttpClient ScratchHttpClient;

        public Form()
        {
            InitializeComponent();
            LoadControlData();
            IsDragging = false;
            StartPoint = new Point(0, 0);
            IsServerRunning = false;
            ScratchHttpServer = new ScratchHttpServer();
            ScratchHttpClient = new ScratchHttpClient();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveControlData();
            ScratchHttpServer.Stop();
            ScratchHttpServer.Close();
            ScratchHttpClient.Stop();
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
                        TextBoxBody.Location = controlElementsData.TextBoxBodyPosition;
                        TextBoxHeaders.Location = controlElementsData.TextBoxHeadersPosition;
                        TextBoxIncomingRequests.Location = controlElementsData.TextBoxIncomingRequestsPosition;

                        // Values  
                        TxtBoxInboundAddress.Text = controlElementsData.TxtBoxInboundAddressText;
                        TxtBoxInboundPort.Text = controlElementsData.TxtBoxInboundPortText;
                        TxtBoxOutboundAddress.Text = controlElementsData.TxtBoxOutboundAddressText;
                        TxtBoxOutboundPort.Text = controlElementsData.TxtBoxOutboundPortText;
                        TextBoxBody.Text = controlElementsData.TextBoxBodyText;
                        TextBoxHeaders.Text = controlElementsData.TextBoxHeadersText;
                        TextBoxIncomingRequests.Text = controlElementsData.TextBoxIncomingRequestsText;
                        ComboBoxMethod.SelectedIndex = controlElementsData.ComboBoxSelectedIndex;
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
                    TextBoxBodyPosition = TextBoxBody.Location,
                    TextBoxHeadersPosition = TextBoxHeaders.Location,
                    TextBoxIncomingRequestsPosition = TextBoxIncomingRequests.Location,

                    // Values
                    TxtBoxInboundAddressText = TxtBoxInboundAddress.Text,
                    TxtBoxInboundPortText = TxtBoxInboundPort.Text,
                    TxtBoxOutboundAddressText = TxtBoxOutboundAddress.Text,
                    TxtBoxOutboundPortText = TxtBoxOutboundPort.Text,
                    TextBoxBodyText = TextBoxBody.Text,
                    TextBoxHeadersText = TextBoxHeaders.Text,
                    TextBoxIncomingRequestsText = TextBoxIncomingRequests.Text,
                    ComboBoxSelectedIndex = ComboBoxMethod.SelectedIndex
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
                IsDragging = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // Buttons functions
        private void BtnSaveData_Click(object sender, EventArgs e)
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
                var setForStartServer = AllSetForStartingServer();
                if (setForStartServer)
                {
                    StartServer();
                }
                var setForStartClient = AllSetForStartingClient();
                if (setForStartClient)
                {
                    SendRequestClient();
                }
                if (!setForStartServer && !setForStartClient)
                {
                    MessageBox.Show("Please enter all the necessary elements to start the server or to send the request.");
                    return;
                }
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
                ScratchHttpServer.Stop();
                IsServerRunning = false;
                ScratchHttpClient.Stop();
                MessageBox.Show("The server and sending requests have been stopped.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Check if the control is in panel
        /// </summary>
        /// <param name="control"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        private bool IsControlEntirelyWithinPanel(Control control, Panel panel)
        {
            // Get panel's top-left corner location and its width and height (screen coordinates)
            Point panelTopLeft = panel.PointToScreen(Point.Empty);
            Point panelBottomRight = new Point(panelTopLeft.X + panel.Width, panelTopLeft.Y + panel.Height);

            // Get control's top-left corner location and its width and height (screen coordinates)
            Point controlTopLeft = control.PointToScreen(Point.Empty);
            Point controlBottomRight = new Point(controlTopLeft.X + control.Width, controlTopLeft.Y + control.Height);

            // Check if the entire control is within the panel's boundaries
            return (controlTopLeft.X >= panelTopLeft.X && controlTopLeft.Y >= panelTopLeft.Y &&
                    controlBottomRight.X <= panelBottomRight.X && controlBottomRight.Y <= panelBottomRight.Y);
        }

        /// <summary>
        /// Checks if all required fields are inside the panel to start the server
        /// </summary>
        /// <returns></returns>
        private bool AllSetForStartingServer()
        {
            if (IsControlEntirelyWithinPanel(TxtBoxInboundAddress, PanelRun) &&
                IsControlEntirelyWithinPanel(TxtBoxInboundPort, PanelRun))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if all required fields are inside the panel to start the client
        /// Headers is not required
        /// Body is required if we have POST or PUT request
        /// </summary>
        /// <returns></returns>
        private bool AllSetForStartingClient()
        {
            var addressSet = IsControlEntirelyWithinPanel(TxtBoxOutboundAddress, PanelRun);
            var portSet = IsControlEntirelyWithinPanel(TxtBoxOutboundPort, PanelRun);
            var bodySet = IsControlEntirelyWithinPanel(TextBoxBody, PanelRun);         
            if (addressSet && portSet)
            {
                // GET and DELETE
                if (ComboBoxMethod.SelectedIndex == 0 || ComboBoxMethod.SelectedIndex == 3)
                {
                    return true;
                }
                // POST and PUT
                if (bodySet)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method for starting the server
        /// </summary>
        private void StartServer()
        {
            // If is already running we stop (maybe there is url change and we did not have multiple starts)
            if (IsServerRunning)
            {
                ScratchHttpServer.Stop();
                IsServerRunning = false;
            }

            // Validation
            string inboundAddress = TxtBoxInboundAddress.Text;
            string inboundPort = TxtBoxInboundPort.Text;
            if (string.IsNullOrEmpty(inboundAddress) || string.IsNullOrEmpty(inboundPort))
            {
                MessageBox.Show("Please enter inboundAddress and inboundPort!");
                return;
            }

            var url = $"{inboundAddress}:{inboundPort}/";
            if (!IsValidUrl(url))
            {
                MessageBox.Show("The final inbound url is not valid. Please check your inboundAddress and inboundPort");
                return;
            }

            ScratchHttpServer.Start(url, TextBoxIncomingRequests);
            IsServerRunning = true;
        }

        /// <summary>
        /// Method for sending request
        /// </summary>
        private async void SendRequestClient()
        {
            string outboundAddress = TxtBoxOutboundAddress.Text;
            string outboundPort = TxtBoxOutboundPort.Text;
            string body = TextBoxBody.Text;
            string headers = TextBoxHeaders.Text;
            int selectedIndex = ComboBoxMethod.SelectedIndex;

            // Validation
            if (string.IsNullOrEmpty(outboundAddress) || string.IsNullOrEmpty(outboundPort))
            {
                MessageBox.Show("Please enter outboundAddress and outboundPort!");
                return;
            }
            if (string.IsNullOrEmpty(body) && (selectedIndex == 1 || selectedIndex == 2))
            {
                MessageBox.Show("Please enter body if you are using POST or PUT method");
                return;
            }
            var url = $"{outboundAddress}:{outboundPort}/";
            if (!IsValidUrl(url))
            {
                MessageBox.Show("The final outbound url is not valid. Please check your outboundAddress and outboundPort");
                return;
            }
            var method = selectedIndex == 0 ? "GET" : selectedIndex == 1 ? "POST" : selectedIndex == 2 ? "PUT" : "DELETE";

            await ScratchHttpClient.SendRequest(url, method, body, headers);
        }

        /// <summary>
        /// Check if url is valid
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
