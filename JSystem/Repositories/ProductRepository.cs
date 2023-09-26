using JSystem.Dados.Context;
using JSystem.Models;
using JSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextWeb _contextWeb;

        public ProductRepository(ContextWeb contextWeb)
        {
            _contextWeb = contextWeb;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {
            _contextWeb.Products.Add(product);
            await _contextWeb.SaveChangesAsync();
            return product;
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id)
        {
            return await _contextWeb.Products.FindAsync(id);
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            return await _contextWeb.Products.ToListAsync();
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var productToDelete = await _contextWeb.Products.FindAsync(id);

            if (productToDelete == null)
                return false;

            _contextWeb.Products.Remove(productToDelete);
            await _contextWeb.SaveChangesAsync();
            return true;
        }

        public async Task<ProductModel> UpdateProductAsync(Guid id, ProductModel updatedProduct)
        {
            var productToUpdate = await _contextWeb.Products.FindAsync(id);

            if (productToUpdate == null)
                return null;

            productToUpdate.Description = updatedProduct.Description;
            productToUpdate.Quantity = updatedProduct.Quantity;
            productToUpdate.UnitPrice = updatedProduct.UnitPrice;

            if (productToUpdate.BrandId != updatedProduct.BrandId)
            {
                var existingBrand = await _contextWeb.Brands.FindAsync(updatedProduct.BrandId);

                if (existingBrand == null)
                {
                    var newBrand = new BrandModel
                    {
                        Id = updatedProduct.BrandId,
                    };

                    _contextWeb.Brands.Add(newBrand);
                }
                productToUpdate.BrandId = updatedProduct.BrandId;
            }

            await _contextWeb.SaveChangesAsync(); 
            return productToUpdate;
        }

        public async Task<List<ProductModel>> SearchProductsByNameAsync(string name)
        {
            return await _contextWeb.Products
                .Where(p => p.Description.Contains(name))
                .ToListAsync();
        }
    }
}
