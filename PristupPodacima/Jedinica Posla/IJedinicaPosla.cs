using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Jedinica_Posla
{
    public interface IJedinicaPosla
    {
        public IKlijentRepozitorijum KlijentRepozitorijum { get; set; }
        public ITrenerRepozitorijum TrenerRepozitorijum { get; set; }
        public IMestoRepozitorijum MestoRepozitorijum { get; set; }
        public IGrupaRepozitorijum GrupaRepozitorijum { get; set; }
        public IObrazovanjeRepozitorijum ObrazovanjeRepozitorijum { get; set; }
        public IPolRepozitorijum PolRepozitorijum { get; set; }



        void SacuvajPromene();
    }
}
