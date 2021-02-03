using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityFLORA.ViewModel
{
    class VM022OrtTopfList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   //muss man immer haben


        //itemSources
        public IEnumerable<Standort> AlleStandorte
        {
            get
            {
                FloraEntities db = new FloraEntities();         //db verbindung
                var erg = (from stand in db.Standorts          //speicher erg von klassenS (collection) linq
                           orderby stand.SO_Bez
                           select stand).ToList();
                db.Dispose();                                   // schließe/entsorge die Verbindung zu OR Mapper/besser mit dem using wie in der Methode public IEnumerable<stunden> StundenderKlasse
                return erg;                                     // erg = source
            }
        }



        //Instanz
        private Standort gewaehlterStandort;                             //obj erzeugt


        //Methode
        public Standort GewaehlteStandortGui                              //Methode   public string GewaehlteKlasseInGui
        {
            get { return gewaehlterStandort; }
            set
            {
                gewaehlterStandort = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehlteStandortGui"));     //0.Column _sorgt für observable
                PropertyChanged(this, new PropertyChangedEventArgs("TopfStandort"));    //1.Column _sorgt für observable in der mittleren Listbox "Pflanzennamen"
            }
        }



        //Liste aller Pflanzen für die 2. Listbox
        public IEnumerable<Topf> TopfStandort
        {
            get
            {
                if (GewaehlteStandortGui != null)
                {                                         // using Konstrukt führt automatisch db.Dispose() aus !!
                    FloraEntities db = new FloraEntities();
                    var erg = (from t in db.Topfs.Include("Pflanzens")
                               where t.T_Standort == GewaehlteStandortGui.SO_ID
                               //orderby pf.P_Name
                               select t).ToList();


                    GewaehlterTopf =
                           (from t in erg
                            where t.T_Standort == GewaehlteStandortGui?.SO_ID
                            && t.T_ID == GewaehlterTopf?.T_ID
                            select t).FirstOrDefault();
                    db.Dispose();                                                              //besser mit dem using wie in der Methode public IEnumerable<stunden> StundenderKlasse
                    return erg;
                }
                return null;
            }
        }


        //Daten für das Stackpanel basierend auf der Auswahl in der 2. Listbox
        private Topf gewaehlterTopf;                                                      //Pflanzen ist der Datentyp der ItemSource (aus der 2. Listbox)

        public Topf GewaehlterTopf
        {
            get { return gewaehlterTopf; }
            set
            {
                gewaehlterTopf = value;                                                       //bei set muss noch für observable gesorgt werden
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehlterTopf"));        //sorgt für observable
                PropertyChanged(this, new PropertyChangedEventArgs("PlanzeImTopf"));
            }
        }

    

        //Liste aller Schädlinge pro Pflanze für das 2. Stackpanel
        public IEnumerable<Pflanzen> PlanzeImTopf
        {

            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    //int id = 0;
                    if (GewaehlterTopf != null)
                    {
                        //id = GewaehltePflanze.P_ID;
                        var erg = (from p in db.Pflanzens
                                   where p.P_Topf == GewaehlterTopf.T_ID //id
                                   orderby p.P_Name
                                   select p).ToList();
                        return erg;
                    }
                }
                return null;
            }
        }



        //Daten für das 2. Stackpanel basierend auf der Auswahl in der 2. Listbox
        private Pflanzen gewaehltePflanze;                                                      //Pflanzen ist der Datentyp der ItemSource (aus der 2. Listbox)

        public Pflanzen GewaehltePflanze
        {
            get { return gewaehltePflanze; }
            set
            {
                gewaehltePflanze = value;                                                       //bei set muss noch für observable gesorgt werden
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehltePflanze"));        //sorgt für observable
            }
        }




        //BUTTONS:

        //Soll einen Instanz von DelegateCommand.cs sein
        private ICommand saveCommandT;

        //Command für den Save-Button
        public ICommand SaveCommandT
        {
            get
            {
                if (saveCommandT == null)
                    saveCommandT = new DelegateCommand(SaveExecuteT, CanExecuteT);        //es muss mind. 1 Parameter angegeben werden, in unserem Fall die Methode SaveExecute & CanExecute
                return saveCommandT;
            }
        }

        //Command für Delete
        public ICommand DeleteCommandT { get { return new DelegateCommand(DeleteExecuteT, CanExecuteT); } }    //muss noch gesetzt werden

        //Command für New
        public ICommand NewCommandT { get { return new DelegateCommand(NewExecuteT, CanExecuteNewT); } }       //muss noch gesetzt werden


        //Abfrage ob der Button im Moment verwendbar ist. Hier nur performanten Code reinschreiben, nix was lange dauert
        public bool CanExecuteT(object param)
        {
            if (GewaehlterTopf != null) return true;
            return false;       //graut den Button aus
        }

        public bool CanExecuteNewT(object param)

        {
            if (GewaehlteStandortGui != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecuteT(object param)
        {
            //Delete-Button was pressed
            if (GewaehlterTopf != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(GewaehlterTopf).State = EntityState.Deleted;
                    db.SaveChanges();
                    //GewaehlteStunde = null;
                    PropertyChanged(this, new PropertyChangedEventArgs("TopfStandort"));     //GewaehlteStandortGui ???  //löscht auch den Datensatz aus der 2. Listbox
                }
            }
        }

        //Neu
        public void NewExecuteT(object param)
        {

            var v = new _033TopfBearbWin();
            var vm = new VM033TopfBearb();
            vm.To = new Topf();
            vm.IsInEditMode = false;
            v.DataContext = vm;             //  view.DataContext = ViewModel
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Topfs.Add(vm.To);
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("TopfStandort")); //GewaehlteStandortGui ???
                }
            }
        }

        //Save
        public void SaveExecuteT(object param)
        {

            var v = new _033TopfBearbWin();
            var vm = new VM033TopfBearb();
            vm.To = GewaehlterTopf;
            vm.IsInEditMode = true;
            v.DataContext = vm;             //  view.DataContext = ViewModel
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(vm.To).State = EntityState.Modified;
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("TopfStandort"));
                }
            }
        }






        //Pflanze
        private ICommand saveCommand;

        //Command für den Save-Button
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(SaveExecute, CanExecute);        //es muss mind. 1 Parameter angegeben werden, in unserem Fall die Methode SaveExecute & CanExecute
                return saveCommand;
            }
        }

        //Command für Delete
        public ICommand DeleteCommand{ get { return new DelegateCommand(DeleteExecute, CanExecute); } }    //muss noch gesetzt werden

        //Command für New
        public ICommand NewCommand { get { return new DelegateCommand(NewExecute, CanExecuteNew); } }       //muss noch gesetzt werden


        //Abfrage ob der Button im Moment verwendbar ist. Hier nur performanten Code reinschreiben, nix was lange dauert
        public bool CanExecute(object param)
        {
            if (GewaehltePflanze != null) return true;
            return false;       //graut den Button aus
        }

        public bool CanExecuteNew(object param)

        {
            if (GewaehltePflanze != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecute(object param)
        {
            //Delete-Button was pressed
            if (GewaehlterTopf != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(GewaehltePflanze).State = EntityState.Deleted;
                    db.SaveChanges();
                    //GewaehlteStunde = null;
                    PropertyChanged(this, new PropertyChangedEventArgs("PlanzeImTopf"));     //löscht auch den Datensatz aus der 2. Listbox
                }
            }
        }

        //Neu
        public void NewExecute(object param)
        {
            var v = new _03PflanzBearbWin();
            var vm = new VM03PflanzBearb();
            vm.Pflanz = new Pflanzen();
            vm.IsInEditMode = false;
            v.DataContext = vm;             //  view.DataContext = ViewModel
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Pflanzens.Add(vm.Pflanz);
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("PlanzeImTopf"));
                }
            }
        }

        //Save
        public void SaveExecute(object param)
        {
            var v = new _03PflanzBearbWin();
            var vm = new VM03PflanzBearb();
            vm.Pflanz = GewaehltePflanze;
            vm.IsInEditMode = false;
            v.DataContext = vm;             //  view.DataContext = ViewModel
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(vm.Pflanz).State = EntityState.Modified;
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("PlanzeImTopf"));
                }
            }
        }
    }
}