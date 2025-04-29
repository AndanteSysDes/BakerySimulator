using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Kassa
    {
        private double _kontanter;
        private Bokforing _bokforing;

        public Kassa()
        {
            _bokforing = new Bokforing();
            _kontanter = _bokforing.GetKontanter();
        }
        public Kassa(Bokforing bokforing)
        {
            _bokforing = bokforing;
            _kontanter = _bokforing.GetKontanter();
        }

        // Inköp av råvaror
        public Faktura Inkop(Stock inkopStock)
        {
            double[] orderkvantitet =
            {
                inkopStock.Kakao,
                inkopStock.Ragmjol ,
                inkopStock.Salt ,
                inkopStock.Smor ,
                inkopStock.Socker ,
                inkopStock.Agg ,
                inkopStock.VaniljSocker ,
                inkopStock.Jast ,
                inkopStock.Vetemjol ,
                inkopStock.Mjolk
            };

            Faktura faktura = new Faktura(orderkvantitet, DateTime.Now);
            _bokforing.SkrivFaktura(faktura);
            _kontanter -= faktura.GetBelopp();

            // faktura.VisaFaktura();

            return faktura;

        }

        public double Kontanter()
        {
            return _kontanter;
        }

        // Försäljning av varor
        public void Forsaljning(List<Varor> varukorg)
        {

            Kvitto kvitto = new Kvitto(varukorg, DateTime.Now);
            _bokforing.SkrivKvitto(kvitto);
            _kontanter -= kvitto.GetBelopp();

        }

        public double [] TotalVinst()
        {
            double[] vinst = new double[3];
            vinst[0] = _bokforing.GetTotalInkomst();

            vinst[1] = _bokforing.GetTotalUtgift();

            vinst[2] = Math.Round(vinst[0] - vinst[1], 2, MidpointRounding.AwayFromZero);

            return vinst;

        }

        public Bokforing GetBokforing()
        {
            return _bokforing;
        }
    }
}
