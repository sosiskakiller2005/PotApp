namespace PotApp.Dtos.ProductDtos
{
    public record UpdateProductRequest(string? Name, string? Description, int? ProductTypeId, string? ImagePath, decimal? Price, decimal? Weight);
}
