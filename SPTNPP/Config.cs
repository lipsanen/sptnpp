using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using SPTNPP;

namespace SPTNPP
{

	public class Config
	{
		public static Config AppConfig = new Config();

		string iniFilePath { get; set; }
		public int Port { get; set; }
		public string CustomCommand { get; set; }
		public int ResumeTick { get; set; }

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

		private static string GetPrivateProfileString(string Section, string Key, string Default, string FilePath)
		{
			StringBuilder builder = new StringBuilder();
			GetPrivateProfileString(Section, Key, Default, builder, 4096, FilePath);
			return builder.ToString();
		}

		public static void InitConfig()
		{
			StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
			Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
			AppConfig.iniFilePath = sbIniFilePath.ToString();
			if (!Directory.Exists(AppConfig.iniFilePath)) Directory.CreateDirectory(AppConfig.iniFilePath);
			AppConfig.iniFilePath = Path.Combine(AppConfig.iniFilePath, Kbg.NppPluginNET.Main.PluginName + ".ini");
			Load();
		}

		public static void Load()
		{
			AppConfig.Port = Win32.GetPrivateProfileInt("SPT", "Port", 27182, AppConfig.iniFilePath);
			AppConfig.CustomCommand = GetPrivateProfileString("SPT", "CustomCommand", "", AppConfig.iniFilePath);
			AppConfig.ResumeTick = Win32.GetPrivateProfileInt("SPT", "ResumeTick", -1, AppConfig.iniFilePath);
		}

		public static void Save()
		{
			Win32.WritePrivateProfileString("SPT", "Port", AppConfig.Port.ToString(), AppConfig.iniFilePath);
			Win32.WritePrivateProfileString("SPT", "CustomCommand", AppConfig.CustomCommand, AppConfig.iniFilePath);
			Win32.WritePrivateProfileString("SPT", "ResumeTick", AppConfig.ResumeTick.ToString(), AppConfig.iniFilePath);
		}
	}
}
