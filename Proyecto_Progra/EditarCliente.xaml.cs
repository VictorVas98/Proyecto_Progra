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
    /// Lógica de interacción para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
        int idCliente = 0;

        public EditarCliente(int id)
        {
            InitializeComponent();
            RecuperarClientes();
            RecuperarCliente(id);
            idCliente = id;
        }
        public void RecuperarClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Apellido, NIT, Direccion FROM Clientes";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clientes.Add(new Clientes
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        NIT = reader.GetInt32(3),
                        Direccion = reader.GetString(4)
                    });
                }
            }
        }
        public void RecuperarCliente(int idCliente)
        {
            Clientes cliente = new Clientes();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Apellido, NIT, Direccion FROM Clientes WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add(new SqlParameter("Id", idCliente));
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cliente = new Clientes
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        NIT = reader.GetInt32(3),
                        Direccion = reader.GetString(4)
                    };
                }
            }

            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtNIT.Text = cliente.NIT.ToString();
            txtDireccion.Text = cliente.Direccion;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(enlace.CONECCION);
            con.Open();
            string consulta = "UPDATE Clientes SET Nombre=@Nombre,Apellido=@Apellido,NIT=@NIT, Direccion=@Direccion WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.Add(new SqlParameter("Nombre", txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("Apellido", txtApellido.Text));
            comando.Parameters.Add(new SqlParameter("NIT", txtNIT.Text));
            comando.Parameters.Add(new SqlParameter("Direccion", txtDireccion.Text));
            comando.Parameters.Add(new SqlParameter("Id", idCliente));

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
