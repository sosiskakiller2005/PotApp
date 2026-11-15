using Microsoft.EntityFrameworkCore;
using PotApi.Dtos.ProductDtos;
using PotApp.Data;
using PotApp.Dtos.ProductDtos;
using PotApp.Models;

namespace PotApp.Services
{
    public class ProductService(DataContext context)
    {
        public async Task<GetProductsResponse> GetProductsAsync()
        {
            var products = await (
            from p in context.Products
            join type in context.ProductTypes on p.ProductTypeId equals type.Id
            join brand in context.Brands on p.BrandId equals brand.Id
            join country in context.Countries on p.CountryId equals country.Id
            join roast in context.RoastDegrees on p.RoastDegreeId equals roast.Id
            select new GetProductResponse(
                p.Id,
                p.Name,
                p.Description,
                type.Name,
                p.ImagePath,
                p.Price,
                p.Weight,
                brand.Name,
                country.Name,
                roast.Name
                )
             ).ToListAsync();
            return new GetProductsResponse(products);
        }

        public async Task<GetProductResponse?> GetProductByIdAsync(int id)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product is null)
            {
                return null;
            }

            GetProductResponse response = new GetProductResponse(
                product.Id, 
                product.Name,
                product.Description,
                context.ProductTypes.FindAsync(product.ProductTypeId).ToString(),
                product.ImagePath,
                product.Price,
                product.Weight,
                context.Brands.FindAsync(product.BrandId).ToString(),
                context.Countries.FindAsync(product.CountryId).ToString(),
                context.RoastDegrees.FindAsync(product.RoastDegreeId).ToString()
                );

            return response;

        }

        //public async Task<ProductDto> CreateProductAsync(CreateProductRequest request)
        //{
        //    var newProduct = new Product
        //    {
        //        Name = request.Name,
        //        Description = request.Description,
        //        ProductTypeId = request.ProductTypeId,
        //        ImagePath = request.ImagePath,
        //        Price = request.Price,
        //        Weight = request.Weight
        //    };
        //    context.Products.Add(newProduct);
        //    await context.SaveChangesAsync();

        //    return new ProductDto(
        //        newProduct.Id,
        //        newProduct.Name,
        //        newProduct.Description,
        //        newProduct.ProductTypeId,
        //        newProduct.ImagePath,
        //        newProduct.Price,
        //        newProduct.Weight);
        //}

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
            product.Description = productDto.Description;
            product.ProductTypeId = productDto.ProductTypeId;
            product.ImagePath = productDto.ImagePath;
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
