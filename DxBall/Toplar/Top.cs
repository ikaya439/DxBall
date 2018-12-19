using DxBall.Interfaces;
using System.Windows.Forms;

namespace DxBall.Toplar
{
    abstract class Top
    {
        protected Main main = new Main();
        private Buyuyebilme buyumeOz;
        protected Nokta top = new Nokta();

        public Nokta getTop()
        {
            return this.top;
        }
        public void setTop(Nokta top)
        {
            this.top = top;
        }
        public Top(){}
        public void setForm(Main m)
        {
            this.main = m;
        }
        public void setBuyuyebilme(Buyuyebilme buyumeOz)
        {
            this.buyumeOz = buyumeOz;
        }

        public abstract void setTop();
        public void buyu(Control c, double widthMult, double heightMult)
        {
            buyumeOz.buyu(c, widthMult, heightMult);
        }
        public abstract void ciz();
        public void removeTop()
        {
            main.Controls.Remove(top);
        }
    }
}
