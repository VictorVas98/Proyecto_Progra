using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Progra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void btningresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaVenta ventana = new VentanaVenta();
            ventana.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VentanaInventario ventanai = new VentanaInventario();
            ventanai.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VentanaClientes ventanac = new VentanaClientes();
            ventanac.Show();
        }

        private void btnuser_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios ventanac = new VentanaUsuarios();
            ventanac.Show();
        }
    }
}
