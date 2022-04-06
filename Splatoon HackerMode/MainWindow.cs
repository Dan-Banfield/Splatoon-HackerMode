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

        private bool wiiUConnected = false;

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

        #endregion

        #region Methods

        public async void CheckForUpdates()
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

        public void ConnectToWiiU()
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
            }
            catch (System.Net.Sockets.SocketException)
            {
                Utilities.MessageBox.ShowErrorMessage("Invalid Wii U IP address.");
            }
        }

        private void connectedTimer_Tick(object sender, System.EventArgs e)
        {
            wiiUConnected = tcpGecko.status() == WiiStatus.Running;

            switch (wiiUConnected)
            {
                case true:
                    tcpGeckoConnectionStatusLabel.Text = "Connection Status: Connected to a Wii U.";
                    tcpGeckoConnectionStatusLabel.ForeColor = System.Drawing.Color.Green;
                    break;
                case false:
                    tcpGeckoConnectionStatusLabel.Text = "Connection Status: Not connected to a Wii U.";
                    tcpGeckoConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
                    break;
            }
        }

        #endregion
    }
}
