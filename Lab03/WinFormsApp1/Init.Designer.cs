namespace WinFormsApp1
{
    partial class Init
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
            btnServer = new Button();
            btnClient = new Button();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.Location = new Point(72, 75);
            btnServer.Name = "btnServer";
            btnServer.Size = new Size(186, 46);
            btnServer.TabIndex = 0;
            btnServer.Text = "Open UDP Server";
            btnServer.UseVisualStyleBackColor = true;
            btnServer.Click += btnServer_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(324, 75);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(186, 46);
            btnClient.TabIndex = 1;
            btnClient.Text = "Open UDP Client";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // Init
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 290);
            Controls.Add(btnClient);
            Controls.Add(btnServer);
            Name = "Init";
            Text = "Dashboard";
            ResumeLayout(false);
        }

        #endregion

        private Button btnServer;
        private Button btnClient;
    }
}
