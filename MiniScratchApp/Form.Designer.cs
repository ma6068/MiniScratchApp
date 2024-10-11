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
            TextBoxMessageBody = new TextBox();
            TextBoxIncomingRequests = new TextBox();
            BtnSave = new Button();
            BtnStart = new Button();
            BtnStop = new Button();
            SuspendLayout();
            // 
            // TxtBoxInboundAddress
            // 
            TxtBoxInboundAddress.Location = new Point(108, 76);
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
            TxtBoxInboundPort.Location = new Point(281, 76);
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
            TxtBoxOutboundAddress.Location = new Point(108, 150);
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
            TxtBoxOutboundPort.Location = new Point(281, 150);
            TxtBoxOutboundPort.Name = "TxtBoxOutboundPort";
            TxtBoxOutboundPort.PlaceholderText = "Outbound Port";
            TxtBoxOutboundPort.Size = new Size(148, 27);
            TxtBoxOutboundPort.TabIndex = 3;
            TxtBoxOutboundPort.MouseDown += TxtBox_MouseDown;
            TxtBoxOutboundPort.MouseMove += TxtBox_MouseMove;
            TxtBoxOutboundPort.MouseUp += TxtBox_MouseUp;
            // 
            // TextBoxMessageBody
            // 
            TextBoxMessageBody.Location = new Point(616, 76);
            TextBoxMessageBody.Name = "TextBoxMessageBody";
            TextBoxMessageBody.PlaceholderText = "Sending message";
            TextBoxMessageBody.Size = new Size(142, 27);
            TextBoxMessageBody.TabIndex = 4;
            TextBoxMessageBody.MouseDown += TxtBox_MouseDown;
            TextBoxMessageBody.MouseMove += TxtBox_MouseMove;
            TextBoxMessageBody.MouseUp += TxtBox_MouseUp;
            // 
            // TextBoxIncomingRequests
            // 
            TextBoxIncomingRequests.Location = new Point(616, 150);
            TextBoxIncomingRequests.Multiline = true;
            TextBoxIncomingRequests.Name = "TextBoxIncomingRequests";
            TextBoxIncomingRequests.PlaceholderText = "Incoming requests";
            TextBoxIncomingRequests.Size = new Size(142, 27);
            TextBoxIncomingRequests.TabIndex = 5;
            TextBoxIncomingRequests.MouseDown += TxtBox_MouseDown;
            TextBoxIncomingRequests.MouseMove += TxtBox_MouseMove;
            TextBoxIncomingRequests.MouseUp += TxtBox_MouseUp;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(209, 308);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(94, 29);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(430, 308);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(94, 29);
            BtnStart.TabIndex = 7;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(616, 308);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(94, 29);
            BtnStop.TabIndex = 8;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStopClick;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 528);
            Controls.Add(BtnSave);
            Controls.Add(BtnStop);
            Controls.Add(BtnStart);
            Controls.Add(TextBoxIncomingRequests);
            Controls.Add(TextBoxMessageBody);
            Controls.Add(TxtBoxOutboundPort);
            Controls.Add(TxtBoxOutboundAddress);
            Controls.Add(TxtBoxInboundPort);
            Controls.Add(TxtBoxInboundAddress);
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
        private TextBox TextBoxMessageBody;
        private TextBox TextBoxIncomingRequests;
        private Button BtnSave;
        private Button BtnStart;
        private Button BtnStop;
    }
}
