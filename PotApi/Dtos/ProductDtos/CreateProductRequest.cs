namespace PotApp.Dtos.ProductDtos
{
    public record CreateProductRequest(string Name, string Description, int ProductTypeId, string? ImagePath, decimal Price, decimal Weight);
}
