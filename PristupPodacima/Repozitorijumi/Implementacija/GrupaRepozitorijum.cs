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
    public class GrupaRepozitorijum : IGrupaRepozitorijum
    {
        Context context;
        public GrupaRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Grupa t)
        {
            context.Grupe.Add(t);
        }

        public void Izmeni(Grupa t)
        {
            context.Grupe.Update(t);
        }

        public void Obrisi(Grupa t)
        {
            context.Grupe.Remove(t);
        }

        public List<Grupa> Pretrazi(string mesto)
        {
            return context.Grupe.Where(t => t.Mesto.Naziv == mesto).ToList();
        }

        public Grupa Vrati(int t)
        {
            return context.Grupe.Find(t);
        }

        public List<Grupa> VratiSve()
        {
            return context.Grupe.Include(t => t.Trener).Include(t => t.Mesto).ToList();
        }
    }
}
