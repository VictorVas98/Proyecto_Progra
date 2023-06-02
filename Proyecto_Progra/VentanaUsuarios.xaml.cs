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
    /// Lógica de interacción para VentanaUsuarios.xaml
    /// </summary>
    public partial class VentanaUsuarios : Window
    {
        public VentanaUsuarios()
        {
            InitializeComponent();
            ImprimirDatos();
        }
        public void ImprimirDatos()
        {
            List<Usuarios> user = new List<Usuarios>();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Apellido, Usuario, Contraseña FROM Usuarios";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.Add(new Usuarios()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Usuario = reader.GetString(3),
                        Contraseña = reader.GetString(4)
                    });
                }
            }
            grilla.ItemsSource = user;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NuevoUsuario ventana = new NuevoUsuario();
            ventana.Show();
            ventana.Closed += Ventana_Closed;
        }

        private void Ventana_Closed(object? sender, EventArgs e)
        {
            ImprimirDatos();
        }
        private void btneditar_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Usuarios)grilla.SelectedItem).Id;
            EditarUsuarios editarusuario = new EditarUsuarios(id);
            editarusuario.Closed += Ventana_Closed;
            editarusuario.Show();
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Usuarios)grilla.SelectedItem).Id;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas eliminar el registro?", "Confirmacion de borrado", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult.HasFlag(System.Windows.MessageBoxResult.Yes))
            {
                SqlConnection conexion = new SqlConnection(enlace.CONECCION);
                conexion.Open();
                string consulta = "DELETE From Usuarios WHERE Id=@Id";
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
