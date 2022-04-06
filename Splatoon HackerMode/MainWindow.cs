using System.Windows.Forms;

namespace Splatoon_HackerMode
{
    public partial class MainWindow : Form
    {
        #region Window Code

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
        }
    }
}
