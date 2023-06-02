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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(enlace.CONECCION);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string consulta = "SELECT * FROM Usuarios where Usuario = '"+usurtext.Text+"' and Contraseña='"+context.Password+"'";
            SqlCommand cmd = new SqlCommand(consulta,con);
            SqlDataReader lector;
            lector = cmd.ExecuteReader();
            if (lector.HasRows == true)
            {
                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
