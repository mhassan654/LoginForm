using Microsoft.Win32;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LoginForm.Views.Modals
{
    public partial class CreateCategory : Window
    {
        SqlConnection conn=new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public CreateCategory()
        {
            InitializeComponent();
            BindCategory();
        }
        
        private void PnlControlPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();
        }

      

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text == null || txtName.Text.Trim() == "")
                {
                    //if amount textbox is null or blank it will show the below message box
                    MessageBox.Show("Please Enter category name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    //after clicking on message box ok sets the focus on amount txtbox
                    txtName.Focus();
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure want to save ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
                    {
                        MyConn();

                        cmd = new SqlCommand("INSERT INTO Categories(Name,ParentId) VALUES(@Name,@parentCategory)", conn)
                        {
                            CommandType = CommandType.Text
                        };
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        if (parentCategory.Text != "0")
                        {
                            cmd.Parameters.AddWithValue("@parentCategory", 1);
                        }

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        DialogResult = false;
                    }
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClearControls();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtName.Text = string.Empty;           
            txtName.Focus();
        }

        public void MyConn()
        {
            String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(Conn);
            conn.Open();
        }

        private OpenFileDialog GetOpenDialog()
        {
            return new OpenFileDialog
            {
                Filter = "Image files|*.bmp;*.jpg;*.png",
                FilterIndex = 1
            };
        }

        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a Catgeory Image";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imagePicture.Source = new BitmapImage(fileUri);
            }
        }

        private void BindCategory()
        {
            MyConn();

            DataTable dt = new DataTable();

            cmd = new SqlCommand("SELECT Id,Name FROM Categories", conn)
            {
                CommandType = CommandType.Text
            };

            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { 
                da.Fill(dt);
            }

            DataRow  newRow= dt.NewRow();

            //assign a value to id column
            newRow["Id"] = 0;

            // assign value to category name column
            newRow["Name"] = "--SELECT--";

            dt.Rows.InsertAt(newRow,0);

            if (dt !=null && dt.Rows.Count>0)
            {
                parentCategory.ItemsSource = dt.DefaultView;
            }
            conn.Close();

            parentCategory.DisplayMemberPath = "Name";
            parentCategory.SelectedValuePath = "Id";
            parentCategory.SelectedIndex = 0;

        }
    }
}