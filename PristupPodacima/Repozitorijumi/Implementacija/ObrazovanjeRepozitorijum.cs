using Domen;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    public class ObrazovanjeRepozitorijum : IObrazovanjeRepozitorijum
    {
        Context context;
        public ObrazovanjeRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Obrazovanje t)
        {
            context.Obrazovanja.Add(t);
        }

        public void Izmeni(Obrazovanje t)
        {
            context.Obrazovanja.Update(t);
        }

        public void Obrisi(Obrazovanje t)
        {
            context.Obrazovanja.Remove(t);
        }

        public List<Obrazovanje> Pretrazi(string kriterijum)
        {
            return context.Obrazovanja.Where(t => t.StepenObrazovanja == kriterijum).ToList();
        }

        public Obrazovanje Vrati(int t)
        {
            return context.Obrazovanja.Find(t);
        }

        public List<Obrazovanje> VratiSve()
        {
            return context.Obrazovanja.ToList();
        }
    }
}
