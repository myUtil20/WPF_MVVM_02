using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_CityFlora.ViewModel
{
    class VMBearbeitePflanzen : INotifyPropertyChanged
    {
        //allle pos incl automat
        public event PropertyChangedEventHandler PropertyChanged;


        //public bool IsInEditMode
        //{
        //    get;
        //    set;
        //}

        public IEnumerable<Pflanzen> AllePflanzen
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    var erg = (from pf in db.Pflanzens.Include("Standort").Include("Kauf").Include("Steckbrief")
                               orderby pf.P_Name
                               select pf).ToList();
                    return erg;
                }
            }
        }

        private Pflanzen selectedPflanze;

        public Pflanzen SelectedPflanze
        {
            get { return selectedPflanze; }
            set
            {
                selectedPflanze = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPflanze"));
                PropertyChanged(this, new PropertyChangedEventArgs("HatSchaden"));
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

        public String HatSchaden
        {
            get
            {
                return SelectedPflanze?.P_Schaedling != null ? "JA" : "NEIN";
            }

        }

        public IEnumerable<Standort> AlleStandortP
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Standorts.ToList();
                }
            }
        }

        public IEnumerable<Kauf> AlleKauf
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Kaufs.ToList();
                }
            }
        }

        public IEnumerable<Steckbrief> AlleSteckbrief
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Steckbriefs.ToList();
                }
            }
        }

        public IEnumerable<Topf> AlleTopf
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Topfs.ToList();
                }
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
            if (SelectedPflanze != null) return true;
            return false;       //graut den Button aus
        }

        public bool CanExecuteNew(object param)
        {
            if (SelectedPflanze != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecute(object param)
        {
            //Delete-Button was pressed
            if (SelectedPflanze != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(SelectedPflanze).State = EntityState.Deleted;
                    db.SaveChanges();

                    PropertyChanged(this, new PropertyChangedEventArgs("AllePflanzen"));     //löscht auch den Datensatz aus der 2. Listbox
                }
            }
        }

        //Neu
        public void NewExecute(object param)
        {
            var v = new VNeuPflanzeW();
            var vm = new VMNeuPflanze();
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
                    PropertyChanged(this, new PropertyChangedEventArgs("AllePflanzen"));
                }
            }
        }

        //Save
        public void SaveExecute(object param)
        {
            if (SelectedPflanze != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(SelectedPflanze).State = EntityState.Modified;
                    db.SaveChanges();                                   //nutzt nix, weil der OR-Mapper noch nie eine Zeile aus der DB gelesen hat
                    PropertyChanged(this, new PropertyChangedEventArgs("AllePflanzen"));     //auch die 2. Listbox soll sich ändern
                }   //wieder built drücken - aber es greift kein SelectedItem, es ist nichts ausgewählt --> besser SelectedValue verwenden
            }
        }
    }
}