using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPGeckoSharp;

namespace Splatoon_HackerMode
{
    public partial class MainWindow : Form
    {
        #region Properties

        private TCPGecko tcpGecko;

        #endregion

        #region Form Code

        // Enable double buffering for the entire form (including controls).
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InitializeForm();

            CheckForUpdates();
        }

        #region Event Handlers

        #region Buttons

        private void tcpGeckoConnectButton_Click(object sender, System.EventArgs e) => ConnectToWiiU();
        private void tcpGeckoDisconnectButton_Click(object sender, System.EventArgs e) => DisconnectFromWiiU();

        private void brighterInkButton_Click(object sender, System.EventArgs e) => SendCode(0x106D37A8, 0x3F100000, true, true);
        private void swimInInkEverywhereButton_Click(object sender, System.EventArgs e) 
        {
            SendCode(0x30000000, 0x106E46E8, true, true);
            SendCode(0x10000000, 0x4DF9FFFE);
            SendCode(0x0012088C, 43000000);
            SendCode(0xD0000000, 0xDEADCAFE);
            SendCode(0xD0000000, 0xDEADCAFE);
        }
        private void moonJumpButton_Click(object sender, System.EventArgs e)
        {
            SendCode(0x30000000, 0x106E46E8, true, true);
            SendCode(0x1D000000, 0x29000000);
            SendCode(0x31000000, 0x00000000);
            SendCode(0x001205C8, 0x00000000);
            SendCode(0x001205D8, 0x00000000);
            SendCode(0xD0000000, 0xDEADCAFE);
        }

        #endregion

        #endregion

        #region Methods

        private void InitializeForm()
        {
            UpdateVersionLabel();
        }

        private async void CheckForUpdates()
        {
            UpdateHandler.UpdateStatus updateStatus = UpdateHandler.UpdateStatus.CheckFailed;
            Root root = new Root();

            await Task.Run(() => 
            {
                updateStatus = UpdateHandler.CheckForUpdates(out root);
            });

            ShowUpdateStatus(updateStatus, root);
        }

        private void ShowUpdateStatus(UpdateHandler.UpdateStatus updateStatus, Root root)
        {
            switch (updateStatus)
            {
                case UpdateHandler.UpdateStatus.CheckFailed:
                    Utilities.MessageBox.ShowErrorMessage("Failed to check for updates! Please try again later.");
                    break;
                case UpdateHandler.UpdateStatus.NoUpdatesAvailable:
                    versionLabel.Text += " - Up To Date!";
                    break;
                case UpdateHandler.UpdateStatus.UpdatesAvailable:
                    DialogResult dialogResult = MessageBox.Show("The v" + root.latestversion.ToString("0.0") + " update is available!\n\nChangelog:\n" + root.changelog + "\n\nWould you like to download the update?", "Update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes) Process.Start(root.latestversiondownloadlink);
                    break;
            }

            ShowNotice(root);
        }

        private void ShowNotice(Root root)
        {
            if (!string.IsNullOrEmpty(root.notice)) Utilities.MessageBox.ShowInformationMessage("Notice: " + root.notice);
        }

        private void UpdateVersionLabel()
        {
            versionLabel.Text += " v" + UpdateHandler.currentVersion.ToString("0.0");
        }

        private void ConnectToWiiU()
        {
            if (!ValidWiiUIP(wiiUIpAddressTextBox.Text)) { Utilities.MessageBox.ShowErrorMessage("Please enter an IP address first."); return; }

            if (tcpGecko == null) tcpGecko = new TCPGecko(wiiUIpAddressTextBox.Text, 7331);

            if (AttemptWiiUConnection())
            {
                EnableConnectedControls();
            }
        }

        private bool ValidWiiUIP(string ipAddress)
        {
            return (!string.IsNullOrEmpty(ipAddress));
        }

        private bool AttemptWiiUConnection()
        {
            try
            {
                tcpGecko.Connect();
                return true;
            }
            catch (ETCPGeckoException)
            {
                Utilities.MessageBox.ShowErrorMessage("Could not find TCPGecko running on the Wii U.");
                return false;
            }
            catch (System.Net.Sockets.SocketException)
            {
                Utilities.MessageBox.ShowErrorMessage("Invalid Wii U IP address.");
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void DisconnectFromWiiU()
        {
            try { tcpGecko.Disconnect(); }
            catch { return; }

            DisableConnectedControls();
        }

        private void EnableConnectedControls()
        {
            #region Big Code Stack

            tcpGeckoDisconnectButton.Enabled = true;
            tcpGeckoConnectButton.Enabled = false;
            wiiUIpAddressTextBox.Enabled = false;
            hacksTabControl.Enabled = true;
            tcpGeckoConnectionStatusLabel.ForeColor = Color.Green;
            tcpGeckoConnectionStatusLabel.Text = "Connection Status: Connected to a Wii U.";
            wiiUIpAddressTextBox.BackColor = Color.Green;

            #endregion
        }

        private void DisableConnectedControls()
        {
            #region Big Code Stack

            tcpGeckoDisconnectButton.Enabled = false;
            tcpGeckoConnectButton.Enabled = true;
            wiiUIpAddressTextBox.Enabled = true;
            hacksTabControl.Enabled = false;
            tcpGeckoConnectionStatusLabel.ForeColor = Color.Red;
            tcpGeckoConnectionStatusLabel.Text = "Connection Status: Not connected to a Wii U.";
            wiiUIpAddressTextBox.BackColor = Color.Red;

            #endregion
        }

        private void SendCode(uint address, uint value, bool sendAntiBanCodes = false, bool showNotifications = false)
        {
            try
            {
                if (sendAntiBanCodes)
                {
                    SendAntiBanCodes();
                }

                tcpGecko.poke(address, value);

                if (showNotifications) Utilities.MessageBox.ShowInformationMessage("Code sent successfully!");
            }
            catch
            {
                if (showNotifications) Utilities.MessageBox.ShowErrorMessage("Failed to send code to the Wii U!");
            }
        }

        private void SendAntiBanCodes()
        {
            SendCode(0x30000000, 0x106E46E8);
            SendCode(0x19000000, 0x29000000);
            SendCode(0x00120058, 0x00000000);
            SendCode(0x31000000, 0x00001184);
            SendCode(0x00120058, 0x00000000);
            SendCode(0x31000000, 0x00001184);
            SendCode(0x00120058, 0x00000000);
            SendCode(0x31000000, 0x00001184);
            SendCode(0x00120058, 0x00000000);
            SendCode(0x31000000, 0x00001184);
            SendCode(0x00120058, 0x00000000);
            SendCode(0x31000000, 0x00001184);
            SendCode(0x00120058, 0x00000000);
            SendCode(0xD0000000, 0xDEADCAFE);
        }

        #endregion
    }
}
