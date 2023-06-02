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
using System.Windows.Shapes;

namespace Proyecto_Progra
{
    /// <summary>
    /// Lógica de interacción para VentanaClientes.xaml
    /// </summary>
    public partial class VentanaClientes : Window
    {
        public VentanaClientes()
        {
            InitializeComponent();
            ImprimirDatos();
        }
        public void ImprimirDatos()
        {
            List<Clientes> client = new List<Clientes>();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Apellido, NIT, Direccion FROM Clientes";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client.Add(new Clientes()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        NIT = reader.GetInt32(3),
                        Direccion = reader.GetString(4)
                    });
                }
            }
            grilla.ItemsSource = client;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NuevoCliente ventana = new NuevoCliente();
            ventana.Show();
            ventana.Closed += Ventana_Closed;
        }

        private void Ventana_Closed(object? sender, EventArgs e)
        {
            ImprimirDatos();
        }
        private void btneditar_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Clientes)grilla.SelectedItem).Id;
            EditarCliente editarcliente = new EditarCliente(id);
            editarcliente.Closed += Ventana_Closed;
            editarcliente.Show();
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Clientes)grilla.SelectedItem).Id;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas eliminar el registro?", "Confirmacion de borrado", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult.HasFlag(System.Windows.MessageBoxResult.Yes))
            {
                SqlConnection conexion = new SqlConnection(enlace.CONECCION);
                conexion.Open();
                string consulta = "DELETE From Clientes WHERE Id=@Id";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(new SqlParameter("Id", id));

                int resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                {
                    ImprimirDatos();
                }
            }
        }
    }
}
