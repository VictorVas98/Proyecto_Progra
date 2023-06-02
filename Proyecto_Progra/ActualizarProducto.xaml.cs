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
    /// Lógica de interacción para EditarProducto.xaml
    /// </summary>
    public partial class EditarProducto : Window
    {
        int idInventario = 0;
        public EditarProducto(int id)

        {
            InitializeComponent();
            RecuperarProductos();
            RecuperarProducto(id);
            idInventario = id;

        }
        public void RecuperarProductos()
        {
            List<Inventario> inventarios = new List<Inventario>();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Cantidad, Precio, Marca FROM Inventario";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    inventarios.Add(new Inventario
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Cantidad = reader.GetInt32(2),
                        Precio = reader.GetDecimal(3),
                        Marca = reader.GetString(4)
                    });
                }
            }
        }
        public void RecuperarProducto(int idInventario)
        {
            Inventario inventario = new Inventario();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Cantidad, Precio, Marca FROM Inventario WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add(new SqlParameter("Id", idInventario));
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    inventario = new Inventario
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Cantidad = reader.GetInt32(2),
                        Precio = reader.GetDecimal(3),
                        Marca = reader.GetString(4)
                    };
                }
            }

            txtNombre.Text = inventario.Nombre;
            txtCantidad.Text = inventario.Cantidad.ToString();
            txtPrecio.Text = inventario.Precio.ToString();
            txtMarca.Text = inventario.Marca;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(enlace.CONECCION);
            con.Open();
            string consulta = "UPDATE Inventario SET Nombre=@Nombre,Cantidad=@Cantidad,Precio=@Precio, Marca=@Marca WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.Add(new SqlParameter("Nombre", txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("Cantidad", txtCantidad.Text));
            comando.Parameters.Add(new SqlParameter("Precio", txtPrecio.Text));
            comando.Parameters.Add(new SqlParameter("Marca", txtMarca.Text));
            comando.Parameters.Add(new SqlParameter("Id", idInventario));

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
