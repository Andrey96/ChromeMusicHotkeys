using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusicHotkeys
{
    class Config
    {
        public bool EnableHotkeys = true, EnableName = true;
        public Font NameFont = new Font(SystemFonts.DefaultFont.FontFamily, 14);
        public Color NameColor = Color.White;
        public readonly string FileName;

        public Config(string fileName)
        {
            FileName = fileName;
        }

        public void Load()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    string[] cfg = File.ReadAllLines(FileName);
                    EnableHotkeys = bool.Parse(cfg[0]);
                    EnableName = bool.Parse(cfg[1]);
                    FontFamily ff = new FontFamily(cfg[2]);
                    float size = float.Parse(cfg[3]);
                    NameFont = new Font(ff, size, (bool.Parse(cfg[4]) ? FontStyle.Bold : FontStyle.Regular) |
                                                  (bool.Parse(cfg[5]) ? FontStyle.Italic : FontStyle.Regular) |
                                                  (bool.Parse(cfg[6]) ? FontStyle.Underline : FontStyle.Regular) |
                                                  (bool.Parse(cfg[7]) ? FontStyle.Strikeout : FontStyle.Regular));
                    NameColor = Color.FromArgb(int.Parse(cfg[8]));
                }
                catch
                {
                    MessageBox.Show("Конфиг поврежден и будет удален.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete(FileName);
                }
            }
        }

        public void Save()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
            File.WriteAllLines(FileName, new string[]{
                EnableHotkeys.ToString(),
                EnableName.ToString(),
                NameFont.FontFamily.Name,
                NameFont.Size.ToString(),
                NameFont.Bold.ToString(),
                NameFont.Italic.ToString(),
                NameFont.Underline.ToString(),
                NameFont.Strikeout.ToString(),
                NameColor.ToArgb().ToString()
            });
        }
    }
}
