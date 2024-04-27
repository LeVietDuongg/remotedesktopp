namespace Bai01
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSend = new Button();
            txbIP = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txbPort = new TextBox();
            label3 = new Label();
            txbMessage = new TextBox();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(68, 360);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(102, 40);
            btnSend.TabIndex = 8;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txbIP
            // 
            txbIP.Location = new Point(68, 73);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(334, 31);
            txbIP.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 117);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 6;
            label2.Text = "Messages";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 44);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 5;
            label1.Text = "IP Remote host ";
            // 
            // txbPort
            // 
            txbPort.Location = new Point(559, 73);
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(174, 31);
            txbPort.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(559, 44);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 10;
            label3.Text = "Port:";
            // 
            // txbMessage
            // 
            txbMessage.Location = new Point(68, 159);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(665, 181);
            txbMessage.TabIndex = 12;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 427);
            Controls.Add(txbMessage);
            Controls.Add(txbPort);
            Controls.Add(label3);
            Controls.Add(btnSend);
            Controls.Add(txbIP);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSend;
        private TextBox txbIP;
        private Label label2;
        private Label label1;
        private TextBox txbPort;
        private Label label3;
        private TextBox txbMessage;
    }
}