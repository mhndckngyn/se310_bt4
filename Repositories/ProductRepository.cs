using System.Data.SqlClient;
using ASP_MVC.Models.DTO;
using Microsoft.CodeAnalysis.Recommendations;
using Microsoft.Data.SqlClient;

namespace ASP_MVC.Repositories;

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

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "Select Id, ProductCode, ProductName, Picture, UnitPrice from Product";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new ProductDto()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
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
}