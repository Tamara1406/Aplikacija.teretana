using Domen;
using Microsoft.EntityFrameworkCore;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    public class KlijentRepozitorijum : IKlijentRepozitorijum
    {
        private Context context;

        public KlijentRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Klijent t)
        {
            context.Klijenti.Add(t);
        }

        public void Izmeni(Klijent t)
        {
            context.Klijenti.Update(t);
        }

        public void Obrisi(Klijent t)
        {
            context.Klijenti.Remove(t);
        }

        public List<Klijent> Pretrazi(string ime)
        {
            if (ime == "" || ime == null)
                return context.Klijenti.Include(k => k.Pol).Include(k => k.Grupa).ToList();
            return context.Klijenti.Include(k => k.Pol).Include(k => k.Grupa).ToList().Where(k => k.ImePrezime.Trim().ToLower().StartsWith(ime.Trim().ToLower())).ToList();
        }

        public Klijent Vrati(int id)
        {
            return context.Klijenti.Single(k => k.KlijentID == id);
        }

        

        public List<Klijent> VratiSve()
        {
            return context.Klijenti.Include(k => k.Pol).Include(k => k.Grupa).ToList();
        }
    }
}
