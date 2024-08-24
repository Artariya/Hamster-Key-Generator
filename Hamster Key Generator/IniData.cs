using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
namespace Hamster_Key_Generator
{
    class IniData
    {
        private static readonly string iniFilePath = "settings.ini";

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static long WriteData(string section, string key, string data)
        {
            return WritePrivateProfileString(section, key, data, Application.StartupPath + $@"\{iniFilePath}");
        }
        public static string ReadData(string section, string key, string defaultValue = null)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, defaultValue, temp, 255, Application.StartupPath + $@"\{iniFilePath}");
            return temp.ToString();
        }
    }
}
