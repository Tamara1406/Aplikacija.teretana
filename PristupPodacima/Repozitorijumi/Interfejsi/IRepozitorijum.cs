using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    public interface IRepozitorijum<T> where T : class
    {
        void Dodaj(T t);
        void Obrisi(T t);
        void Izmeni(T t);
        List<T> VratiSve();
        T Vrati(int t);
        List<T> Pretrazi(string kriterijum);


    }
}
