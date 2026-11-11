namespace PotApp.Dtos.ProductDtos
{
    public record CreateProductRequest(string Name, int ProductTypeId, string? ImagePath, int? ImageTypeId, decimal Price, decimal Weight);
}
