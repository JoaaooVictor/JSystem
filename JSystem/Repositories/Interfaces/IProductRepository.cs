using JSystem.Models;

namespace JSystem.Repositories.Interfaces
{

    public interface IProductRepository
    {
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task<ProductModel> GetProductByIdAsync(Guid id);
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<bool> DeleteProductAsync(Guid id);
        Task<ProductModel> UpdateProductAsync(Guid id, ProductModel product);
        Task<List<ProductModel>> SearchProductsByNameAsync(string name);
    }


}
