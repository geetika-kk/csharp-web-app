using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geetzcsharp.Models;
using geetzcsharp.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace geetzcsharp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static List<ShoppingCartItem> shoppingCartItems = new List<ShoppingCartItem>();
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View(shoppingCartItems);
        }

        public IActionResult AddToCart(int productId)
        {
            var product = _productRepository.GetProductById(productId);// Get product by id from repository
            if (product != null)
            {
                var cartItem = shoppingCartItems.Find(item => item.ProductId == productId);
                if (cartItem == null)
                {
                    shoppingCartItems.Add(new ShoppingCartItem { ProductId = productId, Product = product, Quantity = 1 });
                }
                else
                {
                    cartItem.Quantity++;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cartItem = shoppingCartItems.Find(item => item.ProductId == productId);
            if (cartItem != null)
            {
                shoppingCartItems.Remove(cartItem);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
