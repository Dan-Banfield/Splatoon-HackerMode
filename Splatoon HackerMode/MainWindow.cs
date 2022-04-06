using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splatoon_HackerMode
{
    public partial class MainWindow : Form
    {
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
                    DialogResult dialogResult = MessageBox.Show("The v" + root.latestversion.ToString("0:0") + " update is available!\n\nChangelog:\n" + root.changelog + "\n\nWould you like to download the update?", "Update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes) Process.Start(root.latestversiondownloadlink);
                    break;
            }

            if (!string.IsNullOrEmpty(root.notice)) Utilities.MessageBox.ShowInformationMessage("Notice: " + root.notice);
        }
    }
}
