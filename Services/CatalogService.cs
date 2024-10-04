using ASP_MVC.Models.DTO;
using ASP_MVC.Repositories;

namespace ASP_MVC.Services;

public class CatalogService
{
    private readonly CatalogRepository _repository;

    public CatalogService(string connectionString)
    {
        _repository = new CatalogRepository(connectionString);
    }

    public List<CatalogDto> GetAllCatalogs()
    {
        return _repository.GetCatalogs();
    }

    public void DeleteCatalog(int id)
    {
        _repository.DeleteCatalog(id);
    }
}
