namespace PotApi.Dtos.ProductDtos
{
    public record GetProductResponse(int Id, string Name, string Description, string ProductType, string? ImagePath, decimal Price, decimal Weight, string Brand, string Country, string RoastDegree);

}
