namespace PotApp.Dtos.ProductDtos
{
    public record UpdateProductRequest(string? Name, int? ProductTypeId, string? ImagePath, int? ImageTypeId, decimal? Price, decimal? Weight);
}
