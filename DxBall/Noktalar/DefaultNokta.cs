using System.Drawing;

namespace DxBall
{
    class DefaultNokta : Nokta
    {   
        public DefaultNokta()
        {
            Size = new Size(20, 20);
            BackColor = Color.Red;
            silinebilirlik = true;
            durumu = "Default";
            BackgroundImage = Image.FromFile("Brick.jpg");
            puan = 20;
        }
    }
}
