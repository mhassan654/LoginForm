using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginForm.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public CategoriesView()
        {
            InitializeComponent();
            GetData();
        }

        public void MyConn()
        {
            String Conn = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=MVVMLoginDb;Integrated Security=True;";
            conn = new SqlConnection(Conn);
            conn.Open();
        }

        private void GetData()
        {
            MyConn();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Categories", conn)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgCategories.ItemsSource = dt.DefaultView;
            }
            else
            {
                dgCategories.ItemsSource = null;
            }

            conn.Close();
        }
    }
}
