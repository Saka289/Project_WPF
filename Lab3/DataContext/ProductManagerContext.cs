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
        private bool hasChanges;

        public ProductManagerContext()
        {
            _context = new NorthwindContext();
            hasChanges = false;
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
            hasChanges = true;
        }

        public void SaveNewProductList(List<Product> responseProduct)
        {
            foreach (var item in responseProduct)
            {
                Product product = new Product();
                product.ProductName = item.ProductName;
                product.CategoryId = item.CategoryId;
                product.SupplierId = item.SupplierId;
                product.QuantityPerUnit = item.QuantityPerUnit;
                product.UnitPrice = item.UnitPrice;
                product.Discontinued = item.Discontinued;
                _context.Products.Add(product);
            }
            _context.SaveChanges();
        }

        public void UpdateProduct(Product responseProduct)
        {
            var updateProduct = _context.Products.Find(responseProduct.ProductId);
            if (updateProduct != null)
            {
                updateProduct.ProductName = responseProduct.ProductName;
                updateProduct.CategoryId = responseProduct.CategoryId;
                updateProduct.SupplierId = responseProduct.SupplierId;
                updateProduct.QuantityPerUnit = responseProduct.QuantityPerUnit;
                updateProduct.UnitPrice = responseProduct.UnitPrice;
                updateProduct.Discontinued = responseProduct.Discontinued;
                _context.Products.Update(updateProduct);
            }
            hasChanges = true;
        }

        public void RemoveProduct(Product responseProduct)
        {
            responseProduct.Category = null;
            responseProduct.Supplier = null;
            var removeProduct = _context.Products.Find(responseProduct.ProductId);
            if (removeProduct != null)
            {
                _context.Products.Remove(removeProduct);
            }
            hasChanges = true;
        }

        public bool checkOrderDetail(int productId)
        {
            bool IsCheck = true;
            var checkOrderDetail = _context.OrderDetails.FirstOrDefault(p => p.ProductId == productId);
            if (checkOrderDetail != null)
            {
                IsCheck = false;
            }
            return IsCheck;
        }

        public bool SaveProduct()
        {
            if (hasChanges)
            {
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
