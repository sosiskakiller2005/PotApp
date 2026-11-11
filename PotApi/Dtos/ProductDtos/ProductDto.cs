namespace PotApp.Dtos.ProductDtos
{
    public record ProductDto(int Id, string Name, int ProductTypeId, string? ImagePath, int? ImageTypeId, decimal Price, decimal Weight);
}
