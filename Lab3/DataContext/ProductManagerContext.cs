using Lab3.DataContextObservableCollection;
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
    public class ProductManagerContext
    {
        private readonly NorthwindContext _context;

        public ProductManagerContext()
        {
            _context = new NorthwindContext();
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .AsNoTracking()
                .AsQueryable();
        }

        public int CountProduct()
        {
            return _context.Products.Count();
        }

        public void AddNewProduct(Product responseProduct)
        {
            Product product = new Product();
            product.ProductName = responseProduct.ProductName;
            product.CategoryId = responseProduct.CategoryId;
            product.SupplierId = responseProduct.SupplierId;
            product.QuantityPerUnit = responseProduct.QuantityPerUnit;
            product.UnitPrice = responseProduct.UnitPrice;
            product.Discontinued = responseProduct.Discontinued;
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product responseProduct)
        {
            Product product = new Product();
            product.ProductName = responseProduct.ProductName;
            product.CategoryId = responseProduct.CategoryId;
            product.SupplierId = responseProduct.SupplierId;
            product.QuantityPerUnit = responseProduct.QuantityPerUnit;
            product.UnitPrice = responseProduct.UnitPrice;
            product.Discontinued = responseProduct.Discontinued;
            _context.Products.Update(product);
        }

        public void RemoveProduct(Product responseProduct)
        {
            _context.Entry(responseProduct).State = EntityState.Detached;
            _context.Products.Remove(responseProduct);
            responseProduct.Category = null;
            responseProduct.Supplier = null;
            var removeProduct = _context.Products.Find(responseProduct.ProductId);
            if (removeProduct != null)
            {
                _context.Products.Remove(removeProduct);
            }

        }

        public void SaveProduct()
        {
            _context.SaveChanges();
        }
    }
}
