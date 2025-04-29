using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Kaka : Varor
    {
        // Kladdkaka
        // Pris: 42.95 SEK, Dagar till Utgångsdatum: 2 dagar.

        public Kaka() : base(42.95, 2)
        {
            _ingrediens.Smor = 100;
            _ingrediens.Agg = 2;
            _ingrediens.Socker = 250;
            _ingrediens.Kakao = 45;
            _ingrediens.VaniljSocker = 10;
            _ingrediens.Vetemjol = 90;
            _ingrediens.Salt = 1;
            _brodtyp = "Kladdkaka";
        }
        public Kaka(int dagar) : base(42.95, dagar)
        {
            _ingrediens.Smor = 100;
            _ingrediens.Agg = 2;
            _ingrediens.Socker = 250;
            _ingrediens.Kakao = 45;
            _ingrediens.VaniljSocker = 10;
            _ingrediens.Vetemjol = 90;
            _ingrediens.Salt = 1;
            _brodtyp = "Kladdkaka";
        }

    }
}

