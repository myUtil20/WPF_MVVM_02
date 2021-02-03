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
    /// Interaction logic for _04SchadBearbWin.xaml
    /// </summary>
    public partial class _04SchadBearbWin : Window
    {
        public _04SchadBearbWin()
        {
            InitializeComponent();
        }
        private void SaveCommand(object sender, RoutedEventArgs e)
        {
            // dies ist leider notwenig um die DialogBox mit OK zu schliessen
            DialogResult = true;

        }

    }


}
