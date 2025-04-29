using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Limpabrod : Varor
    {

        // Limpa
        // Pris: 28.5SEK, Dagar till Utgångsdatum: 4 dagar.

        public Limpabrod() : base(28.5, 4)
        {
            _ingrediens.Jast = 25;
            _ingrediens.Mjolk = 350;
            _ingrediens.Salt = 5;
            _ingrediens.Smor = 50;
            _ingrediens.Socker = 50;
            _ingrediens.Ragmjol = 270;
            _ingrediens.Vetemjol = 270;
            _brodtyp = "Limpabröd";
        }

        public Limpabrod(int dagar) : base(28.5, dagar)
        {
            _ingrediens.Jast = 25;
            _ingrediens.Mjolk = 350;
            _ingrediens.Salt = 5;
            _ingrediens.Smor = 50;
            _ingrediens.Socker = 50;
            _ingrediens.Ragmjol = 270;
            _ingrediens.Vetemjol = 270;
            _brodtyp = "Limpabröd";
        }


    }
}
