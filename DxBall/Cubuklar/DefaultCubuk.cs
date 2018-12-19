using DxBall.Interfaces.Ates;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxBall.Cubuklar
{
    class DefaultCubuk : Cubuk
    {
        public DefaultCubuk()
        {
            cubuk.Size = new Size(80, 20);
            cubuk.Location = new Point(350, 400);
            cubuk.BackColor = Color.Red;
            atesEtmeOz = new AtesEtme();
            cubuk.BackgroundImage = Image.FromFile("Stick.jpg");
            cubuk.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public override void ciz()
        {
            Console.WriteLine("Cubuk Cizildi");
            main.Controls.Add(cubuk);
        }
    }
}
