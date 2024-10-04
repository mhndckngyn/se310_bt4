using ASP_MVC.Models.DTO;
using ASP_MVC.Repositories;

namespace ASP_MVC.Services;

public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService(string connectionString)
    {
        _repository = new ProductRepository(connectionString);
    }

    public List<ProductDto> GetAllProducts()
    {
        return _repository.GetProducts();
    }
}