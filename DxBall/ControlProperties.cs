using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxBall
{
    class ControlProperties
    {
        private System.Drawing.Size size;
        private Point konum = new Point();
        private Color color = new Color();
        private Image img;
       public ControlProperties()
        {
            konum = new Point(100, 100);
            color = Color.Red;
            img = null;
            size = new Size(100, 100);
        }

        public Size Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public Point Konum
        {
            get
            {
                return konum;
            }

            set
            {
                konum = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public Image Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }

        public static implicit operator ControlProperties(Control v)
        {
            throw new NotImplementedException();
        }
    }
}
