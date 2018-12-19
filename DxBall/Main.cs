using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxBall
{
    public partial class Main : Form
    {
        Timer t;
        int sayac = 0;
        int tempSayac;
        int speed = 40;
        bool sagaGit = false;
        bool solaGit = false;
        bool atesEt = false;
        Oyun o;
        public Main()
        {
            InitializeComponent();

        }
        public void setOyun()
        {
            o = new Oyun();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            char c = (char)e.KeyCode;
            if (e.KeyValue == 'd' || e.KeyValue == 'D')
            {
                sagaGit = true;

            }
            if (e.KeyValue == 'a' || e.KeyValue == 'A')
            {
                solaGit = true;

            }
            if (e.KeyValue == ' ')
            {
                atesEt = true;
            }
        }

        public void Main_Load(object sender, EventArgs e)
        {

            o = new Oyun();
            o.setForm(this);
            o.yukle();
            o.basla();
            t = new Timer();
            t.Interval = 1;
            t.Tick += new EventHandler(timer_tick);
            t.Start();
            tempSayac = speed;
            timer1.Start();

        }
        private char klavyedenDegerOku()
        {
            throw new NotImplementedException();

        }
        public void timer_tick(object sender, EventArgs e)
        {
            sayac++;
        }



        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (sagaGit)
            {
                o.cubukHareket('d');
            }
            else if (solaGit)
            {
                o.cubukHareket('a');
            }
            else if (atesEt)
            {
                if (sayac >= tempSayac)
                {
                    sayac = tempSayac;
                    tempSayac += speed;
                    sayac++;
                    o.cubukHareket(' ');
                }
            }
            if (o.yanma() || o.oyunBittiKontrol())
            {
                sagaGit = false;
                solaGit = false;
                t.Stop();
                timer1.Stop();
                string durum = "Tekrar başlamak için eveti çıkmak için hayır seçin";
                DialogResult dialogResult = MessageBox.Show(durum, "Uyarı", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Main_Load(sender, e);
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }


            }
            if (o.oyunBittiKontrol())
            {
                t.Stop();
                timer1.Stop();
                Main_Load(sender, e);
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'd' || e.KeyValue == 'D')
            {
                sagaGit = false;
            }
            if (e.KeyValue == 'a' || e.KeyValue == 'A')
            {
                solaGit = false;
            }
            if (e.KeyValue == ' ')
            {
                atesEt = false;
            }
        }
    }
}
