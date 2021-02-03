using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CityFLORA
{
    /// <summary>
    /// Interaction logic for _033TopfBearbWin.xaml
    /// </summary>
    public partial class _033TopfBearbWin : Window
    {
        public _033TopfBearbWin()
        {
            InitializeComponent();
        }

        private void SaveCommand(object sender, RoutedEventArgs e)
        {
            
            DialogResult = true;

        }
    }
}
