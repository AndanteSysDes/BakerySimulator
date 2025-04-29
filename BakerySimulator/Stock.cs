using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Stock
    {
        // Per Gram eller Sticken(Agg)

        public double 
            Kakao,
            Ragmjol,
            Salt, 
            Smor, 
            Socker, 
            Agg, 
            VaniljSocker, 
            Jast, 
            Vetemjol, 
            Mjolk;

        public Stock()
        {
            Kakao= 0;
            Ragmjol= 0;
            Salt= 0; 
            Smor= 0; 
            Socker= 0; 
            Agg= 0; 
            VaniljSocker= 0; 
            Jast= 0; 
            Vetemjol= 0; 
            Mjolk = 0;
        }

        public Stock(Stock input)
        {
            Kakao = input.Kakao;
            Ragmjol = input.Ragmjol;
            Salt = input.Salt;
            Smor = input.Smor;
            Socker = input.Socker;
            Agg = input.Agg;
            VaniljSocker = input.VaniljSocker;
            Jast = input.Jast;
            Vetemjol = input.Vetemjol;
            Mjolk = input.Mjolk;

        }
        public Stock(Stock input, int antal)
        {
            Kakao = input.Kakao* antal;
            Ragmjol = input.Ragmjol* antal;
            Salt = input.Salt* antal;
            Smor = input.Smor* antal;
            Socker = input.Socker* antal;
            Agg = input.Agg* antal;
            VaniljSocker = input.VaniljSocker* antal;
            Jast = input.Jast* antal;
            Vetemjol = input.Vetemjol* antal;
            Mjolk = input.Mjolk* antal;

        }

        public void LaggTillStock(Stock inputStock)
        {
           Kakao += inputStock.Kakao;
           Ragmjol += inputStock.Ragmjol;
           Salt += inputStock.Salt;
           Smor += inputStock.Smor;
           Socker += inputStock.Socker;
           Agg += inputStock.Agg;
           VaniljSocker += inputStock.VaniljSocker;
           Jast += inputStock.Jast;
           Vetemjol += inputStock.Vetemjol;
           Mjolk += inputStock.Mjolk;
        }

        public void KonsmeraStock(Stock outputStock)
        {
           Kakao -= outputStock.Kakao;
           Ragmjol -= outputStock.Ragmjol;
           Salt -= outputStock.Salt;
           Smor -= outputStock.Smor;
           Socker -= outputStock.Socker;
           Agg -= outputStock.Agg;
           VaniljSocker -= outputStock.VaniljSocker;
           Jast -= outputStock.Jast;
           Vetemjol -= outputStock.Vetemjol;
           Mjolk -= outputStock.Mjolk;
        }


        public void VisaStock()
        {
            Console.WriteLine("Kakao :" + Kakao);
            Console.WriteLine("Ragmjol :" +Ragmjol);
            Console.WriteLine("Salt :" + Salt);
            Console.WriteLine("Smor :" + Smor);
            Console.WriteLine("Socker :" + Socker);
            Console.WriteLine("Agg :" + Agg);
            Console.WriteLine("VaniljSocker" + VaniljSocker);
            Console.WriteLine("Jast: " + Jast);
            Console.WriteLine("Vetemjol :" + Vetemjol);
            Console.WriteLine("Mjolk : " + Mjolk);
        }
    }
}
