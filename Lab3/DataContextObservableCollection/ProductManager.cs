using Lab3.DataContext;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Lab3.DataContextObservableCollection
{
    public class ProductManager
    {
        private readonly ProductManagerContext _contextProduct;

        private readonly NorthwindContext _context;

        public ObservableCollection<Product> dataProducts { get; set; }

        public ProductManager()
        {
            _contextProduct = new ProductManagerContext();
            dataProducts = new ObservableCollection<Product>();
            _context = new NorthwindContext();
            LoadProducts();
        }

        public void LoadProducts()
        {
            var productList = _contextProduct.GetProducts();
            foreach (var product in productList)
            {
                dataProducts.Add(product);
            }
        }

        public void AddProduct(Product newProduct)
        {
            var existingProduct = dataProducts.FirstOrDefault(p => p.ProductId == newProduct.ProductId);

            if (existingProduct != null)
            {
                MessageBox.Show("ProductID is already exists !!!");
            }
            else
            {
                if (ValidateValue(newProduct) == true)
                {
                    var maxProductId = dataProducts.Max(p => p.ProductId);
                    newProduct.ProductId = maxProductId + 1;
                    dataProducts.Add(newProduct);
                    _contextProduct.AddNewProduct(newProduct);
                    MessageBox.Show("Add new product successful !!!");
                }
            }
        }

        public void UpdateProduct(Product responseProduct)
        {

            var itemToUpdate = dataProducts.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);

            if (itemToUpdate != null)
            {
                itemToUpdate.ProductName = responseProduct.ProductName;
                itemToUpdate.CategoryId = responseProduct.CategoryId;
                itemToUpdate.SupplierId = responseProduct.SupplierId;
                itemToUpdate.QuantityPerUnit = responseProduct.QuantityPerUnit;
                itemToUpdate.UnitPrice = responseProduct.UnitPrice;
                _contextProduct.UpdateProduct(responseProduct);
                MessageBox.Show("Update product successful !!!");
            }
            else
            {
                MessageBox.Show("Selected item value in ListView");
            }
        }

        public void RemoveProduct(Product responseProduct)
        {
            var itemToRemove = dataProducts.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);

            if (itemToRemove != null)
            {
                _context.Entry(itemToRemove).State = EntityState.Detached;
                dataProducts.Remove(itemToRemove);
                _contextProduct.RemoveProduct(responseProduct);
                MessageBox.Show("Remove product successful !!!");
            }
            else
            {
                MessageBox.Show("Selected item value in ListView");
            }

        }

        public void SaveProduct()
        {
            if (dataProducts.Count() > _contextProduct.CountProduct())
            {
                _contextProduct.SaveProduct();
                MessageBox.Show("Save product successful !!!");
            }
            else if (dataProducts.Count() < _contextProduct.CountProduct())
            {
                _contextProduct.SaveProduct();
                MessageBox.Show("Save product successful !!!");
            }
            else
            {
                MessageBox.Show("No Data In List !!!");
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
            else if (responseProduct.Supplier == null)
            {
                MessageBox.Show("Supplier is null");
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
