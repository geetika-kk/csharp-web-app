using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geetzcsharp.Models;

namespace geetzcsharp.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
