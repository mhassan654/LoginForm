using System.Data.SqlClient;

namespace LoginForm.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=MVVMLoginDb;Integrated Security=True;";

            ///this kind of connection below does not work
           // _connectionString = "Server=localhost\\MSSQLSERVER01;Database=MVVMLoginDb;Integrated Security=True";
        }

        protected SqlConnection getConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}