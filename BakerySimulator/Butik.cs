using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Butik
    {
        private Varor[] _meny ;

        private Kok _kok;
        private Kassa _kassa;
        private List<Varor> _butiksHylla;
        private bool _oppet = false;


        public Butik(Varor[] meny)
        {
            _meny = meny;
            _kok = new Kok();
            _kassa = new Kassa();
            _butiksHylla = new List<Varor>();
        }
        public Butik(Varor[] meny, Bokforing bokforing, List<Varor> butiksHylla)
        {
            _meny = meny;
            _kok = new Kok();
            _kassa = new Kassa(bokforing);
            _butiksHylla = new List<Varor>(butiksHylla);
        }

        public void OppnaButik()
        {
            _oppet = true;
        }

        public void StangButik()
        {
            _oppet = false;

            foreach(Varor varor in _butiksHylla)
            {
                varor.forsamring();
            }

            _butiksHylla.RemoveAll(v => v.GetDagar() < 1);

        }

        public double[] GetVinst()
        {
            double[] vinst = _kassa.TotalVinst();

            return vinst;
        }

        public double GetKontanter()
        {
            return _kassa.Kontanter();
        }

        public void SaljaVaror()
        {
            // 0-9 kunder besöker butiken.
            Random random = new Random();
            int kunder = random.Next(0,10);

            Console.WriteLine($"Idag kommer {kunder} kunder till butiken.");
            Console.WriteLine();

            for (int i = 0; i < kunder; i++)
            {

                System.Threading.Thread.Sleep(1000);

                // bestämma antal. (1 - 4 st)
                random = new Random();
                int antal = random.Next(1, 5);
                List<Varor> varukorg = new List<Varor>();

                for (int j = 0; j < antal; j++)
                {
                    // bestämma varor som kunden köper.
                    random = new Random();
                    int menyVal = random.Next(0, _meny.Length);

                    Console.Write($"Kunden{i + 1} vill köpa {_meny[menyVal].GetBrodTyp()} ");

                    int index = _butiksHylla.FindIndex(v => v.GetBrodTyp() == _meny[menyVal].GetBrodTyp());

                    // När utsålt
                    if (index == -1)
                    {
                        Console.WriteLine($"men hittar inte den på butiks hylla.");
                        continue;
                    }

                    // lägga till varukorg

                    varukorg.Add(_butiksHylla[index]);
                    _butiksHylla.RemoveAt(index);

                    Console.WriteLine($"och lägger den till varukorg.");


                }

                if(varukorg.Count == 0)
                {
                    Console.WriteLine($"Kunden {i + 1} gick hem.");
                    continue;
                }

                // gå till kassan
                _kassa.Forsaljning(varukorg);

                Console.WriteLine($"Kunden{i + 1} har köpt varorna.");

            }

        }

        /* Planera hur mycket varor butiken bakar.*/
        public int[] PlaneraVaror(int[] forsaljningsPlan)
        {
            int[] baksPlan = new int[_meny.Length];

            for (int i = 0; i < _meny.Length; i++)
            {

                // Räkna restan av varor.
                int resten = 0;
                foreach (Varor varor in _butiksHylla)
                {
                    if (varor.GetBrodTyp() == _meny[i].GetBrodTyp())
                    {
                        resten++;
                    }
                }

                // Räkna baks plan. (antal av varor)

                baksPlan[i] = forsaljningsPlan[i] - resten;
                if (baksPlan[i] < 0)
                {
                    baksPlan[i] = 0;
                }
            }

            return baksPlan;

        }

        public Faktura KopaRavaror(int[] baksPlan)
        {
            Stock inkopStock = new Stock();
            Faktura faktura;

            for (int i = 0; i < _meny.Length; i++)
            {
                /* Planera hur mycket råvaror butiken köper.*/
                Stock receptIngredienser = _meny[i].BakRecept(baksPlan[i]);
                inkopStock.LaggTillStock(receptIngredienser);

            }

            /* Köpa totalt ingredienser.*/
            faktura = _kassa.Inkop(inkopStock);
            _kok.LaggTillStock(inkopStock);

            return faktura;
        }

        public void SkapaVaror(int[] baksPlan)
        {
            for (int i = 0; i < _meny.Length; i++)
            {
                _butiksHylla.AddRange(_kok.Baka(_meny[i].GetBrodTyp(), baksPlan[i]));

            }

        }

        public string[] GetHyllan()
        {
            string[] hyllan = new string[_meny.Length];


            for (int i = 0; i < _meny.Length; i++)
            {
                int resten = 0;

                foreach (Varor varor in _butiksHylla)
                {
                    if (varor.GetBrodTyp() == _meny[i].GetBrodTyp())
                    {
                        resten++;
                    }
                }

                //Console.WriteLine(_meny[i].GetBrodTyp() + " : " + resten + " st.");

                hyllan[i] = _meny[i].GetBrodTyp().PadRight(20, ' ') + $"{resten} st.".PadLeft(10, ' ');
            }

            return hyllan;
        }

        public List<Varor> GetAllHyllan()
        {
            return _butiksHylla;
        }

        public Bokforing GetBokforing()
        {
            return _kassa.GetBokforing();
        }

    }
}
