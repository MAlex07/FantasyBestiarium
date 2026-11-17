using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FantasyBestiarium
{
    internal class Szornyelemzo
    {
        private List<Szorny> szornyek;

        public Szornyelemzo(List<Szorny> szornyek)
        {
            this.szornyek = szornyek;
        }

        public int OsszesSzornySzama()
        {
            return szornyek.Count(sz => sz.Nev != null);
        }

        public IEnumerable<string> VeszelyesSzornyekNevei()
        {
            return szornyek.Where(sz => sz.VeszelyesE).Select(sz => sz.Nev);
        }

        public IEnumerable<string> EgyediElohelyek()
        {
            return szornyek.OrderBy(sz => sz.Elohely).Select(sz => sz.Elohely).Distinct();
        }

        public double AtlagosVeszelyesseg()
        {
            return szornyek.Average(sz => sz.VeszelyessegiSzint);
        }

        public IEnumerable<string> LegveszelyesebbSzornyek()
        {
            int maxVeszelyesseg = szornyek.Max(sz => sz.VeszelyessegiSzint);
            return szornyek.Where(sz => sz.VeszelyessegiSzint == maxVeszelyesseg).Select(sz => sz.Nev).ToList();
        }

        public IEnumerable<string> MocsariVeszelyesSzornyek()
        {
            return szornyek.Where(sz => sz.Elohely == "Mocsár" && sz.VeszelyessegiSzint >= 5).OrderByDescending(sz => sz.VeszelyessegiSzint).Select(sz => sz.Nev);
        }

        public bool VanExtremTuzGyengeSzorny()
        {
            return szornyek.Any(sz => sz.FoGyengeseg == "Tűz" && sz.VeszelyessegiSzint >= 9);
        }

        public IEnumerable<string> SzornyekSzamaElohelyenkent()
        {
            return szornyek.GroupBy(sz => sz.Elohely).Select(g => $"{g.Key}: {g.Count()}");
        }


    }
}
