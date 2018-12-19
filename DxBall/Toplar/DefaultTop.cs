using System.Drawing;
using System.Windows.Forms;

namespace DxBall.Toplar
{
    class DefaultTop : Top
    {
        public DefaultTop()
        {
            top.Size = new Size(20, 20);
            top.BackColor = Color.Red;
            top.Location = new Point(400, 300);
            top.BackgroundImage = Image.FromFile("newBall.jpg");
            top.BackgroundImageLayout = ImageLayout.Stretch;

        }

        public override void setTop()
        {
        }

        public override void ciz()
        {
                main.Controls.Add(top);
        }
    }
}
