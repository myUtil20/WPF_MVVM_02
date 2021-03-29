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

namespace WPF_CityFlora
{
    /// <summary>
    /// Interaction logic for VNeuSchadW.xaml
    /// </summary>
    public partial class VNeuSchadW : Window
    {
        public VNeuSchadW()
        {
            InitializeComponent();
        }
        private void SaveCommand(object sender, RoutedEventArgs e)
        {

            DialogResult = true;

        }
    }
}
