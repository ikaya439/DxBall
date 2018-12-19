using DxBall.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DxBall.Cubuklar
{
    abstract class Cubuk : Panel, AtesEdebilme, Buyuyebilme
    {
        protected Main main = new Main();
        Form form = new Form();
        protected Panel cubuk = new Panel();
        protected Buyuyebilme buyumeOz;
        protected AtesEdebilme atesEtmeOz;
        protected List<Nokta> mermiler = new List<Nokta>();
        private int cubukHareketHızı = 5;
        public List<Nokta> Mermiler
        {
            get
            {
                return mermiler;
            }

            set
            {
                mermiler = value;
            }
        }

        public int CubukHareketHızı
        {
            get
            {
                return cubukHareketHızı;
            }

            set
            {
                cubukHareketHızı = value;
            }
        }

        public Cubuk()
        {

        }
        public void setForm(Main m)
        {
            this.main = m;
        }

        public void setbuyumeOz(Buyuyebilme buyu)
        {
            this.buyumeOz = buyu;
        }
        public void setAtesEtmeOz(AtesEdebilme ates)
        {
            this.atesEtmeOz = ates;
        }
        public AtesEdebilme getAtesEtmeOz()
        {
            return atesEtmeOz;
        }
        public abstract void ciz();
        public Panel getCubuk()
        {
            return cubuk;
        }

        public void buyu(Control c, double widthMult, double heightMult)
        {
            buyumeOz.buyu(cubuk, widthMult, heightMult);
        }
        public void atesEt(Control c, List<Nokta> mermiler)
        {
            atesEtmeOz.atesEt(cubuk, this.Mermiler);
        }

        public void setForm(Form f)
        {

        }
        public void sagaGit()
        {
            cubuk.Location = new Point(cubuk.Location.X + cubukHareketHızı, cubuk.Location.Y);
        }
        public void solaGit()
        {
            cubuk.Location = new Point(cubuk.Location.X - cubukHareketHızı, cubuk.Location.Y);
        }
        public void removeCubuk()
        {
            main.Controls.Remove(cubuk);    
        }

    }
}
