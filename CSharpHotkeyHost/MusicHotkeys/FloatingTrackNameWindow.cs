using MrSmarty.CodeProject;
using System.Drawing;
using System.Windows.Forms;

namespace MusicHotkeys
{
    class FloatingTrackNameWindow : FloatingOSDWindow
    {
        private Brush bgBrush = new SolidBrush(Color.FromArgb(127, 0, 0, 0));

        public void Show(string trackName)
        {
            base.Show(Point.Empty, 255, Program.FileConfig.NameColor, Program.FileConfig.NameFont, 1500, AnimateMode.SlideTopToBottom, 500, trackName);
        }

        protected override void PerformPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle(bgBrush, Bound);
            base.PerformPaint(e);
        }
    }
}
