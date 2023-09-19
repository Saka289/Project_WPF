using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DataContext
{
    public class ProductManager
    {

        private readonly NorthwindContext _context;
        public ObservableCollection<Product> dataProducts { get; set; }

        public ProductManager()
        {
            _context = new NorthwindContext();
            dataProducts = new ObservableCollection<Product>();
            LoadProducts();
        }

        public void LoadProducts()
        {
            var productList = _context.Products.Include(c => c.Category).ToList();
            foreach (var product in productList)
            {
                dataProducts.Add(product);
            }
        }

        public void AddProduct(Product newProduct)
        {
            newProduct.ProductId = 0;
            newProduct.Category = null;
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            dataProducts.Add(newProduct);
        }

        public void UpdateProduct(Product responseProduct)
        {
            _context.Products.AsNoTracking();
            _context.Products.Update(responseProduct);
            _context.SaveChanges();
        }

        public void RemoveProduct(Product responseProduct)
        {
            int id = responseProduct.ProductId;
            var item = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (item != null)
            {
                item.Category = null;
                dataProducts.Remove(item);
                _context.Products.Remove(item);
                _context.SaveChanges();
            }

        }
    }
}
