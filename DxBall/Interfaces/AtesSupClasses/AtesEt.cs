using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxBall.Interfaces.Ates
{
    class AtesEt : AtesEdebilme
    {
        Main main;
        Nokta n = new DefaultNokta();
        Nokta n1 = new DefaultNokta();
        private int ozellikSure = 1000;//milisaniye
        private int atesZamani;

        public int AtesZamani
        {
            get
            {
                return atesZamani;
            }

            set
            {
                atesZamani = value;
            }
        }

        public int OzellikSure
        {
            get
            {
                return ozellikSure;
            }

            set
            {
                ozellikSure = value;
            }
        }

        public AtesEt()
        {
            main = new Main();
        }
        public void atesEt(Control c, List<Nokta> mermiler)
        {
            n = new DefaultNokta();
            n.Size = new System.Drawing.Size(5, 15);
            n.Location = new System.Drawing.Point(c.Location.X, c.Location.Y - 20);
            n1 = new DefaultNokta();
            n1.Size = new System.Drawing.Size(5, 15);
            n1.Location = new System.Drawing.Point(c.Location.X + c.Size.Width, c.Location.Y - 20);
            mermiler.Add(n);
            mermiler.Add(n1);
            main.Controls.Add(n);
            main.Controls.Add(n1);
        }
        public void setForm(Form f)
        {
            this.main = (Main)f;
        }
    }
}
