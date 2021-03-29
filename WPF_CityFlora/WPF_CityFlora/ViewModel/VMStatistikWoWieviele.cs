using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CityFlora.ViewModel
{
    class VMStatistikWoWieviele
    {
        public IEnumerable<OrtStati> ortStatiList
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    var erg = (from l in db.Standorts
                               orderby l.Pflanzens.Count
                               select new OrtStati
                               {
                                   ID = l.SO_ID,
                                   Bez = l.SO_Bez,
                                   PflazenZahl = l.Pflanzens.Count,
                                   Breite = l.Pflanzens.Count() * 20              // Breite als Hilfswert für die Balkendarstellung
                               }).ToList();

                    return erg;
                }
            }


            //var db = new FloraEntities();

            //llstat.ItemsSource =
            //   (from l in db.Standorts
            //    orderby l.Pflanzens.Count
            //    select new Pflstat
            //    {
            //        ID = l.SO_ID,
            //        Bez = l.SO_Bez,
            //        PflazenZahl = l.Pflanzens.Count,
            //        Breite = l.Pflanzens.Count() * 20              // Breite als Hilfswert für die Balkendarstellung
            //    }).ToList();
        }

        // helper class for the return value
        public class OrtStati
        {
            public int ID { get; set; }
            public String Bez { get; set; }
            public int PflazenZahl { get; set; }
            public int Breite { get; set; }
        }
    }
}