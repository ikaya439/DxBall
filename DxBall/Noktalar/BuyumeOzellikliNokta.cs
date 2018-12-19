using System.Drawing;

namespace DxBall.Noktalar
{
    class BuyumeOzellikliNokta : Nokta
    {
        int dusmeOlasilik;
        public BuyumeOzellikliNokta()
        {
            Size = new Size(20, 20);
            BackColor = Color.Purple;
            silinebilirlik = false;
            durumu = "Buyu";
            puan = 40;
            DusmeOlasilik = 30;
            BackgroundImage = Image.FromFile("purpleBrick.jpg");
        }

        public int DusmeOlasilik
        {
            get
            {
                return dusmeOlasilik;
            }

            set
            {
                dusmeOlasilik = value;
            }
        }
    }
}
