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
        public ObservableCollection<Product> dataProducts { get; set; }

        public ProductManager()
        {
            _contextProduct = new ProductManagerContext();
            dataProducts = new ObservableCollection<Product>();
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
                itemToUpdate.QuantityPerUnit = responseProduct.QuantityPerUnit;
                itemToUpdate.UnitPrice = responseProduct.UnitPrice;
                _contextProduct.UpdateProduct(responseProduct);
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
                dataProducts.Remove(itemToRemove);
                _contextProduct.RemoveProduct(responseProduct);
            }
            else
            {
                MessageBox.Show("Selected item value in ListView");
            }

        }

        public void SaveProduct()
        {
            _contextProduct.SaveProduct();
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
