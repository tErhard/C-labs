using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_programming
{
    internal class GasStation
    {
        public int id { get; set; }
        public string adress { get; set; }
        public string company { get; set; }
        public double benzin { get; set; }
        public int A_80 { get; set; }
        public int A_92 { get; set; }
        public int A_95 { get; set; }
        public int A_80_price { get; set; }
        public int A_92_price { get; set; }
        public int A_95_price { get; set; }

        public GasStation(int id, string adress, string company, double benzin, int A_80, int A_92, int A_95, int A_80_price, int A_92_price, int A_95_price)
        {
            this.id = id;
            this.adress = adress;
            this.company = company;
            this.benzin = benzin;
            this.A_80 = A_80;
            this.A_92 = A_92;
            this.A_95 = A_95;
            this.A_80_price = A_80_price;
            this.A_92_price = A_92_price;
            this.A_95_price = A_95_price;
        }

        public GasStation(string adress, string company, double benzin, int A_80, int A_92, int A_95, int A_80_price, int A_92_price, int A_95_price)
        {
            this.id = 0;
            this.adress = adress;
            this.company = company;
            this.benzin = benzin;
            this.A_80 = A_80;
            this.A_92 = A_92;
            this.A_95 = A_95;
            this.A_80_price = A_80_price;
            this.A_92_price = A_92_price;
            this.A_95_price = A_95_price;
        }
        public GasStation() { }

        public override string ToString()
        {
            return $"Azs:{company} {adress} with id {id}";
        }
    }
}

