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
    public class TrenerRepozitorijum : ITrenerRepozitorijum
    {
        Context context;
        public TrenerRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Trener t)
        {
            context.Treneri.Add(t);
        }

        public void Izmeni(Trener t)
        {
            context.Treneri.Update(t);
        }

        public void Obrisi(Trener t)
        {
            context.Treneri.Remove(t);
        }

        public List<Trener> Pretrazi(string ime)
        {
            return context.Treneri.Where(t => t.ImePrezime == ime).ToList();
        }

        public Trener Vrati(int id)
        {
            return context.Treneri.Single(t => t.TrenerID == id);
        }

        public List<Trener> VratiSve()
        {
            return context.Treneri.Include(t => t.Obrazovanje).ToList();
        }
    }
}
