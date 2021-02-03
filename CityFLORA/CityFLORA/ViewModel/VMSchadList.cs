﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityFLORA.ViewModel
{
    class VMSchadList : INotifyPropertyChanged
    {
        //allle pos incl automat
        public event PropertyChangedEventHandler PropertyChanged;



        public IEnumerable<Schaedling> AlleSchadlinge
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    var erg = (from s in db.Schaedlings
                               orderby s.S_ID
                               select s).ToList();
                    return erg;
                }
            }
        }

        private Schaedling selectedSchad;

        public Schaedling SelectedSchad
        {
            get { return selectedSchad; }
            set
            {
                selectedSchad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedSchad"));
               
            }
        }

        public IEnumerable<Pflanzen> AllePflanzen
        {
            get
            {
                using (FloraEntities db = new FloraEntities())
                {
                    return db.Pflanzens.ToList();
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
            if (SelectedSchad != null) return true;
            return false;       //graut den Button aus
        }

        public bool CanExecuteNew(object param)
        {
            if (SelectedSchad != null) return true;
            return false;       //graut den Button aus
        }

        //Löschen
        public void DeleteExecute(object param)
        {
            //Delete-Button was pressed
            if (SelectedSchad != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(SelectedSchad).State = EntityState.Deleted;
                    db.SaveChanges();

                    PropertyChanged(this, new PropertyChangedEventArgs("AlleSchadlinge"));     //löscht auch den Datensatz aus der 2. Listbox
                }
            }
        }

        //Neu
        public void NewExecute(object param)
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
                    PropertyChanged(this, new PropertyChangedEventArgs("AlleSchadlinge"));
                }
            }
        }

        //Save
        public void SaveExecute(object param)
        {
            if (SelectedSchad != null)
            {
                using (FloraEntities db = new FloraEntities())
                {
                    db.Entry(SelectedSchad).State = EntityState.Modified;
                    db.SaveChanges();                                   //nutzt nix, weil der OR-Mapper noch nie eine Zeile aus der DB gelesen hat
                    PropertyChanged(this, new PropertyChangedEventArgs("AlleSchadlinge"));     //auch die 2. Listbox soll sich ändern
                }   //wieder built drücken - aber es greift kein SelectedItem, es ist nichts ausgewählt --> besser SelectedValue verwenden
            }
        }
    }
}