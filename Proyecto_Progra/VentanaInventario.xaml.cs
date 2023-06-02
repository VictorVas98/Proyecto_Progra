using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para VentanaInventario.xaml
    /// </summary>
    public partial class VentanaInventario : Window
    {
        public VentanaInventario()
        {
            InitializeComponent();
            ImprimirDatos();
        }
        public void ImprimirDatos()
        {
            List<Inventario> invent = new List<Inventario>();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Cantidad, Precio, Marca FROM Inventario";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    invent.Add(new Inventario()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Cantidad = reader.GetInt32(2),
                        Precio = reader.GetDecimal(3),
                        Marca = reader.GetString(4)
                    });
                }
            }
            grilla.ItemsSource = invent;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NuevoProducto ventana = new NuevoProducto();
            ventana.Show();
            ventana.Closed += Ventana_Closed;
        }

        private void Ventana_Closed(object? sender, EventArgs e)
        {
            ImprimirDatos();
        }

        private void btneditar_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Inventario)grilla.SelectedItem).Id;
            EditarProducto editarProducto = new EditarProducto(id);
            editarProducto.Closed += Ventana_Closed;
            editarProducto.Show();
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Inventario)grilla.SelectedItem).Id;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas eliminar el registro?", "Confirmacion de borrado", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult.HasFlag(System.Windows.MessageBoxResult.Yes))
            {
                SqlConnection conexion = new SqlConnection(enlace.CONECCION);
                conexion.Open();
                string consulta = "DELETE From Inventario WHERE Id=@Id";
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
