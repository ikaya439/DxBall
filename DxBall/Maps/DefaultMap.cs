using DxBall.Noktalar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DxBall.Maps
{
    class DefaultMap : Map
    {
        public DefaultMap()
        {
            haritaOlustur();
        }
        public override void deleteInMap(Nokta n)
        {
            foreach (Control c in main.Controls)
            {
                if (c == n)
                {
                    main.Controls.Remove(n);
                    noktalar.Remove(n);
                }
            }
        }
        public override void ciz()
        {
            foreach (Nokta n in noktalar)
            {
                main.Controls.Add(n);
            }
        }
        public override void hareketEttir(List<Nokta> dusenNoktalar)
        {
            foreach (Control c in main.Controls)
            {
                foreach (Nokta n in dusenNoktalar)
                {
                    if (c == n)
                    {
                        n.Location = new Point(n.Location.X, n.Location.Y + 1);
                    }
                }
            }
        }
        private void haritaOlustur()
        {
            AtesOzellikliNokta ates = new AtesOzellikliNokta();
            BuyumeOzellikliNokta buyume = new BuyumeOzellikliNokta();
            noktalar.Clear();
            int soldanBaslangic = 100;
            int tempSoldanBaslangic = 100;
            int yukaridanBaslangic = 60;
            int tuglaGenislik = 60;
            int tuglaUzunluk = 20;

            int tuglalarArasindakiBosluk = 1;
            int enUsttekiTuglaSayisi = 10;
            Random rnd = new Random();
            int randomTugla;
            Nokta n;
            for (int i = 0; i < enUsttekiTuglaSayisi; i++)
            {
                randomTugla = rnd.Next(0, 100);
                if (randomTugla >= 0 && randomTugla < ates.DusmeOlasilik && randomTugla <= 100 - buyume.DusmeOlasilik)
                {
                    n = new AtesOzellikliNokta();
                }
                else if (randomTugla >= ates.DusmeOlasilik && randomTugla < buyume.DusmeOlasilik + ates.DusmeOlasilik)
                {
                    n = new BuyumeOzellikliNokta();
                }
                else
                {
                    n = new DefaultNokta();
                }
                n.Location = new Point(soldanBaslangic, yukaridanBaslangic);
                n.Size = new Size(tuglaGenislik, tuglaUzunluk);
                noktalar.Add(n);
                if (i + 1 == enUsttekiTuglaSayisi)
                {
                    enUsttekiTuglaSayisi -= 2;
                    i = -1;
                    yukaridanBaslangic += tuglaUzunluk + tuglalarArasindakiBosluk;
                    tempSoldanBaslangic += tuglaGenislik + tuglalarArasindakiBosluk;
                    soldanBaslangic = tempSoldanBaslangic;
                }
                else
                {
                    soldanBaslangic += tuglaGenislik + tuglalarArasindakiBosluk;
                }


            }

        }
    }
}
