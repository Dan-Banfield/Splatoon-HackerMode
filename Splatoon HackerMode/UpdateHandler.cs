using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Splatoon_HackerMode
{
    public static class UpdateHandler
    {
        public enum UpdateStatus
        {
            CheckFailed,
            UpdatesAvailable,
            NoUpdatesAvailable
        }

        public const float currentVersion = 1.0f;

        private const string jsonUpdateEndPoint = "https://raw.githubusercontent.com/Dan-Banfield/Json-Update-Files/main/SplatoonHackerMode.json";

        public static UpdateStatus CheckForUpdates(out Root root)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(jsonUpdateEndPoint);
                WebResponse webResponse = webRequest.GetResponse();

                string json = "";

                using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    json = streamReader.ReadToEnd();
                }

                root = JsonConvert.DeserializeObject<Root>(json);

                if (root.latestversion > currentVersion) return UpdateStatus.UpdatesAvailable;
                if (root.latestversion < currentVersion) return UpdateStatus.UpdatesAvailable;
                if (root.latestversion == currentVersion) return UpdateStatus.NoUpdatesAvailable;
            }
            catch
            {
                root = new Root();
                return UpdateStatus.CheckFailed;
            }

            root = new Root();
            return UpdateStatus.CheckFailed;
        }
    }
}
