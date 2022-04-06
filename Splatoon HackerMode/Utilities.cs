namespace Splatoon_HackerMode
{
    public static class Utilities
    {
        public static class MessageBox
        {
            public static void ShowInformationMessage(string message)
            {
                System.Windows.Forms.MessageBox.Show(message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }

            public static void ShowErrorMessage(string message)
            {
                System.Windows.Forms.MessageBox.Show(message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
