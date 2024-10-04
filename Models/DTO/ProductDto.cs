namespace ASP_MVC.Models.DTO;

public class ProductDto
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string Picture { get; set; } = null!;
    public float UnitPrice { get; set; }
}