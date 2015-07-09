using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Windows.Forms;

namespace MusicHotkeys
{
    public partial class MainForm : Form
    {
        private NativeMessaging native;
        private FloatingTrackNameWindow trackNameWindow = new FloatingTrackNameWindow();
        private bool InitHide = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InstallRegistry()
        {
            string key = @"HKEY_CURRENT_USER\Software\Google\Chrome\NativeMessagingHosts\ru.andrey96.music_hotkeys";
            string val = Path.GetFullPath("ru.andrey96.music_hotkeys.json");
            Registry.SetValue(key, "", val);
            Registry.SetValue(key, "dir", Path.GetDirectoryName(val));
        }

        private string GetCfgPath()
        {
            return (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Google\Chrome\NativeMessagingHosts\ru.andrey96.music_hotkeys", "dir", "");
        }

        private void KillExtraProcesses()
        {
            int curPId = Process.GetCurrentProcess().Id;
            foreach (Process p in Process.GetProcessesByName("MusicHotkeys"))
            {
                if (p.Id != curPId)
                    p.Kill();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("ru.andrey96.music_hotkeys.json"))
            {
                InstallRegistry();
                MessageBox.Show("Программа установлена в текущей папке.\nЕсли есть необходимость её переместить, запустите её в новой директории.\nПрограмма будет запускаться сама по сигналу расширения Chrome.");
                Environment.Exit(0);
            }
            KillExtraProcesses();
            Program.FileConfig = new Config(GetCfgPath()+@"\MusicHotkeys.cfg");
            Program.FileConfig.Load();
            cbHotkeys.Checked = Program.FileConfig.EnableHotkeys;
            cbName.Checked = Program.FileConfig.EnableName;
            native = new NativeMessaging();
            KeyboardHook hook = new KeyboardHook();
            hook.KeyPressed += hook_KeyPressed;
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.None, Keys.MediaPlayPause);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.Control, Keys.MediaPlayPause);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.Shift, Keys.MediaPlayPause);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.None, Keys.MediaNextTrack);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.Control, Keys.MediaNextTrack);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.Shift, Keys.MediaNextTrack);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.None, Keys.MediaPreviousTrack);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.Control, Keys.MediaPreviousTrack);
            hook.RegisterHotKey(MusicHotkeys.ModifierKeys.Shift, Keys.MediaPreviousTrack);
            Timer tm = new Timer();
            tm.Interval = 250;
            tm.Tick += tm_Tick;
            tm.Start();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.MediaPlayPause:
                    native.PressedKey = "play";
                    break;
                case Keys.MediaNextTrack:
                    native.PressedKey = "next";
                    break;
                case Keys.MediaPreviousTrack:
                    native.PressedKey = "prev";
                    break;
            }
        }

        void tm_Tick(object sender, EventArgs e)
        {
            if (InitHide)
            {
                InitHide = false;
                HideSettings();
            }
            if (native.TrackName != null)
            {
                string track = native.TrackName;
                native.TrackName = null;
                if (Program.FileConfig.EnableName)
                    try { trackNameWindow.Show(HttpUtility.UrlDecode(HttpUtility.HtmlDecode(track))); } catch { }
            }
        }

        private void ShowSettings()
        {
            Show();
            notifyIcon.Visible = false;
            Focus();
        }

        private void HideSettings()
        {
            Hide();
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1500, "Окно свернуто", "Тут можно развернуть окно настроек еще раз, либо закрыть программу.", ToolTipIcon.Info);
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            HideSettings();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideSettings();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowSettings();
        }

        private void itemOpenSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void cbHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            Program.FileConfig.EnableHotkeys = cbHotkeys.Checked;
            Program.FileConfig.Save();
        }

        private void cbName_CheckedChanged(object sender, EventArgs e)
        {
            Program.FileConfig.EnableName = cbName.Checked;
            Program.FileConfig.Save();
        }

        private void btFont_Click(object sender, EventArgs e)
        {
            FontDialog diag = new FontDialog();
            diag.FontMustExist = true;
            diag.ShowColor = true;
            diag.ShowHelp = false;
            diag.Font = Program.FileConfig.NameFont;
            diag.Color = Program.FileConfig.NameColor;
            if(diag.ShowDialog() == DialogResult.OK)
            {
                Program.FileConfig.NameFont = diag.Font;
                Program.FileConfig.NameColor = diag.Color;
                Program.FileConfig.Save();
            }
        }

        private void itemExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Environment.Exit(0);
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowSettings();
        }

    }
}
