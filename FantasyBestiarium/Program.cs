namespace FantasyBestiarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SzornyAdatbazis db = new SzornyAdatbazis("server=localhost;database=fantasybestariumdb;uid=root;pwd=");
            List<Szorny> szornylista = db.Feltolt();

            Szornyelemzo szornyelemzo = new Szornyelemzo(szornylista);

            

            Console.WriteLine($"A listában {szornyelemzo.OsszesSzornySzama()} db szörny van");
            Console.WriteLine($"A veszélyes szörnyek nevei: {szornyelemzo.VeszelyesSzornyekNevei()}");
            Console.WriteLine($"Egyedi elohelyek: {szornyelemzo.EgyediElohelyek()}");
            Console.WriteLine($"Az átlagos veszelyesség: {szornyelemzo.AtlagosVeszelyesseg()}");
            Console.WriteLine($"A legveszélyesebb szörnyek {szornyelemzo.LegveszelyesebbSzornyek()}");
            Console.WriteLine($"Veszélyes Mocsári szörnyek: {szornyelemzo.MocsariVeszelyesSzornyek()}");
            Console.WriteLine($"Legalább 9es veszelyességi szintű szörny akinek a tűz a legnagyobb gyengesége {szornyelemzo.VanExtremTuzGyengeSzorny}");
            Console.WriteLine($"A szörnyek száma élőhelyenként: {szornyelemzo.SzornyekSzamaElohelyenkent()}");


        }
    }
}
