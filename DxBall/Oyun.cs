using DxBall.Cubuklar;
using DxBall.Interfaces;
using DxBall.Interfaces.Ates;
using DxBall.Maps;
using DxBall.Toplar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DxBall
{
    class Oyun
    {
        Main main = new Main();
        Cubuk cubuk;
        Top top;
        Map map;
        int puanCount = 0;
        Label puanLabel = new Label();
        Point topPreviousLocation = new Point();
        Timer t = new Timer();
        List<Nokta> dusenNoktalar = new List<Nokta>();
        int speed = 1;
        int topX, topY, topVX, topVY;

        public Oyun()
        {
            cubuk = new DefaultCubuk();
            top = new DefaultTop();
            map = new DefaultMap();
        }

        public Oyun(Cubuk cubuk, Top top, Map map)
        {
            this.cubuk = cubuk;
            this.top = top;
            this.map = map;
        }

        private void yenidenBasla()
        {

            List<Nokta> tempMermiler = new List<Nokta>(cubuk.Mermiler.Select(x => x));
            List<Nokta> tempMap = new List<Nokta>(map.getNoktalar().Select(x => x));
            foreach (Control obje in main.Controls)
            {
                main.Controls.Remove(obje);
            }
            foreach (Nokta mermi in tempMermiler)
            {
                cubuk.Mermiler.Remove(mermi);
            }
            foreach (Nokta nokta in tempMap)
            {
                map.deleteInMap(nokta);
            }

            cubuk.removeCubuk();
            top.removeTop();
            t.Stop();
        }
        public void setForm(Main main)
        {
            this.main = main;
        }
        public void yukle()
        {
            cubuk.setForm(main);
            top.setForm(main);
            map.setForm(main);
            cubuk.ciz();
            top.ciz();
            map.ciz();

            top.getTop().Location = new Point(200, 30);
            topX = top.getTop().Location.X;
            topY = top.getTop().Location.Y;
            topVY = topVX = speed;

            puanLabeliniİlkle();
        }
        private void puanLabeliniİlkle()
        {
            puanCount = 0;
            puanLabel.Text = "Puan: " + puanCount;
            puanLabel.Location = new Point(main.Width / 20, main.Height - main.Height / 5);
            puanLabel.ForeColor = Color.Red;
            int fontSize = 15;
            puanLabel.Font = new Font("Arial", fontSize);  
            main.Controls.Add(puanLabel);
        }
        private void puanla(Nokta n)
        {
            puanCount += n.Puan;
            puanLabel.Text = "Puan: " + puanCount;
        }

        public void basla()
        {

            t.Interval = 1;

            //t.Tick += new EventHandler(t_tick);
            //t.Tick += new EventHandler(t_tick);
            t.Tick += new EventHandler(t_tick);
            t.Tick += new EventHandler(t_tick);
            t.Tick += new EventHandler(t_tick);
            t.Start();
        }
        private void t_tick(object sender, EventArgs e)
        {
            topHareket();
            mermihareket();
            ozellikleriZamanla();
            cubukCarpismaKontrol();
            puaniYaz();
        }

        private void puaniYaz()
        {

        }

        public bool yanma()
        {
            if (top.getTop().Location.Y >= main.Size.Height - 58)
            {        
                yenidenBasla();
                return true;
            }

            return false;
        }
        public bool oyunBittiKontrol()
        {
            if (map.getNoktalar().Count == 0)
            {
                yenidenBasla();
                return true;
            }
            return false;
        }


        private void mermihareket()
        {
            foreach (Nokta n in cubuk.Mermiler)
            {
                n.Location = new Point(n.Location.X, n.Location.Y - 1);
            }
            mermileriKontrolEt();
        }

        private void mermileriKontrolEt()
        {
            List<Nokta> tempMermiler = new List<Nokta>(cubuk.Mermiler.Select(x => x));
            foreach (Nokta n in tempMermiler)
            {
                mermiHaritaSonuCarpismaKontrol(n);
                mermiMapNoktaCarpismaKontrol(n);
            }
        }
        private void mermiHaritaSonuCarpismaKontrol(Nokta mermi)
        {
            if (mermi.Location.Y <= 0)
            {
                cubuk.Mermiler.Remove(mermi);
                main.Controls.Remove(mermi);
            }
        }
        private void mermiMapNoktaCarpismaKontrol(Nokta mermi)
        {
            List<Nokta> tempMermiler = new List<Nokta>(map.getNoktalar().Select(x => x));
            foreach (Nokta n in tempMermiler)
            {
                if (mermi.Location.X >= n.Location.X && mermi.Location.X <= n.Location.X + n.Size.Width &&
                    mermi.Location.Y == n.Location.Y + n.Size.Height)
                {
                    puanla(n);
                    cubuk.Mermiler.Remove(mermi);
                    main.Controls.Remove(mermi);
                    map.deleteInMap(n);
                }
            }
        }
        public void topHareket()
        {
            oyunBittiKontrol();
            duvarCarpismaKontrol();
            haritaCarpismaKontrol();
            cubukTopCarpismaKontrol();
            topX += topVX;
            topY += topVY;
            top.getTop().Location = new Point(topX, topY);
        }
        private void haritaCarpismaKontrol()
        {
            if (map.getNoktalar().Count != 0)
            {
                int topLocationX = top.getTop().Location.X;
                int topLocationY = top.getTop().Location.Y;
                int topGenislik = top.getTop().Size.Width;
                int tuglaGenislik = map.getNoktalar()[0].Size.Width;
                int tuglaYukselik = map.getNoktalar()[0].Size.Height;
                int topWidth = top.getTop().Size.Width;
                int topHeight = top.getTop().Size.Height;
                foreach (Nokta n in map.getNoktalar())
                {
                    //birimin ustuyle carpişmasi
                    if (n.Location.Y - tuglaYukselik == topLocationY &&
                        n.Location.X - topGenislik - 1 <= topLocationX &&
                        topLocationX <= n.Location.X + tuglaGenislik - 1 && n.Gecirgenlik == false)
                    {
                        topVY = -topVY;
                        if (n.Silinebilirlik)
                        {
                            mapteBirimsil(n);
                        }
                        else
                        {
                            map.getNoktalar().FirstOrDefault(m => m == n).Gecirgenlik = true;
                            n.Gecirgenlik = true;
                            dusenNoktalar.Add(n);
                        }
                        puanla(n);
                        break;
                    }
                    //birimin sag tarafıyla carpişmasi
                    if (n.Location.X + tuglaGenislik == topLocationX && n.Location.Y - tuglaYukselik - 1 <= topLocationY &&
                        topLocationY <= n.Location.Y + tuglaYukselik - 1 && n.Gecirgenlik == false)
                    {
                        topVX = -topVX;
                        if (n.Silinebilirlik)
                            mapteBirimsil(n);
                        else
                        {
                            map.getNoktalar().FirstOrDefault(m => m == n).Gecirgenlik = true;
                            n.Gecirgenlik = true;
                            dusenNoktalar.Add(n);
                        }
                        puanla(n);
                        break;
                    }
                    //birimin altıyla carpişmasi
                    if (n.Location.Y + tuglaYukselik == topLocationY &&
                        n.Location.X - topGenislik - 1 <= topLocationX
                        && topLocationX <= n.Location.X + tuglaGenislik - 1 && n.Gecirgenlik == false)
                    {
                        topVY = -topVY;
                        if (n.Silinebilirlik)
                            mapteBirimsil(n);
                        else
                        {
                            map.getNoktalar().FirstOrDefault(m => m == n).Gecirgenlik = true;
                            n.Gecirgenlik = true;
                            dusenNoktalar.Add(n);
                        }
                        puanla(n);
                        break;
                    }
                    //birimin soluyla carpişmasi
                    if (n.Location.X - topGenislik == topLocationX &&
                        n.Location.Y - tuglaYukselik - 1 <= topLocationY &&
                        topLocationY <= n.Location.Y + tuglaYukselik - 1 && n.Gecirgenlik == false)
                    {
                        topVX = -topVX;
                        if (n.Silinebilirlik)
                            mapteBirimsil(n);
                        else
                        {
                            map.getNoktalar().FirstOrDefault(m => m == n).Gecirgenlik = true;
                            n.Gecirgenlik = true;
                            dusenNoktalar.Add(n);
                        }
                        puanla(n);
                        break;
                    }
                }

                if (dusenNoktalar != null)
                {
                    map.hareketEttir(dusenNoktalar);
                }
            }
        }
        private void cubukTopCarpismaKontrol()
        {
            int topX = top.getTop().Location.X;
            int topY = top.getTop().Location.Y;
            int cubukX = cubuk.getCubuk().Location.X;
            int cubukY = cubuk.getCubuk().Location.Y;
            int cubukWidth = cubuk.getCubuk().Size.Width;
            int cubukHeight = cubuk.getCubuk().Size.Height;
            int topHeight = top.getTop().Size.Height;
            int topwidth = top.getTop().Size.Width;

            if ((topX <= cubukX - 2 * topwidth && topX >= cubukX - 3 * topwidth) ||
                (topX == cubukX + cubukWidth + 2 * topwidth && topX <= cubukX + cubukWidth + 3 * topwidth))
            {
                topPreviousLocation = new Point(topX, topY);
            }

            if (topX >= cubukX - topwidth &&//ÇUBUGUN SOL TARAFIYLA ÇARPIŞMASI
             topX <= cubukX + cubukWidth / 3 &&
             topY + topHeight == cubukY && topPreviousLocation.X <= cubukX)
            {
                topVY = -topVY;
                topVX = (int)-1.5 * topVX;
            }
            else if (topX >= cubukX + 2 * cubukWidth / 3 &&//ÇUBUGUN SAĞ TARAFIYLA ÇARPIŞMASI
             topX <= cubukX + cubukWidth && topY + topHeight == cubukY)
            {
                topVY = -topVY;
                topVX = (int)-1.5 * topVX;
            }

            else if (topX >= cubukX - topwidth &&
            topX <= cubukX + cubukWidth &&
            topY + topHeight == cubukY)
            {
                topVY = -topVY;
            }
        }

        private void cubukCarpismaKontrol()
        {
            List<Nokta> tempdusenNoktalar = new List<Nokta>(dusenNoktalar.Select(x => x));
            foreach (Nokta dN in tempdusenNoktalar)
            {
                cubukOzellikCarpismaKontrol(dN);
            }
        }
        private void cubukOzellikCarpismaKontrol(Nokta Ozellik)
        {

            if (Ozellik.Location.Y + Ozellik.Size.Height == cubuk.getCubuk().Location.Y &&
                     Ozellik.Location.X >= cubuk.getCubuk().Location.X - Ozellik.Size.Width &&
                     Ozellik.Location.X <= cubuk.getCubuk().Location.X + cubuk.getCubuk().Size.Width)
            {
                if (Ozellik.Durumu == "Buyu")
                {
                    cubuk.setbuyumeOz(new Buyu());
                    cubuk.buyu(cubuk.getCubuk(), 1.2, 1.0);
                }
                if (Ozellik.Durumu == "Ates")
                {
                    AtesEt a = new AtesEt();
                    a.setForm(main);
                    cubuk.setAtesEtmeOz(a);
                }
                if (top.getTop().Location.Y + 20 == cubuk.getCubuk().Location.Y)
                    cubuk.setAtesEtmeOz(new AtesEtme());
                dusenNoktalar.Remove(Ozellik);
                map.deleteInMap(Ozellik);
            }
            else if (Ozellik.Location.Y >= main.Size.Height - 58)
            {
                dusenNoktalar.Remove(Ozellik);
                map.deleteInMap(Ozellik);
            }
        }

        public void ozellikleriZamanla()
        {
            if (cubuk.getAtesEtmeOz().GetType().ToString() == "DxBall.Interfaces.Ates.AtesEt")
            {
                AtesEt t = new AtesEt();
                t = (AtesEt)cubuk.getAtesEtmeOz();
                t.AtesZamani++;
                if (t.AtesZamani >= t.OzellikSure)
                {
                    cubuk.setAtesEtmeOz(new AtesEtme());
                    t.AtesZamani = 0;
                }
            }
        }
        public void cubukHareket(char yon)
        {
            if (yon == 'd' || yon == 'D')
            {
                if (cubuk.getCubuk().Location.X <= main.Size.Width-100)
                    cubuk.sagaGit();
            }
            if (yon == 'a' || yon == 'A')
            {
                if (cubuk.getCubuk().Location.X >= 0)
                    cubuk.solaGit();
            }
            if (yon == ' ')
            {
                if (cubuk.getAtesEtmeOz().GetType().ToString() == "DxBall.Interfaces.Ates.AtesEt")
                {
                    cubuk.atesEt(null, null);
                }
            }
        }
      
        private void mapteBirimsil(Nokta n)
        {
            map.deleteInMap(n);
        }
        private void duvarCarpismaKontrol()
        {
            if (topX >= main.Size.Width - 36)
            {
                topVX = -topVX;
            }
            if (topX <= 0)
            {
                topVX = -topVX;
            }
            if (topY <= 0)
            {
                topVY = -topVY;
            }
        }
    }
}

