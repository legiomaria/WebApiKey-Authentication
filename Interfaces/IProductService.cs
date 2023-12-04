using Demo.Models;

namespace Demo.Interfaces
{
    public interface IProductService
    {
        Product Add(Product product);
        Product Update(Product product);
        bool Delete(string productId);
        Product GetProduct(string productId);
        List<Product> GetProducts();
        bool IsExist(string product);
    }
}