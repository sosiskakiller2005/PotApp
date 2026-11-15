namespace PotApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProductTypeId { get; set; }

    //фото товаров будут харниться в папке wwwroot/images/products, а в базе данных будет храниться путь к фото
    public string? ImagePath { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
    public int BrandId { get; set; }
    public int CountryId { get; set; }
    public int RoastDegreeId { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
    public ICollection<SubscriptionProduct> SubscriptionProducts { get; set; }
}
