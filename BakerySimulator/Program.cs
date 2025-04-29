
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace BakerySimulator
{
    class Program
    {
        static bool Quit = false;

        static void Main(string[] args)
        {

            // Kontroll funktioner
            InputKontroll inputKontroll = new InputKontroll();
            Vy vy = new Vy();

            // Bygga butiken (Ladda)
            Varor[] meny = { new Limpabrod(), new Lantbrod(), new Kaka() };
            Butik butik = inputKontroll.LoadButik(meny);
            double startPengar = butik.GetKontanter();

            // Dagens rutiner
            bool forbereda = false;


            /********************* Huvud menyn *********************/
            
            vy.Instruktion(startPengar);

            while (!Quit)
            {
                vy.VisaHuvudMeny(forbereda);
                int huvudMeny = inputKontroll.ValjaMeny();

                switch (huvudMeny)
                {
                    case 0:
                        break;

                    // 1.Förbereda butiken
                    case 1:

                        ForberedaButiken();
                        break;

                    // 2. Öppna butiken
                    case 2:
                        OppnaButiken();
                        break;

                    // 3. Visa result
                    case 3:
                        VisaResult();
                        break;

                    // 4. Se butiks hylla
                    case 4:
                        SeHyllan();
                        break;

                    // 5.Spara data
                    case 5:
                        SaveData();
                        break;

                    // 6. Återställ data.
                    case 6:
                        RaderaData();
                        break;

                    case 9:
                        Quit = true;
                        Console.WriteLine("Hej då!");
                        break;
                }
            }
            

            void ForberedaButiken()
            {
                // Förberedelser inför öppnandet //

                int[] forsaljningsPlan = inputKontroll.InputPlan(meny);
                int[] baksPlan = butik.PlaneraVaror(forsaljningsPlan);
                vy.Plan(meny, baksPlan);

                vy.Inkopning();
                Faktura faktura = butik.KopaRavaror(baksPlan);
                vy.VisaFaktura(faktura);

                butik.SkapaVaror(baksPlan);
                vy.Bakning();

                SeHyllan();

                forbereda = true;

            }

            void OppnaButiken()
            {
                // Öppna butiken //
                butik.OppnaButik();
                vy.Oppen();

                butik.SaljaVaror();

                // Stänga butiken //
                vy.Stang();
                butik.StangButik();
                SeHyllan();


                VisaResult();

                forbereda = false;
            }


            void VisaResult()
            {
                double[] vinst = butik.GetVinst();
                vy.VisaVinst(vinst);

            }

            void SeHyllan()
            {
                string[] hyllan = butik.GetHyllan();
                vy.VisaHyllan(hyllan);
            }

            void SaveData()
            {
                inputKontroll.Save(butik);
                vy.Save();

            }

            void RaderaData()
            {
                bool raderas = inputKontroll.Radera();
                vy.Radera(raderas);
            }

        }

    }

}
