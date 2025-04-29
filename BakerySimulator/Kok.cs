using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Kok
    {
        private Stock _koksStock = new Stock();

        public void LaggTillStock(Stock inputStock)
        {
            _koksStock.LaggTillStock(inputStock);

        }

        public void KonsmeraStock(Stock outputStock)
        {
            _koksStock.KonsmeraStock(outputStock);

        }

        // Bakning av bröd med hjälp av köksutrustning.
        public List<Varor> Baka(string brodnamn, int antal)
        {
            List<Varor> varors = new List<Varor>();
            Stock kravsStock;

            switch (brodnamn)
            {
                case "Limpabröd":
                    // Se receptet och konsumera Stock.
                    Limpabrod limpaRecept = new Limpabrod();                    
                    kravsStock = limpaRecept.BakRecept(antal);
                    KonsmeraStock(kravsStock);

                    // Baka bröd
                    for (int i = 0; i < antal; i++)
                    {
                        varors.Add(new Limpabrod());
                    }

                    break;

                case "Lantbröd":
                    // Se receptet och konsumera Stock.
                    Lantbrod lantRecept = new Lantbrod();
                    kravsStock = lantRecept.BakRecept(antal);
                    KonsmeraStock(kravsStock);

                    // Baka bröd
                    for (int i = 0; i < antal; i++)
                    {
                        varors.Add(new Lantbrod());
                    }

                    break;

                case "Kladdkaka":
                    // Se receptet och konsumera Stock.
                    Kaka kakaRecept = new Kaka();
                    kravsStock = kakaRecept.BakRecept(antal);
                    KonsmeraStock(kravsStock);

                    // Baka bröd
                    for (int i = 0; i < antal; i++)
                    {
                        varors.Add(new Kaka());
                    }
                    break;


                default: break;
            }


            return varors;

        }

        public Stock TaStock()
        {
            return _koksStock;
        }
    }
}
