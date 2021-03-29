using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CityFlora.ViewModel
{
    class VMNeuTopf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Topf To
        {
            get;
            set;
        }
        public bool IsInEditMode
        {
            get;
            set;
        }

        public IEnumerable<Standort> AlleStandortT
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Standorts.ToList();
                }
            }
        }



    }
}