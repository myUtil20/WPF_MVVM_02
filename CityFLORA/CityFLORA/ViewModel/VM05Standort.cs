using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityFLORA.ViewModel
{
    class VM05Standort : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Liste aller Siedlungen für die ComboBox
        public IEnumerable<Standort> AlleOrte
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Standorts.ToList();
                }
            }
        }

        //gewählte Siedlung im Datagrid anzeigen
        private Standort gewaehlterOrt;

        public Standort GewaehlterOrt
        {
            get { return gewaehlterOrt; }
            set
            {
                gewaehlterOrt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehlterOrt"));      //sorgt für observable
                PropertyChanged(this, new PropertyChangedEventArgs("AllePflanzenDesStandortes"));
            }
        }



        //Daten für das Datagrid je nach gewählter Siedlung
        public IEnumerable<Pflanzen> AllePflanzenDesStandortes
        {
            get
            {
                if (GewaehlterOrt != null)
                {                                         // using Konstrukt führt automatisch db.Dispose() aus !!
                    FloraEntities db = new FloraEntities();
                    var erg = (from pf in db.Pflanzens  //.Include("Schaedlings")
                               where pf.P_Standort == GewaehlterOrt.SO_ID
                               //orderby pf.P_Name
                               select pf).ToList();


                    //SelectedPflanze =
                    //       (from pf in erg
                    //        where pf.P_Standort == GewaehlterOrt?.SO_ID
                    //        && pf.P_ID == SelectedPflanze?.P_ID
                    //        select pf).FirstOrDefault();
                    db.Dispose();                                                              //besser mit dem using wie in der Methode public IEnumerable<stunden> StundenderKlasse
                    return erg;
                }
                return null;
            }
        }

        //public IEnumerable<Pflanzen> AllePflanzenDesStandortes
        //{
        //    get
        //    {
        //        using (FloraEntities db = new FloraEntities())
        //        {
        //            return db.Pflanzens.ToList();
        //        }
        //    }
        //}

        //private Pflanzen selectedPflanze;

        //public Pflanzen SelectedPflanze
        //{
        //    get { return selectedPflanze; }
        //    set
        //    {
        //        selectedPflanze = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs("AllePflanzenDesStandortes"));      //sorgt für observable
        //    }
        //}
    }
}
