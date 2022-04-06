using System.Diagnostics;
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
            CheckForUpdates();
        }

        #region Event Handlers

        private void tcpGeckoConnectButton_Click(object sender, System.EventArgs e) => ConnectToWiiU();
        private void tcpGeckoDisconnectButton_Click(object sender, System.EventArgs e) => DisconnectFromWiiU();

        private void brighterInkButton_Click(object sender, System.EventArgs e) => SendCode(0x106D37A8, 0x3F100000, true);
        private void swimInInkEverywhereButton_Click(object sender, System.EventArgs e) 
        {
            SendCode(0x30000000, 0x106E46E8, true);
            SendCode(0x10000000, 0x4DF9FFFE);
            SendCode(0x0012088C, 43000000);
            SendCode(0xD0000000, 0xDEADCAFE);
            SendCode(0xD0000000, 0xDEADCAFE);
        }

        #endregion

        #region Methods

        private async void CheckForUpdates()
        {
            UpdateHandler.UpdateStatus updateStatus = UpdateHandler.UpdateStatus.CheckFailed;
            Root root = new Root();

            await Task.Run(() => 
            {
                updateStatus = UpdateHandler.CheckForUpdates(out root);
            });

            switch (updateStatus)
            {
                case UpdateHandler.UpdateStatus.CheckFailed:
                    Utilities.MessageBox.ShowErrorMessage("Failed to check for updates! Please try again later.");
                    break;
                case UpdateHandler.UpdateStatus.NoUpdatesAvailable:
                    Utilities.MessageBox.ShowInformationMessage("You're running the latest version!");
                    break;
                case UpdateHandler.UpdateStatus.UpdatesAvailable:
                    DialogResult dialogResult = MessageBox.Show("The v" + root.latestversion.ToString("0.0") + " update is available!\n\nChangelog:\n" + root.changelog + "\n\nWould you like to download the update?", "Update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes) Process.Start(root.latestversiondownloadlink);
                    break;
            }

            if (!string.IsNullOrEmpty(root.notice)) Utilities.MessageBox.ShowInformationMessage("Notice: " + root.notice);
        }

        private void ConnectToWiiU()
        {
            if (string.IsNullOrEmpty(wiiUIpAddressTextBox.Text))
            {
                Utilities.MessageBox.ShowErrorMessage("Please enter a valid IP address.");
                return;
            }

            if (tcpGecko == null) tcpGecko = new TCPGecko(wiiUIpAddressTextBox.Text, 7331);

            try
            {
                tcpGecko.Connect();
            }
            catch (ETCPGeckoException)
            {
                Utilities.MessageBox.ShowErrorMessage("Could not find TCPGecko running on the Wii U.");
                return;
            }
            catch (System.Net.Sockets.SocketException)
            {
                Utilities.MessageBox.ShowErrorMessage("Invalid Wii U IP address.");
                return;
            }
            catch
            {
                return;
            }

            EnableConnectedControls();
        }

        private void DisconnectFromWiiU()
        {
            try { tcpGecko.Disconnect(); }
            catch { return; }

            DisableConnectedControls();
        }

        private void EnableConnectedControls()
        {
            tcpGeckoDisconnectButton.Enabled = true;
            tcpGeckoConnectButton.Enabled = false;
            wiiUIpAddressTextBox.Enabled = false;
            hacksTabControl.Enabled = true;
            tcpGeckoConnectionStatusLabel.ForeColor = System.Drawing.Color.Green;
            tcpGeckoConnectionStatusLabel.Text = "Connection Status: Connected to a Wii U.";
        }

        private void DisableConnectedControls()
        {
            tcpGeckoDisconnectButton.Enabled = false;
            tcpGeckoConnectButton.Enabled = true;
            wiiUIpAddressTextBox.Enabled = true;
            hacksTabControl.Enabled = false;
            tcpGeckoConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            tcpGeckoConnectionStatusLabel.Text = "Connection Status: Not connected to a Wii U.";
        }

        private void SendCode(uint address, uint value, bool sendAntiBanCodes = false)
        {
            try
            {
                tcpGecko.poke(address, value);

                if (sendAntiBanCodes)
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
            }
            catch
            {
                Utilities.MessageBox.ShowErrorMessage("Failed to send code to the Wii U!");
            }
        }

        #endregion
    }
}
