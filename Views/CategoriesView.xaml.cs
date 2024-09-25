using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using LoginForm.Models;
using LoginForm.ViewModels;
using LoginForm.Views.Modals;
using MaterialDesignThemes.Wpf;

namespace LoginForm.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        CategoryViewModel viewModel = new CategoryViewModel();

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
            var list = viewModel.GetAll;

            MyConn();           
            string query = "SELECT * FROM Categories";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            using (adapter)
            {
                DataTable categoriesTable = new();
                adapter.Fill(categoriesTable);

                // dgCategories.DisplayMemberPath = "Name";
                // dgCategories.SelectedValuePath = "Id";
                //
                // dgCategories.ItemsSource = categoriesTable.Rows.Count > 0 ? categoriesTable.DefaultView : null;
            }
            // cmd = new SqlCommand(query, conn);
            //{
            //    CommandType = CommandType.Text
            //};
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);



            //conn.Close();
        }

        private void CreateNewCategory_OnClick(object sender, RoutedEventArgs e)
        {
            CreateCategory createCategory = new CreateCategory();
            bool? result = createCategory.ShowDialog();
            if (result==true)
            {
     
     
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ready to edit");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to delete?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // var selected = dgCategories.SelectedValue;
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("canceled");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        private void dgCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("selected");
        }
    }
}
