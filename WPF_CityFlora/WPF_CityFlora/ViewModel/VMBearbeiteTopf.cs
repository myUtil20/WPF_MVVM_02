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
    class VMBearbeiteTopf : INotifyPropertyChanged
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

        public IEnumerable<Topf> AlleTopfe
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    var erg = (from top in db.Topfs.Include("Standort")
                               orderby top.T_ID
                               select top).ToList();
                    return erg;
                }
            }
        }

        private Topf selectedTopf;

        public Topf SelectedTopf
        {
            get { return selectedTopf; }
            set
            {
                selectedTopf = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTopf"));

            }
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
            if (SelectedTopf != null) return true;
            return false;       //graut den Button aus
        }

        public bool CanExecuteNew(object param)
        {
            if (SelectedTopf != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecute(object param)
        {
            //Delete-Button was pressed
            if (SelectedTopf != null)
            {
                using (FloraEntities db = new FloraEntities())

                {
                    db.Entry(SelectedTopf).State = EntityState.Deleted;
                    db.SaveChanges();

                    PropertyChanged(this, new PropertyChangedEventArgs("AlleTopfe"));     //löscht auch den Datensatz aus der 2. Listbox
                }
            }
        }

        //Neu
        public void NewExecute(object param)
        {

            if (SelectedTopf != null)
            {
                var v = new VNeuTopfW();
                var vm = new VMNeuTopf();
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
                        PropertyChanged(this, new PropertyChangedEventArgs("AlleTopfe"));
                    }
                }
            }
        }

        //Save
        public void SaveExecute(object param)
        {
            if (SelectedTopf != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(SelectedTopf).State = EntityState.Modified;
                    db.SaveChanges();                                   //nutzt nix, weil der OR-Mapper noch nie eine Zeile aus der DB gelesen hat
                    PropertyChanged(this, new PropertyChangedEventArgs("AlleTopfe"));     //auch die 2. Listbox soll sich ändern
                }   //wieder built drücken - aber es greift kein SelectedItem, es ist nichts ausgewählt --> besser SelectedValue verwenden
            }
        }
    }
}
