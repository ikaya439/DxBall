using System.Collections.Generic;

namespace DxBall.Maps
{
    abstract class Map
    {
        public Main main = new Main();
        public void setForm(Main m)
        {
            this.main = m;
        }
        protected List<Nokta> noktalar = new List<Nokta>();
        public List<Nokta> getNoktalar()
        {
            return noktalar;
        }
        public abstract void ciz();
        public abstract void deleteInMap(Nokta n);
        public abstract void hareketEttir(List<Nokta> dusenNoktalar);
    }
}
