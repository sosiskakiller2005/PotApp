using Microsoft.EntityFrameworkCore;
using PotApp.Data;
using PotApp.Dtos.ProductDtos;
using PotApp.Models;

namespace PotApp.Services
{
    public class ProductService(DataContext context)
    {
        public async Task<GetProductsResponse> GetProductsAsync()
        {
            List<ProductDto> products = await context.Products.Select(p => new ProductDto(p.Id, p.Name, p.ProductTypeId, p.ImagePath, p.ImageTypeId, p.Price, p.Weight)).ToListAsync();
            return new GetProductsResponse(products);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductRequest request)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                ProductTypeId = request.ProductTypeId,
                ImagePath = request.ImagePath,
                ImageTypeId = request.ImageTypeId,
                Price = request.Price,
                Weight = request.Weight
            };
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            return new ProductDto(
                newProduct.Id,
                newProduct.Name,
                newProduct.ProductTypeId,
                newProduct.ImagePath,
                newProduct.ImageTypeId,
                newProduct.Price,
                newProduct.Weight);
        }

        public async Task<bool?> DeleteProductAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await context.Products.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            product.Name = productDto.Name;
            product.ProductTypeId = productDto.ProductTypeId;
            product.ImagePath = productDto.ImagePath;
            product.ImageTypeId = productDto.ImageTypeId;
            product.Price = productDto.Price;
            product.Weight = productDto.Weight;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateProductPartialAsync(int id, UpdateProductRequest productDto)
        {
            var product = await context.Products.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            foreach (var productProperty in product.GetType().GetProperties())
            {
                if (productProperty.Name == nameof(product.Id))
                {
                    continue;
                }

                var dtoProperty = productDto.GetType().GetProperty(productProperty.Name);
                var dtoValue = dtoProperty?.GetValue(productDto);
                if (dtoValue is null)
                {
                    continue;
                }

                var productValue = productProperty.GetValue(product);
                if (!Equals(productValue, dtoValue))
                {
                    productProperty.SetValue(product, dtoValue);
                }
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
