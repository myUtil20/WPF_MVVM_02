using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CityFLORA.ViewModel
{
    class MenuCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindow mw = (MainWindow)Application.Current.MainWindow;

            if (parameter?.ToString() != "WindowInfo")
                mw.contentctrl.Children.Clear();

            switch (parameter.ToString())
            {
                case "_02PflanzenSchadList":
                    mw.contentctrl.Children.Add(new _02PflanzenSchadList());
                    break;
                case "_022OrtTopfList":
                    mw.contentctrl.Children.Add(new _022OrtTopfList());
                    break;
                case "_05Standort":
                    mw.contentctrl.Children.Add(new _05Standort());
                    break;
                case "_06Blumentopf":
                    mw.contentctrl.Children.Add(new _06Blumentopf());
                    break;

                case "_061BearbPflanzen":
                    mw.contentctrl.Children.Add(new _061BearbPflanzen());
                    break;

                    
                case "SchadList":
                    mw.contentctrl.Children.Add(new SchadList());
                    break;

                case "_07Statistik":
                    mw.contentctrl.Children.Add(new _07Statistik());
                    break;

                case "_08Extra":
                    _08Extra wa = new _08Extra();
                    wa.ShowDialog();
                    break;
                default:
                    MessageBox.Show(parameter.ToString() + " - keine Namensübereinstimmung zw. Menüeintrag und Code!");
                    break;
            }
        }
    }
}
