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
    /// Lógica de interacción para NuevoProducto.xaml
    /// </summary>
    public partial class NuevoCliente : Window
    {
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "INSERT INTO Clientes (Nombre, Apellido, NIT, Direccion) VALUES (@Nombre, @Apellido, @NIT, @Direccion)";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add(new SqlParameter("Nombre", txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("Apellido", txtApellido.Text));
            comando.Parameters.Add(new SqlParameter("NIT", txtNIT.Text));
            comando.Parameters.Add(new SqlParameter("Direccion", txtDireccion.Text));

            int resultado = comando.ExecuteNonQuery();

            if (resultado > 0)
            {
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
