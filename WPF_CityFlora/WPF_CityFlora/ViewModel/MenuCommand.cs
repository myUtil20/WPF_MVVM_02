using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_CityFlora.ViewModel
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
                case "VPflanzenOrtUndPUC":
                    mw.contentctrl.Children.Add(new VPflanzenOrtUndPUC());
                    break;
                case "VPflanzenTopfUndPUC":
                    mw.contentctrl.Children.Add(new VPflanzenTopfUndPUC());
                    break;
                case "VStandortWoWerUC":
                    mw.contentctrl.Children.Add(new VStandortWoWerUC());
                    break;
                case "VBearbeiteTopfUC":
                    mw.contentctrl.Children.Add(new VBearbeiteTopfUC());
                    break;

                case "VBearbeitePflanzenUC":
                    mw.contentctrl.Children.Add(new VBearbeitePflanzenUC());
                    break;

                    
                case "VBearbeiteSchadUC":
                    mw.contentctrl.Children.Add(new VBearbeiteSchadUC());
                    break;

                case "VStatistikWoWievieleUC":
                    mw.contentctrl.Children.Add(new VStatistikWoWievieleUC());
                    break;

                case "VExtrasOrmW":
                    VExtrasOrmW wa = new VExtrasOrmW();
                    wa.ShowDialog();
                    break;
                default:
                    MessageBox.Show(parameter.ToString() + " - keine Namensübereinstimmung zw. Menüeintrag und Code!");
                    break;
            }
        }
    }
}
