using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityFLORA.ViewModel
{
    class VM03PflanzBearb : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Pflanzen Pflanz
        {
            get;
            set;
        }


        public bool IsInEditMode
        {
            get;
            set;
        }

        public IEnumerable<Topf> AlleTopf
        {
            get {
                using (FloraEntities db = new FloraEntities()) {
                    return db.Topfs.ToList();
                }
            }
        }
        public IEnumerable<Standort> AlleStandortPf
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Standorts.ToList();
                }
            }
        }


        public String HatSchaden
        {
            get
            {
                return Pflanz.P_Schaedling != null? "JA" : "NEIN";
            }

        }

        public IEnumerable<Schaedling> AlleSchadlingePf
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Schaedlings.ToList();
                }
            }
        }

    }
}
