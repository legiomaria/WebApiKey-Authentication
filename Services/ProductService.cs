using Demo.Interfaces;
using Demo.Models;

namespace Demo.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = 
        new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Phone",
                Price = 200000,
                Description = "Samsung blue"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Home Theatre",
                Price = 150000,
                Description = "Home Theatre blueray"
            }
        };
        public Product Add(Product product)
        {
            products.Add(product);
            return product;
        }

        public bool Delete(string productId)
        {
           var toBeDeleted = products
           .Where(m => m.Id.ToString() == productId).SingleOrDefault();
           products.Remove(toBeDeleted ?? new Product());
           return true;
        }

        public Product GetProduct(string productId)
        {
            var existing = products
           .Where(m => m.Id.ToString() == productId)
           .SingleOrDefault();

           return existing ?? new Product();

        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool IsExist(string productId)
        {
            var existing = products
            .Where(m => m.Id.ToString() == productId)
            .SingleOrDefault();

            return existing == null ? true : false;
        }

        public Product Update(Product product)
        {
            Product updatedProduct = new Product();
            foreach(Product pro in products)
            {
                if(pro.Id == product.Id)
                {
                    pro.Name = product.Name;
                    pro.Price = product.Price;
                    pro.Description = product.Description;
                    pro.Id = product.Id;
                    updatedProduct = pro;
                    break;
                }
            }

            return updatedProduct;
        }
    }
}