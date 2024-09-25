using System.Configuration;
using System.Data.SqlClient;

namespace LoginForm.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        protected POSDbDataDataContext DataContext { get; private set; }

        public BaseRepository()
        {

            //_connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //_connectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=MVVMLoginDb;Integrated Security=True;";
             _connectionString = ConfigurationManager.ConnectionStrings["LoginForm.Properties.Settings.MVVMLoginDbConnectionString1"].ConnectionString;
            DataContext = new POSDbDataDataContext(_connectionString);

            ///this kind of connection below does not work
           // _connectionString = "Server=localhost\\MSSQLSERVER01;Database=MVVMLoginDb;Integrated Security=True";
        }

        protected SqlConnection getConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}