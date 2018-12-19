using System.Drawing;
using System.Windows.Forms;

namespace DxBall
{
    class DenemeClass
    {
      protected  Main m = new Main();

        public void set(Form t)
        {
            m = (Main)t;
        }
        public void dene()
        {
            m.Controls.Add(new TextBox());
            TextBox t = new TextBox();
            t.Location = new Point(400, 400);
            m.Controls.Add(t);
          //  m.Controls.Remove(t);
        }
    }
}
