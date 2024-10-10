using ASP_MVC.Models.DTO;
using Npgsql;

namespace ASP_MVC.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ProductDto> GetProducts()
        {
            var products = new List<ProductDto>();

            using (var connection = new NpgsqlConnection(_connectionString)) // Use NpgsqlConnection
            {
                connection.Open();
                string query = "SELECT Id, CatalogId, ProductCode, ProductName, Picture, UnitPrice FROM Product";

                using (var command = new NpgsqlCommand(query, connection)) // Use NpgsqlCommand
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new ProductDto()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CatalogId = Convert.ToInt32(reader["CatalogId"]),
                                ProductCode = reader["ProductCode"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Picture = reader["Picture"].ToString(),
                                UnitPrice = Convert.ToSingle(reader["UnitPrice"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void DeleteProduct(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Product WHERE Id = @Id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}