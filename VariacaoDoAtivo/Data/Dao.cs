using Microsoft.Data.SqlClient;

namespace VariacaoDoAtivo.Data
{
    public class Dao
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public Dao(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public System.Data.IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
