using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CityFlora.ViewModel
{
    class VMNeuSchad : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Schaedling Schad
        {
            get;
            set;
        }
        public bool IsInEditMode
        {
            get;
            set;
        }

        public IEnumerable<Schaedling> AlleSchadlinge
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
