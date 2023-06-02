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
    /// Lógica de interacción para EditarUsuarios.xaml
    /// </summary>
    public partial class EditarUsuarios : Window
    {
        int idUsuario = 0;
        public EditarUsuarios(int id)
        {
            InitializeComponent();
            RecuperarUsuarios();
            RecuperarUsuario(id);
            idUsuario = id;
        }
        public void RecuperarUsuarios()
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
                    user.Add(new Usuarios
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Usuario = reader.GetString(3),
                        Contraseña = reader.GetString(4)
                    });
                }
            }
        }
        public void RecuperarUsuario(int idUsuario)
        {
            Usuarios usuario = new Usuarios();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Apellido, Usuario, Contraseña FROM Usuarios WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add(new SqlParameter("Id", idUsuario));
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    usuario = new Usuarios
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Usuario = reader.GetString(3),
                        Contraseña = reader.GetString(4)
                    };
                }
            }

            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtUsuario.Text = usuario.Usuario;
            txtContraseña.Text = usuario.Contraseña;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(enlace.CONECCION);
            con.Open();
            string consulta = "UPDATE Usuarios SET Nombre=@Nombre,Apellido=@Apellido,Usuario=@Usuario,Contraseña=@Contraseña WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.Add(new SqlParameter("Nombre", txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("Apellido", txtApellido.Text));
            comando.Parameters.Add(new SqlParameter("Usuario", txtUsuario.Text));
            comando.Parameters.Add(new SqlParameter("Contraseña", txtContraseña.Text));
            comando.Parameters.Add(new SqlParameter("Id", idUsuario));

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
