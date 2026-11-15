using PotApi.Dtos.ProductDtos;

namespace PotApp.Dtos.ProductDtos
{
    public record GetProductsResponse(List<GetProductResponse> Products);
}
