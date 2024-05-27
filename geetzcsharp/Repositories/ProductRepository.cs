using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geetzcsharp.Data;
using geetzcsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace geetzcsharp.Repositories
{
 
        public class ProductRepository : IProductRepository
        {
            private readonly ApplicationDbContext _context;

            public ProductRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Product> GetAllProducts()
            {
                return _context.Products.Include(p => p.Category).ToList();
            }

            public Product GetProductById(int id)
            {
                return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            }

            public void AddProduct(Product product)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            public void UpdateProduct(Product product)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }

            public void DeleteProduct(int id)
            {
                var product = _context.Products.Find(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
        }

}
