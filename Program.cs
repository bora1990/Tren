using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama_metotlar_
{
    class Talep
    {
        public Tren Tren { get; set; }
        public int KisiSayisi { get; set; }
        public bool FarkliYerlesim { get; set; }
    }

    class Tren
    {
        private static string TrenAd = "Başkent Tren";
        public TrenVagon[] Vagonlar { get; set; }

        public static string DisplayTrainName()
        {
            return TrenAd;
        }
    }

    class TrenVagon
    {
        public string VagonAd { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
    }

    class Yanit
    {
        public bool RezYapilirMi { get; set; }
        public Ayrinti[] Ayrintilar { get; set; }
    }

    public class Ayrinti
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            double yuzde = (double)70 / (double)100;

            Console.WriteLine("Tren adı:" + Tren.DisplayTrainName());

            Console.WriteLine("Binecek kişi sayısı :");
            var kisiSayisi = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Vagon adedini giriniz: ");
            var vagonAdedi = Console.ReadLine();


            int vagonAdetSayi = Convert.ToInt32(vagonAdedi);

            TrenVagon[] IstenenVagonlar = new TrenVagon[vagonAdetSayi];

            for (int i = 0; i < vagonAdetSayi; i++)
            {
                Console.WriteLine(i + 1 + ". " + " vagonun kapasitesi:");
                var kapasite = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dolu koltuk sayısını giriniz:");
                var doluKoltuk = Convert.ToInt32(Console.ReadLine());

                var yeniVagon = new TrenVagon
                {
                    Kapasite = kapasite,
                    DoluKoltukAdet = doluKoltuk,
                    VagonAd = "Vagon" + i
                };

                IstenenVagonlar[i] = yeniVagon;
            }

            Yanit yanit = new Yanit();
            Ayrinti[] ayrintilar = new Ayrinti[vagonAdetSayi];
            int x = 0;
            bool olduMu = false;

            foreach (var vagon in IstenenVagonlar)
            {
                bool gectiMi = yuzde > Convert.ToDouble(vagon.DoluKoltukAdet) / Convert.ToDouble(vagon.Kapasite);

                if (gectiMi)
                {
                    olduMu = true;

                    Ayrinti ayrinti = new Ayrinti();

                    ayrinti.VagonAdi = vagon.VagonAd;
                    ayrinti.KisiSayisi = kisiSayisi;

                    ayrintilar[x] = ayrinti;
                }
                else
                {
                    Ayrinti ayrinti = new Ayrinti();

                    ayrinti.VagonAdi = vagon.VagonAd;
                    ayrinti.KisiSayisi = 0;

                    ayrintilar[x] = ayrinti;
                }

                x++;
            }

            if (olduMu == true)
            {
                yanit.RezYapilirMi = true;
            }

            yanit.Ayrintilar = ayrintilar;

            foreach (var ayrinti in yanit.Ayrintilar)   
            {
                Console.WriteLine(ayrinti.VagonAdi + " " + ayrinti.KisiSayisi);
            }

            Console.WriteLine(yanit.RezYapilirMi);

            Console.ReadLine();



        }










    }
}













