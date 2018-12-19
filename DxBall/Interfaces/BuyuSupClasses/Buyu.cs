using DxBall.Cubuklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxBall.Interfaces
{
    class Buyu : Buyuyebilme
    {
        public void buyu(Control c, double widthMult, double heightMult)
        {
            int width = Convert.ToInt32(c.Size.Width * widthMult);
            int height = Convert.ToInt32(c.Size.Height * heightMult);
            c.Size = new System.Drawing.Size(width, height);
        }

    }
}
