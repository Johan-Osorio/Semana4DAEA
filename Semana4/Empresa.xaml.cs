using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Semana4
{
    public partial class Empresa : Window
    {
        private DataTable productosTable;
        private DataTable categoriasTable;

        public Empresa()
        {
            InitializeComponent();
            productosTable = new DataTable();
            categoriasTable = new DataTable();
        }

        private void ButtonProductos_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS; Initial Catalog=NeptunoDB;User Id=johanom; Password=123456;";
            string uspProductos = "USP_ListarProductos";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(uspProductos, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(productosTable);
                }

                dgProductos.ItemsSource = productosTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ButtonCategorias_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS; Initial Catalog=NeptunoDB;User Id=johanom; Password=123456;";
            string uspCategorias = "USP_ListarCategorias";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(uspCategorias, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(categoriasTable);
                }

                dgCategorias.ItemsSource = categoriasTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

}
