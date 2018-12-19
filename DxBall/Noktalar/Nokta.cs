using System.Windows.Forms;

namespace DxBall
{
    class Nokta : Panel
    {
        protected string durumu;
        protected bool silinebilirlik;
        protected bool gecirgenlik;
        protected int puan;
        public Nokta()
        {
            
        }

        public string Durumu
        {
            get
            {
                return durumu;
            }

            set
            {
                durumu = value;
            }
        }

        public bool Silinebilirlik
        {
            get
            {
                return silinebilirlik;
            }

            set
            {
                silinebilirlik = value;
            }
        }

        public bool Gecirgenlik
        {
            get
            {
                return gecirgenlik;
            }

            set
            {
                gecirgenlik = value;
            }
        }

        public int Puan
        {
            get
            {
                return puan;
            }

            set
            {
                puan = value;
            }
        }
    }
}
