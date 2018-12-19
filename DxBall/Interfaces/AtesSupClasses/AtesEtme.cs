using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxBall.Interfaces.Ates
{
    class AtesEtme:AtesEdebilme
    {
        private int ozellikSure = 5;
        public void atesEt(Control c, List<Nokta> mermiler)
        {
            Console.WriteLine("Ateş etmiyorum");
        }

        public void setForm(Form f)
        {
        }

    }
}
