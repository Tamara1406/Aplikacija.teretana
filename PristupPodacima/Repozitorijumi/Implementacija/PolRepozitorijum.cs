using Domen;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    internal class PolRepozitorijum : IPolRepozitorijum
    {
        Context context;
        public PolRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Pol t)
        {
            throw new NotImplementedException();
        }

        public void Izmeni(Pol t)
        {
            throw new NotImplementedException();
        }

        public void Obrisi(Pol t)
        {
            throw new NotImplementedException();
        }

        public List<Pol> Pretrazi(string kriterijum)
        {
            throw new NotImplementedException();
        }

        public Pol Vrati(int t)
        {
            throw new NotImplementedException();
        }

        public List<Pol> VratiSve()
        {
            return context.Pol.ToList();
        }
    }
}
