using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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
            var item = _context.Products.FirstOrDefault(p => p.ProductId == newProduct.ProductId);
            if (item != null)
            {
                MessageBox.Show("ProductID is exists !!!");
            }
            else
            {
                if (ValidateValue(newProduct) == true)
                {
                    newProduct.ProductId = 0;
                    newProduct.Category = null;
                    _context.Products.AsNoTracking();
                    _context.Products.Add(newProduct);
                    dataProducts.Add(newProduct);
                    _context.SaveChanges();
                }
            }
        }

        public void UpdateProduct(Product responseProduct)
        {

            var item = _context.Products.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);
            if (item != null)
            {
                responseProduct.Category = null;
                _context.Products.AsNoTracking();
                _context.Products.Update(responseProduct);
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("ProductID does not exist !!!");
            }
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

        private bool ValidateValue(Product responseProduct)
        {
            bool Ischeck = true;
            if (responseProduct.ProductName == null)
            {
                MessageBox.Show("ProductName is null");
                Ischeck = false;
            }
            else if (responseProduct.Category == null)
            {
                MessageBox.Show("Category is null");
                Ischeck = false;
            }
            else if (responseProduct.QuantityPerUnit == null)
            {
                MessageBox.Show("QuantityPerUnit is null");
                Ischeck = false;
            }
            else if (responseProduct.UnitPrice == null)
            {
                MessageBox.Show("UnitPrice is null");
                Ischeck = false;
            }
            return Ischeck;
        }
    }
}
