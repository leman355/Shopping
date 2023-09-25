using Shopping.Business.Abstract;
using Shopping.DataAccess.Abstract;
using Shopping.Entities;

namespace Shopping.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await _repository.CreateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repository.GetProductById(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _repository.UpdateProduct(product);
        }
    }
}