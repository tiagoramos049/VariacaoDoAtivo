using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using VariacaoDoAtivo.Data;
using VariacaoDoAtivo.Interfaces;
using VariacaoDoAtivo.Models;

namespace VariacaoDoAtivo.Repository
{
    public class VariacaoAtivoRepository : IVariacao
    {
        private readonly Dao _dao;
        public VariacaoAtivoRepository(Dao dao)
        {
            _dao = dao;
        }
        public IEnumerable<Meta> GetAll()
        {
            using (IDbConnection dbConnection = _dao.Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Meta>("SELECT TOP 30 * FROM Meta ORDER BY Date DESC;");
            }
        }

        public void Insert(Meta meta)
        {
            try
            {
                using (IDbConnection dbConnection = _dao.Connection)
                {
                    dbConnection.Open();
                    dbConnection.Execute("INSERT INTO Meta (regularMarketPrice, dataGranularity, firstTradeDate) VALUES (@regularMarketPrice, @dataGranularity, @firstTradeDate)", meta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
