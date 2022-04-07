
namespace Splatoon_HackerMode
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tcpGeckoGroupBox = new System.Windows.Forms.GroupBox();
            this.tcpGeckoConnectionStatusLabel = new System.Windows.Forms.Label();
            this.tcpGeckoDisconnectButton = new System.Windows.Forms.Button();
            this.tcpGeckoConnectButton = new System.Windows.Forms.Button();
            this.wiiUIpAddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.hacksTabControl = new System.Windows.Forms.TabControl();
            this.safeHacksTabPage = new System.Windows.Forms.TabPage();
            this.swimInInkEverywhereButton = new System.Windows.Forms.Button();
            this.brighterInkButton = new System.Windows.Forms.Button();
            this.bannableHacksTabPage = new System.Windows.Forms.TabPage();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tcpGeckoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            this.hacksTabControl.SuspendLayout();
            this.safeHacksTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcpGeckoGroupBox
            // 
            this.tcpGeckoGroupBox.Controls.Add(this.tcpGeckoConnectionStatusLabel);
            this.tcpGeckoGroupBox.Controls.Add(this.tcpGeckoDisconnectButton);
            this.tcpGeckoGroupBox.Controls.Add(this.tcpGeckoConnectButton);
            this.tcpGeckoGroupBox.Controls.Add(this.wiiUIpAddressTextBox);
            this.tcpGeckoGroupBox.Controls.Add(this.label1);
            this.tcpGeckoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.tcpGeckoGroupBox.Name = "tcpGeckoGroupBox";
            this.tcpGeckoGroupBox.Size = new System.Drawing.Size(490, 74);
            this.tcpGeckoGroupBox.TabIndex = 0;
            this.tcpGeckoGroupBox.TabStop = false;
            this.tcpGeckoGroupBox.Text = "TCPGecko";
            // 
            // tcpGeckoConnectionStatusLabel
            // 
            this.tcpGeckoConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.tcpGeckoConnectionStatusLabel.Location = new System.Drawing.Point(34, 51);
            this.tcpGeckoConnectionStatusLabel.Name = "tcpGeckoConnectionStatusLabel";
            this.tcpGeckoConnectionStatusLabel.Size = new System.Drawing.Size(425, 13);
            this.tcpGeckoConnectionStatusLabel.TabIndex = 6;
            this.tcpGeckoConnectionStatusLabel.Text = "Connection Status: Not connected to a Wii U.";
            this.tcpGeckoConnectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcpGeckoDisconnectButton
            // 
            this.tcpGeckoDisconnectButton.Enabled = false;
            this.tcpGeckoDisconnectButton.Location = new System.Drawing.Point(384, 21);
            this.tcpGeckoDisconnectButton.Name = "tcpGeckoDisconnectButton";
            this.tcpGeckoDisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.tcpGeckoDisconnectButton.TabIndex = 3;
            this.tcpGeckoDisconnectButton.TabStop = false;
            this.tcpGeckoDisconnectButton.Text = "Disconnect";
            this.tcpGeckoDisconnectButton.UseVisualStyleBackColor = true;
            this.tcpGeckoDisconnectButton.Click += new System.EventHandler(this.tcpGeckoDisconnectButton_Click);
            // 
            // tcpGeckoConnectButton
            // 
            this.tcpGeckoConnectButton.Location = new System.Drawing.Point(303, 21);
            this.tcpGeckoConnectButton.Name = "tcpGeckoConnectButton";
            this.tcpGeckoConnectButton.Size = new System.Drawing.Size(75, 23);
            this.tcpGeckoConnectButton.TabIndex = 2;
            this.tcpGeckoConnectButton.TabStop = false;
            this.tcpGeckoConnectButton.Text = "Connect";
            this.tcpGeckoConnectButton.UseVisualStyleBackColor = true;
            this.tcpGeckoConnectButton.Click += new System.EventHandler(this.tcpGeckoConnectButton_Click);
            // 
            // wiiUIpAddressTextBox
            // 
            this.wiiUIpAddressTextBox.Location = new System.Drawing.Point(127, 23);
            this.wiiUIpAddressTextBox.Name = "wiiUIpAddressTextBox";
            this.wiiUIpAddressTextBox.Size = new System.Drawing.Size(162, 20);
            this.wiiUIpAddressTextBox.TabIndex = 1;
            this.wiiUIpAddressTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wii U IP Address:";
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPictureBox.Location = new System.Drawing.Point(0, 0);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(529, 512);
            this.backgroundPictureBox.TabIndex = 1;
            this.backgroundPictureBox.TabStop = false;
            // 
            // hacksTabControl
            // 
            this.hacksTabControl.Controls.Add(this.safeHacksTabPage);
            this.hacksTabControl.Controls.Add(this.bannableHacksTabPage);
            this.hacksTabControl.Enabled = false;
            this.hacksTabControl.Location = new System.Drawing.Point(12, 92);
            this.hacksTabControl.Name = "hacksTabControl";
            this.hacksTabControl.SelectedIndex = 0;
            this.hacksTabControl.Size = new System.Drawing.Size(505, 392);
            this.hacksTabControl.TabIndex = 2;
            this.hacksTabControl.TabStop = false;
            // 
            // safeHacksTabPage
            // 
            this.safeHacksTabPage.Controls.Add(this.swimInInkEverywhereButton);
            this.safeHacksTabPage.Controls.Add(this.brighterInkButton);
            this.safeHacksTabPage.Location = new System.Drawing.Point(4, 22);
            this.safeHacksTabPage.Name = "safeHacksTabPage";
            this.safeHacksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.safeHacksTabPage.Size = new System.Drawing.Size(497, 366);
            this.safeHacksTabPage.TabIndex = 0;
            this.safeHacksTabPage.Text = "Safe Hacks";
            this.safeHacksTabPage.UseVisualStyleBackColor = true;
            // 
            // swimInInkEverywhereButton
            // 
            this.swimInInkEverywhereButton.Location = new System.Drawing.Point(21, 57);
            this.swimInInkEverywhereButton.Name = "swimInInkEverywhereButton";
            this.swimInInkEverywhereButton.Size = new System.Drawing.Size(143, 33);
            this.swimInInkEverywhereButton.TabIndex = 1;
            this.swimInInkEverywhereButton.Text = "Swim In Ink Everywhere";
            this.swimInInkEverywhereButton.UseVisualStyleBackColor = true;
            this.swimInInkEverywhereButton.Click += new System.EventHandler(this.swimInInkEverywhereButton_Click);
            // 
            // brighterInkButton
            // 
            this.brighterInkButton.Location = new System.Drawing.Point(21, 18);
            this.brighterInkButton.Name = "brighterInkButton";
            this.brighterInkButton.Size = new System.Drawing.Size(143, 33);
            this.brighterInkButton.TabIndex = 0;
            this.brighterInkButton.Text = "Brighter Ink";
            this.brighterInkButton.UseVisualStyleBackColor = true;
            this.brighterInkButton.Click += new System.EventHandler(this.brighterInkButton_Click);
            // 
            // bannableHacksTabPage
            // 
            this.bannableHacksTabPage.Location = new System.Drawing.Point(4, 22);
            this.bannableHacksTabPage.Name = "bannableHacksTabPage";
            this.bannableHacksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.bannableHacksTabPage.Size = new System.Drawing.Size(497, 366);
            this.bannableHacksTabPage.TabIndex = 1;
            this.bannableHacksTabPage.Text = "Bannable Hacks";
            this.bannableHacksTabPage.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(12, 490);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(69, 13);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Version: v1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Caution! Some hacks may freeze your Wii U, or get you banned!";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.hacksTabControl);
            this.Controls.Add(this.tcpGeckoGroupBox);
            this.Controls.Add(this.backgroundPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splatoon HackerMode";
            this.tcpGeckoGroupBox.ResumeLayout(false);
            this.tcpGeckoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            this.hacksTabControl.ResumeLayout(false);
            this.safeHacksTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tcpGeckoGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wiiUIpAddressTextBox;
        private System.Windows.Forms.Button tcpGeckoConnectButton;
        private System.Windows.Forms.Button tcpGeckoDisconnectButton;
        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.TabControl hacksTabControl;
        private System.Windows.Forms.TabPage safeHacksTabPage;
        private System.Windows.Forms.TabPage bannableHacksTabPage;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tcpGeckoConnectionStatusLabel;
        private System.Windows.Forms.Button brighterInkButton;
        private System.Windows.Forms.Button swimInInkEverywhereButton;
    }
}

