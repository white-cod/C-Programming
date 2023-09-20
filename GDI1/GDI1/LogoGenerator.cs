using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI1
{
    internal class LogoGenerator
    {
        public static Bitmap GenerateLogo(int width, int height)
        {
            Bitmap logo = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(logo))
            {
                g.Clear(Color.White);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLines(new Point[]
                    {
                    new Point(width / 2, 10),
                    new Point(10, height - 10),
                    new Point(width / 2, height / 2),
                    new Point(width - 10, height - 10)
                    });

                    using (Brush brush = new LinearGradientBrush(new Point(0, 0), new Point(width, height),
                                                                 Color.FromArgb(0, 122, 204), Color.FromArgb(0, 80, 133)))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
            return logo;
        }
    }
}
