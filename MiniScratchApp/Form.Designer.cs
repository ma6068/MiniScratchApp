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
            txtBoxInboundAddress = new TextBox();
            txtBoxInboundPort = new TextBox();
            txtBoxOutboundAddress = new TextBox();
            txtBoxOutboundPort = new TextBox();
            textBoxSendingMessage = new TextBox();
            textBoxIncomingRequests = new TextBox();
            Save = new Button();
            Start = new Button();
            Stop = new Button();
            SuspendLayout();
            // 
            // txtBoxInboundAddress
            // 
            txtBoxInboundAddress.Location = new Point(108, 76);
            txtBoxInboundAddress.Name = "txtBoxInboundAddress";
            txtBoxInboundAddress.PlaceholderText = "Inbound Address";
            txtBoxInboundAddress.Size = new Size(148, 27);
            txtBoxInboundAddress.TabIndex = 0;
            txtBoxInboundAddress.MouseDown += txtBox_MouseDown;
            txtBoxInboundAddress.MouseMove += txtBox_MouseMove;
            txtBoxInboundAddress.MouseUp += txtBox_MouseUp;
            // 
            // txtBoxInboundPort
            // 
            txtBoxInboundPort.Location = new Point(281, 76);
            txtBoxInboundPort.Name = "txtBoxInboundPort";
            txtBoxInboundPort.PlaceholderText = "Inbound Port";
            txtBoxInboundPort.Size = new Size(148, 27);
            txtBoxInboundPort.TabIndex = 1;
            txtBoxInboundPort.MouseDown += txtBox_MouseDown;
            txtBoxInboundPort.MouseMove += txtBox_MouseMove;
            txtBoxInboundPort.MouseUp += txtBox_MouseUp;
            // 
            // txtBoxOutboundAddress
            // 
            txtBoxOutboundAddress.Location = new Point(108, 150);
            txtBoxOutboundAddress.Name = "txtBoxOutboundAddress";
            txtBoxOutboundAddress.PlaceholderText = "Outbound Address";
            txtBoxOutboundAddress.Size = new Size(148, 27);
            txtBoxOutboundAddress.TabIndex = 2;
            txtBoxOutboundAddress.MouseDown += txtBox_MouseDown;
            txtBoxOutboundAddress.MouseMove += txtBox_MouseMove;
            txtBoxOutboundAddress.MouseUp += txtBox_MouseUp;
            // 
            // txtBoxOutboundPort
            // 
            txtBoxOutboundPort.Location = new Point(281, 150);
            txtBoxOutboundPort.Name = "txtBoxOutboundPort";
            txtBoxOutboundPort.PlaceholderText = "Outbound Port";
            txtBoxOutboundPort.Size = new Size(148, 27);
            txtBoxOutboundPort.TabIndex = 3;
            txtBoxOutboundPort.MouseDown += txtBox_MouseDown;
            txtBoxOutboundPort.MouseMove += txtBox_MouseMove;
            txtBoxOutboundPort.MouseUp += txtBox_MouseUp;
            // 
            // textBoxSendingMessage
            // 
            textBoxSendingMessage.Location = new Point(616, 76);
            textBoxSendingMessage.Name = "textBoxSendingMessage";
            textBoxSendingMessage.PlaceholderText = "Sending message";
            textBoxSendingMessage.Size = new Size(142, 27);
            textBoxSendingMessage.TabIndex = 4;
            textBoxSendingMessage.MouseDown += txtBox_MouseDown;
            textBoxSendingMessage.MouseMove += txtBox_MouseMove;
            textBoxSendingMessage.MouseUp += txtBox_MouseUp;
            // 
            // textBoxIncomingRequests
            // 
            textBoxIncomingRequests.Location = new Point(616, 150);
            textBoxIncomingRequests.Multiline = true;
            textBoxIncomingRequests.Name = "textBoxIncomingRequests";
            textBoxIncomingRequests.PlaceholderText = "Incoming requests";
            textBoxIncomingRequests.Size = new Size(142, 27);
            textBoxIncomingRequests.TabIndex = 5;
            textBoxIncomingRequests.MouseDown += txtBox_MouseDown;
            textBoxIncomingRequests.MouseMove += txtBox_MouseMove;
            textBoxIncomingRequests.MouseUp += txtBox_MouseUp;
            // 
            // Save
            // 
            Save.Location = new Point(209, 308);
            Save.Name = "Save";
            Save.Size = new Size(94, 29);
            Save.TabIndex = 6;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            Start.Location = new Point(430, 308);
            Start.Name = "Start";
            Start.Size = new Size(94, 29);
            Start.TabIndex = 7;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            // 
            // Stop
            // 
            Stop.Location = new Point(616, 308);
            Stop.Name = "Stop";
            Stop.Size = new Size(94, 29);
            Stop.TabIndex = 8;
            Stop.Text = "Stop";
            Stop.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 528);
            Controls.Add(Save);
            Controls.Add(Stop);
            Controls.Add(Start);
            Controls.Add(textBoxIncomingRequests);
            Controls.Add(textBoxSendingMessage);
            Controls.Add(txtBoxOutboundPort);
            Controls.Add(txtBoxOutboundAddress);
            Controls.Add(txtBoxInboundPort);
            Controls.Add(txtBoxInboundAddress);
            Name = "Form";
            Text = "Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxInboundAddress;
        private TextBox txtBoxInboundPort;
        private TextBox txtBoxOutboundAddress;
        private TextBox txtBoxOutboundPort;
        private TextBox textBoxSendingMessage;
        private TextBox textBoxIncomingRequests;
        private Button Save;
        private Button Start;
        private Button Stop;
    }
}
