
namespace Coin.Mobile.Utilities
{
    public class PathDB
    {
        public static string GetPath(string nameDb)
        {
            string path = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = Path.Combine(path, nameDb);
            }
            else if(DeviceInfo.Platform == DevicePlatform.iOS)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = Path.Combine(path,"..","Library", nameDb);
            }

            return path;
        }
    }
}
