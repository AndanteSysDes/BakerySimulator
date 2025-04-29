using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Lantbrod : Varor
    {
        // Lantbröd
        // Pris: 34.95 SEK, Dagar till Utgångsdatum: 6 dagar.

        public Lantbrod() : base(24.95, 6)
        {
            _ingrediens.Jast = 25;
            _ingrediens.Salt = 10;
            _ingrediens.Vetemjol = 660;
            _brodtyp = "Lantbröd";
        }
        public Lantbrod(int dagar) : base(24.95, dagar)
        {
            _ingrediens.Jast = 25;
            _ingrediens.Salt = 10;
            _ingrediens.Vetemjol = 660;
            _brodtyp = "Lantbröd";
        }



    }
}
