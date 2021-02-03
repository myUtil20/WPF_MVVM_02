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
    class VM02PflanzenSchadList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   //muss man immer haben

        public Schaedling Schad
        {
            get;
            set;
        } 

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
                PropertyChanged(this, new PropertyChangedEventArgs("PflanzeStandort"));    //1.Column _sorgt für observable in der mittleren Listbox "Pflanzennamen"
            }
        }



        //Liste aller Pflanzen für die 2. Listbox
        public IEnumerable<Pflanzen> PflanzeStandort
        {
            get
            {
                if (GewaehlteStandortGui != null)
                {                                         // using Konstrukt führt automatisch db.Dispose() aus !!
                    FloraEntities db = new FloraEntities();
                    var erg = (from pf in db.Pflanzens.Include("Schaedlings")
                               where pf.P_Standort == GewaehlteStandortGui.SO_ID
                               //orderby pf.P_Name
                               select pf).ToList();


                    GewaehltePflanze =
                           (from pf in erg
                            where pf.P_Standort == GewaehlteStandortGui?.SO_ID
                            && pf.P_ID == GewaehltePflanze?.P_ID
                            select pf).FirstOrDefault();
                    db.Dispose();                                                              //besser mit dem using wie in der Methode public IEnumerable<stunden> StundenderKlasse
                    return erg;
                }
                return null;
            }
        }


        //Daten für das Stackpanel basierend auf der Auswahl in der 2. Listbox
        private Pflanzen gewaehltePflanze;                                                      //Pflanzen ist der Datentyp der ItemSource (aus der 2. Listbox)

        public Pflanzen GewaehltePflanze
        {
            get { return gewaehltePflanze; }
            set
            {
                gewaehltePflanze = value;                                                       //bei set muss noch für observable gesorgt werden
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehltePflanze"));        //sorgt für observable
                PropertyChanged(this, new PropertyChangedEventArgs("SchadlingeDerPflanze"));
            }
        }



        //Liste aller Schädlinge pro Pflanze für das 2. Stackpanel
        public IEnumerable<Schaedling> SchadlingeDerPflanze
        {

            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    //int id = 0;
                    if (GewaehltePflanze != null)
                    {
                        //id = GewaehltePflanze.P_ID;
                        var erg = (from sch in db.Schaedlings
                                   where sch.S_P_ID == GewaehltePflanze.P_ID //id
                                   orderby sch.S_Bez
                                   select sch).ToList();

                        GewaehlterSchadling =
                               (from sch in erg
                                where sch.S_P_ID == GewaehltePflanze?.P_ID
                                && sch.S_ID == GewaehlterSchadling?.S_ID
                                select sch).FirstOrDefault();

                        return erg;
                    }
                }
                return null;
            }
        }



        //Daten für das 2. Stackpanel basierend auf der Auswahl in der 2. Listbox
        private Schaedling gewaehlterSchadling;                                                  //= Datentyp der ItemSource (aus der 2. Listbox)

        public Schaedling GewaehlterSchadling
        {
            get { return gewaehlterSchadling; }
            set
            {
                gewaehlterSchadling = value;                                                      //bei set muss noch für observable gesorgt werden
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehlterSchadling"));        //sorgt für observable
            }
        }




        //BUTTONS:

        //Soll einen Instanz von DelegateCommand.cs sein
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
        public ICommand DeleteCommand { get { return new DelegateCommand(DeleteExecute, CanExecute); } }    //muss noch gesetzt werden

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
            if (GewaehlteStandortGui != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecute(object param)
        {
            //Delete-Button was pressed
            if (GewaehltePflanze != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(GewaehltePflanze).State = EntityState.Deleted;
                    db.SaveChanges();
                    //GewaehlteStunde = null;
                    PropertyChanged(this, new PropertyChangedEventArgs("PflanzeStandort"));     //löscht auch den Datensatz aus der 2. Listbox
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
                    PropertyChanged(this, new PropertyChangedEventArgs("PflanzeStandort"));
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
            v.DataContext = vm;            
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(vm.Pflanz).State = EntityState.Modified;
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("PflanzeStandort"));
                }
            }
        }






        //schadling
        private ICommand saveCommandSch;

        //Command für den Save-Button
        public ICommand SaveCommandSch
        {
            get
            {
                if (saveCommandSch == null)
                    saveCommandSch = new DelegateCommand(SaveExecuteSch, CanExecuteSch);        //es muss mind. 1 Parameter angegeben werden, in unserem Fall die Methode SaveExecute & CanExecute
                return saveCommandSch;
            }
        }

        //Command für Delete
        public ICommand DeleteCommandSch { get { return new DelegateCommand(DeleteExecuteSch, CanExecuteSch); } }    //muss noch gesetzt werden

        //Command für New
        public ICommand NewCommandSch { get { return new DelegateCommand(NewExecuteSch, CanExecuteNewSch); } }       //muss noch gesetzt werden


        //Abfrage ob der Button im Moment verwendbar ist. Hier nur performanten Code reinschreiben, nix was lange dauert
        public bool CanExecuteSch(object param)
        {
            if (GewaehltePflanze != null) return true;
            return false;       //graut den Button aus
        }

        public bool CanExecuteNewSch(object param)

        {
            if (GewaehltePflanze != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecuteSch(object param)
        {
            //Delete-Button was pressed
            if (GewaehltePflanze != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(GewaehlterSchadling).State = EntityState.Deleted;
                    db.SaveChanges();
                    //GewaehlteStunde = null;
                    PropertyChanged(this, new PropertyChangedEventArgs("SchadlingeDerPflanze"));     //löscht auch den Datensatz aus der 2. Listbox
                }
            }
        }

        //Neu
        public void NewExecuteSch(object param)
        {
            var v = new _04SchadBearbWin();
            var vm = new VM04SchadBearb();
            vm.Schad = new Schaedling();
            vm.IsInEditMode = false;
            v.DataContext = vm;             //  view.DataContext = ViewModel
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Schaedlings.Add(vm.Schad);
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("SchadlingeDerPflanze"));
                }
            }
        }

        //Save
        public void SaveExecuteSch(object param)
        {
            var v = new _04SchadBearbWin();
            var vm = new VM04SchadBearb();
            vm.Schad = gewaehlterSchadling;
            vm.IsInEditMode = false;
            v.DataContext = vm;             //  view.DataContext = ViewModel
            v.ShowDialog();

            if (v.DialogResult == true)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(vm.Schad).State = EntityState.Modified;
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("GewaehlterSchadling"));
                }
            }
        }
    }
}
