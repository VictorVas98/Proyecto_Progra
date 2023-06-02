using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    /// Lógica de interacción para VentanaVenta.xaml
    /// </summary>
    public partial class VentanaVenta : Window
    {
        public VentanaVenta()
        {
            InitializeComponent();
            RecuperarJuegos();
        }


        public void RecuperarJuegos()
        {
            List<Inventario> juegos = new List<Inventario>();
            SqlConnection conexion = new SqlConnection(enlace.CONECCION);
            conexion.Open();
            string consulta = "SELECT Id, Nombre, Cantidad, Precio FROM Inventario";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    juegos.Add(new Inventario
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Cantidad = reader.GetInt32(2),
                        Precio = reader.GetDecimal(3)

                    });
                }
            }
            cb.ItemsSource = juegos;
        }

        private void cb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cb.SelectedItem != null)
            {
                Inventario juegoSeleccionado = (Inventario)cb.SelectedItem;
                txtPrecio.Text = juegoSeleccionado.Precio.ToString();
                txtCantidadActual.Text = juegoSeleccionado.Cantidad.ToString();
            }
        }
        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(txtCantidad.Text, out decimal cantidad) && decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                    decimal total = cantidad * precio;
                    txtTotal.Text = total.ToString();
            }
        }

        private void btnVender_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedItem != null)
            {
                Inventario juegoSeleccionado = (Inventario)cb.SelectedItem;
                int cantidadVenta;

                if (int.TryParse(txtCantidad.Text, out cantidadVenta))
                {
                    if (cantidadVenta <= juegoSeleccionado.Cantidad)
                    {
                        juegoSeleccionado.Cantidad -= cantidadVenta;

                        using (SqlConnection conexion = new SqlConnection(enlace.CONECCION))
                        {
                            conexion.Open();
                            string consulta = "UPDATE Inventario SET Cantidad = @NuevaCantidad WHERE Id = @Id";
                            SqlCommand cmdActualizarCant = new SqlCommand(consulta, conexion);
                            cmdActualizarCant.Parameters.AddWithValue("@NuevaCantidad", juegoSeleccionado.Cantidad);
                            cmdActualizarCant.Parameters.AddWithValue("@Id", juegoSeleccionado.Id);
                            cmdActualizarCant.ExecuteNonQuery();
                        }
                        cb.Items.Refresh();
                        txtCantidad.Text = "";
                        MessageBox.Show("Venta realizada.");
                    }
                        else
                            {
                                MessageBox.Show("No hay existencias suficientes para vender.");
                            }
                }
                    else
                        {
                            MessageBox.Show("Ingrese una cantidad válida.");
                        }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
