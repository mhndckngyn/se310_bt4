using ASP_MVC.Models.DTO;
using Npgsql; // Use Npgsql for PostgreSQL

namespace ASP_MVC.Repositories
{
    public class CatalogRepository
    {
        private readonly string _connectionString;

        public CatalogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public List<CatalogDto> GetCatalogs()
        {
            var catalogs = new List<CatalogDto>();
            
            using (var connection = new NpgsqlConnection(_connectionString)) // Use NpgsqlConnection
            {
                connection.Open();
                string query = "SELECT Id, CatalogCode, CatalogName FROM Catalog";

                using (var command = new NpgsqlCommand(query, connection)) // Use NpgsqlCommand
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var catalog = new CatalogDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CatalogCode = reader["CatalogCode"].ToString(),
                                CatalogName = reader["CatalogName"].ToString()
                            };

                            catalogs.Add(catalog);
                        }
                    }
                }
            }

            return catalogs;
        }

        public void DeleteCatalog(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString)) // Use NpgsqlConnection
            {
                connection.Open();
                string query = "DELETE FROM Catalog WHERE Id = @Id";
                using (var command = new NpgsqlCommand(query, connection)) // Use NpgsqlCommand
                {
                    command.Parameters.AddWithValue("@Id", id); // Parameter name remains the same
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
