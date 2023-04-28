using PristupPodacima.Repozitorijumi.Implementacija;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Jedinica_Posla
{
    public class JedinicaPosla : IJedinicaPosla
    {

        Context context;

        public JedinicaPosla(Context context)
        {
            this.context = context;
            KlijentRepozitorijum = new KlijentRepozitorijum(context);
            TrenerRepozitorijum = new TrenerRepozitorijum(context);
            GrupaRepozitorijum = new GrupaRepozitorijum(context);
            MestoRepozitorijum = new MestoRepozitorijum(context);
            ObrazovanjeRepozitorijum = new ObrazovanjeRepozitorijum(context);
            PolRepozitorijum = new PolRepozitorijum(context);


        }

        public IKlijentRepozitorijum KlijentRepozitorijum { get; set; }
        public ITrenerRepozitorijum TrenerRepozitorijum { get; set; }
        public IGrupaRepozitorijum GrupaRepozitorijum { get; set; }
        public IMestoRepozitorijum MestoRepozitorijum { get; set; }
        public IObrazovanjeRepozitorijum ObrazovanjeRepozitorijum { get; set; }
        public IPolRepozitorijum PolRepozitorijum { get; set; }

        public void SacuvajPromene()
        {
            context.SaveChanges();
        }
    }
}
