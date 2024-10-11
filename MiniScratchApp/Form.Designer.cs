namespace MiniScratchApp
{
    partial class Form
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
            TxtBoxInboundAddress = new TextBox();
            TxtBoxInboundPort = new TextBox();
            TxtBoxOutboundAddress = new TextBox();
            TxtBoxOutboundPort = new TextBox();
            TextBoxBody = new TextBox();
            TextBoxIncomingRequests = new TextBox();
            BtnSaveData = new Button();
            BtnStart = new Button();
            BtnStop = new Button();
            TextBoxHeaders = new TextBox();
            PanelRun = new Panel();
            ComboBoxMethod = new ComboBox();
            SuspendLayout();
            // 
            // TxtBoxInboundAddress
            // 
            TxtBoxInboundAddress.Location = new Point(62, 45);
            TxtBoxInboundAddress.Name = "TxtBoxInboundAddress";
            TxtBoxInboundAddress.PlaceholderText = "Inbound Address";
            TxtBoxInboundAddress.Size = new Size(148, 27);
            TxtBoxInboundAddress.TabIndex = 0;
            TxtBoxInboundAddress.MouseDown += TxtBox_MouseDown;
            TxtBoxInboundAddress.MouseMove += TxtBox_MouseMove;
            TxtBoxInboundAddress.MouseUp += TxtBox_MouseUp;
            // 
            // TxtBoxInboundPort
            // 
            TxtBoxInboundPort.Location = new Point(62, 132);
            TxtBoxInboundPort.Name = "TxtBoxInboundPort";
            TxtBoxInboundPort.PlaceholderText = "Inbound Port";
            TxtBoxInboundPort.Size = new Size(148, 27);
            TxtBoxInboundPort.TabIndex = 1;
            TxtBoxInboundPort.MouseDown += TxtBox_MouseDown;
            TxtBoxInboundPort.MouseMove += TxtBox_MouseMove;
            TxtBoxInboundPort.MouseUp += TxtBox_MouseUp;
            // 
            // TxtBoxOutboundAddress
            // 
            TxtBoxOutboundAddress.Location = new Point(62, 88);
            TxtBoxOutboundAddress.Name = "TxtBoxOutboundAddress";
            TxtBoxOutboundAddress.PlaceholderText = "Outbound Address";
            TxtBoxOutboundAddress.Size = new Size(148, 27);
            TxtBoxOutboundAddress.TabIndex = 2;
            TxtBoxOutboundAddress.MouseDown += TxtBox_MouseDown;
            TxtBoxOutboundAddress.MouseMove += TxtBox_MouseMove;
            TxtBoxOutboundAddress.MouseUp += TxtBox_MouseUp;
            // 
            // TxtBoxOutboundPort
            // 
            TxtBoxOutboundPort.Location = new Point(62, 172);
            TxtBoxOutboundPort.Name = "TxtBoxOutboundPort";
            TxtBoxOutboundPort.PlaceholderText = "Outbound Port";
            TxtBoxOutboundPort.Size = new Size(148, 27);
            TxtBoxOutboundPort.TabIndex = 3;
            TxtBoxOutboundPort.MouseDown += TxtBox_MouseDown;
            TxtBoxOutboundPort.MouseMove += TxtBox_MouseMove;
            TxtBoxOutboundPort.MouseUp += TxtBox_MouseUp;
            // 
            // TextBoxBody
            // 
            TextBoxBody.Location = new Point(805, 176);
            TextBoxBody.Multiline = true;
            TextBoxBody.Name = "TextBoxBody";
            TextBoxBody.PlaceholderText = "Body";
            TextBoxBody.Size = new Size(321, 132);
            TextBoxBody.TabIndex = 4;
            TextBoxBody.MouseDown += TxtBox_MouseDown;
            TextBoxBody.MouseMove += TxtBox_MouseMove;
            TextBoxBody.MouseUp += TxtBox_MouseUp;
            // 
            // TextBoxIncomingRequests
            // 
            TextBoxIncomingRequests.Location = new Point(230, 45);
            TextBoxIncomingRequests.Multiline = true;
            TextBoxIncomingRequests.Name = "TextBoxIncomingRequests";
            TextBoxIncomingRequests.PlaceholderText = "Incoming requests";
            TextBoxIncomingRequests.Size = new Size(558, 154);
            TextBoxIncomingRequests.TabIndex = 5;
            TextBoxIncomingRequests.MouseDown += TxtBox_MouseDown;
            TextBoxIncomingRequests.MouseMove += TxtBox_MouseMove;
            TextBoxIncomingRequests.MouseUp += TxtBox_MouseUp;
            // 
            // BtnSaveData
            // 
            BtnSaveData.Location = new Point(785, 400);
            BtnSaveData.Name = "BtnSaveData";
            BtnSaveData.Size = new Size(94, 29);
            BtnSaveData.TabIndex = 6;
            BtnSaveData.Text = "Save data";
            BtnSaveData.UseVisualStyleBackColor = true;
            BtnSaveData.Click += BtnSaveData_Click;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(785, 460);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(94, 29);
            BtnStart.TabIndex = 7;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(785, 513);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(94, 29);
            BtnStop.TabIndex = 8;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStopClick;
            // 
            // TextBoxHeaders
            // 
            TextBoxHeaders.Location = new Point(805, 45);
            TextBoxHeaders.Multiline = true;
            TextBoxHeaders.Name = "TextBoxHeaders";
            TextBoxHeaders.PlaceholderText = "Headers";
            TextBoxHeaders.Size = new Size(310, 114);
            TextBoxHeaders.TabIndex = 9;
            TextBoxHeaders.MouseDown += TxtBox_MouseDown;
            TextBoxHeaders.MouseMove += TxtBox_MouseMove;
            TextBoxHeaders.MouseUp += TxtBox_MouseUp;
            // 
            // PanelRun
            // 
            PanelRun.BackColor = SystemColors.ActiveCaptionText;
            PanelRun.Location = new Point(35, 242);
            PanelRun.Name = "PanelRun";
            PanelRun.Size = new Size(730, 300);
            PanelRun.TabIndex = 10;
            // 
            // ComboBoxMethod
            // 
            ComboBoxMethod.FormattingEnabled = true;
            ComboBoxMethod.Items.AddRange(new object[] { "GET", "POST", "PUT", "DELETE" });
            ComboBoxMethod.Location = new Point(785, 327);
            ComboBoxMethod.Name = "ComboBoxMethod";
            ComboBoxMethod.Size = new Size(94, 28);
            ComboBoxMethod.TabIndex = 11;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 581);
            Controls.Add(TextBoxBody);
            Controls.Add(ComboBoxMethod);
            Controls.Add(BtnStop);
            Controls.Add(BtnStart);
            Controls.Add(BtnSaveData);
            Controls.Add(TxtBoxOutboundAddress);
            Controls.Add(TxtBoxOutboundPort);
            Controls.Add(TextBoxIncomingRequests);
            Controls.Add(TextBoxHeaders);
            Controls.Add(TxtBoxInboundPort);
            Controls.Add(TxtBoxInboundAddress);
            Controls.Add(PanelRun);
            Name = "Form";
            Text = "Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtBoxInboundAddress;
        private TextBox TxtBoxInboundPort;
        private TextBox TxtBoxOutboundAddress;
        private TextBox TxtBoxOutboundPort;
        private TextBox TextBoxBody;
        private TextBox TextBoxHeaders;
        private TextBox TextBoxIncomingRequests;
        private Button BtnSaveData;
        private Button BtnStart;
        private Button BtnStop;
        private Panel PanelRun;
        private ComboBox ComboBoxMethod;
    }
}
