using System.ComponentModel.DataAnnotations.Schema;

namespace PotApp.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int TypeId { get; set; }

    //фото товаров будут харниться в папке wwwroot/images/products, а в базе данных будет храниться путь к фото

    public string? ImagePath { get; set; }

    public int? ImageTypeId { get; set; }


    public decimal Price { get; set; }

    public decimal Weight { get; set; }
}
