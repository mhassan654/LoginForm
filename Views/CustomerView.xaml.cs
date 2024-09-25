using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace LoginForm.Views
{
    public partial class CustomerView : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public CustomerView()
        {
            InitializeComponent();
        }
    }
}