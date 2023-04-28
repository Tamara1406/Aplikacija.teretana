using Domen;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    public class MestoRepozitorijum : IMestoRepozitorijum
    {
        Context context;
        public MestoRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Mesto t)
        {
            context.Mesta.Add(t);
        }

        public void Izmeni(Mesto t)
        {
            context.Mesta.Update(t);
        }

        public void Obrisi(Mesto t)
        {
            context.Mesta.Remove(t);
        }

        public List<Mesto> Pretrazi(string ime)
        {
            return context.Mesta.Where(t => t.Naziv == ime).ToList();
        }

        public Mesto Vrati(int t)
        {
            return context.Mesta.Find(t);   
        }

        public List<Mesto> VratiSve()
        {
            return context.Mesta.ToList();
        }
    }
}
