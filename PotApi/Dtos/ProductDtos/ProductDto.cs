namespace PotApp.Dtos.ProductDtos
{
    public record ProductDto(int Id, string Name, string Description, int ProductTypeId, string? ImagePath, decimal Price, decimal Weight, int BrandId, int CountryId, int RoastDegreeId);
}
