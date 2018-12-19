using System.Drawing;

namespace DxBall
{
    class AtesOzellikliNokta : Nokta
    {
        int dusmeOlasilik;
        public AtesOzellikliNokta()
        {
            Size = new Size(20, 20);
            BackColor = Color.Yellow;
            silinebilirlik = false;
            durumu = "Ates";
            puan = 50;
            dusmeOlasilik = 30;
            BackgroundImage = Image.FromFile("yellowBrick.jpg");


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
