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

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "SPTNPP";
        static settingsDlg frmMyDlg = null;
        static int idMyDlg = -1;
        static Icon tbIcon = null;
        static NotepadPPGateway gateway = new NotepadPPGateway();

        public static void OnNotification(ScNotification notification)
        {  
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
        }

        internal static void CommandMenuInit()
        {
            Config.InitConfig();
            PluginBase.SetCommand(0, "Change settings...", settingsDialog); idMyDlg = 1;
            PluginBase.SetCommand(1, "Load script", LoadScript, new ShortcutKey(false, true, false, Keys.L));
            PluginBase.SetCommand(2, "Custom command", CustomCommand, new ShortcutKey(false, true, false, Keys.G));
        }

        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        public static string GetRelativePath(string relativeTo, string path)
        {
            var uri = new Uri(relativeTo);
            var rel = Uri.UnescapeDataString(uri.MakeRelativeUri(new Uri(path)).ToString()).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            if (rel.Contains(Path.DirectorySeparatorChar.ToString()) == false)
            {
                rel = $".{ Path.DirectorySeparatorChar }{ rel }";
            }
            return rel;
        }

        internal static void LoadScript()
		{
			try
			{
                using (var socketClient = new SocketClient(Config.AppConfig.Port))
                {
                    socketClient.SendCommand("y_spt_ipc_gamedir");
                    var response = socketClient.GetMessage();

                    if (!response.ContainsKey("path"))
                    {
                        throw new Exception("SPT did not respond with game dir.\n");
                    }

                    var relPath = GetRelativePath(response["path"] + "\\", gateway.GetCurrentFilePath());
                    relPath = Path.ChangeExtension(relPath, null);
                    relPath = relPath.Replace("\\", "/");
                    string scriptCmd;

                    if (Config.AppConfig.ResumeTick > 0)
                        scriptCmd = string.Format("tas_script_load {0} {1}", relPath, Config.AppConfig.ResumeTick);
                    else
                        scriptCmd = string.Format("tas_script_load {0}", relPath);

                    socketClient.SendCommand(scriptCmd);
                }
            }
            catch(Exception e)
			{
                MessageBox.Show(string.Format("Error: {0}", e));
			}

        }

        internal static void CustomCommand()
		{
            try
			{
                using (var socketClient = new SocketClient(Config.AppConfig.Port))
                {
                    socketClient.SendCommand(Config.AppConfig.CustomCommand);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error: {0}", e));
            }
        }

        internal static void PluginCleanUp()
        {
            Config.Save();
        }

        internal static void settingsDialog()
        {
            if (frmMyDlg == null)
            {
                frmMyDlg = new settingsDlg();

                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmMyDlg.Handle;
                _nppTbData.pszName = "SPTNPP Settings";
                _nppTbData.dlgID = idMyDlg;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_DMMSHOW, 0, frmMyDlg.Handle);
            }
        }
    }
}