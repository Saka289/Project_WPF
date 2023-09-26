using Lab3.DataContext;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Lab3.DataContextObservableCollection
{
    public class ProductManager
    {
        private readonly ProductManagerContext _contextProduct;

        public ObservableCollection<Product> dataProducts { get; set; }

        public List<Product> products { get; set; }

        public ProductManager()
        {
            _contextProduct = new ProductManagerContext();
            dataProducts = new ObservableCollection<Product>();
            products = new List<Product>();
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

        public void AddProductObservableCollection(Product newProduct)
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
                    products.Add(newProduct);
                    MessageBox.Show("Add new product successful !!!");
                }
            }
        }

        public void UpdateProductObservableCollection(Product responseProduct)
        {

            var itemToUpdate = dataProducts.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);
            var itemListProduct = products.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);
            if (itemListProduct != null)
            {
                itemListProduct.ProductName = responseProduct.ProductName;
                itemListProduct.CategoryId = responseProduct.CategoryId;
                itemListProduct.SupplierId = responseProduct.SupplierId;
                itemListProduct.QuantityPerUnit = responseProduct.QuantityPerUnit;
                itemListProduct.UnitPrice = responseProduct.UnitPrice;
            }
            if (itemToUpdate != null)
            {
                _contextProduct.UpdateProduct(responseProduct);
                MessageBox.Show("Update product successful !!!");
            }
            else
            {
                MessageBox.Show("Selected item value in ListView");
            }
        }

        public void RemoveProductObservableCollection(Product responseProduct)
        {
            var itemToRemove = dataProducts.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);
            var itemListProduct = products.FirstOrDefault(p => p.ProductId == responseProduct.ProductId);
            if (itemToRemove == null)
            {
                MessageBox.Show("Selected item value in ListView");
            }
            if (_contextProduct.checkOrderDetail(responseProduct.ProductId) == true)
            {
                if (itemListProduct != null && itemToRemove != null)
                {
                    products.Remove(itemListProduct);
                    dataProducts.Remove(itemToRemove);
                    MessageBox.Show("Remove product successful !!!");
                }
                else if (itemToRemove != null)
                {
                    dataProducts.Remove(itemToRemove);
                    _contextProduct.RemoveProduct(itemToRemove);
                    MessageBox.Show("Remove product successful !!!");
                }
            }
            else
            {
                MessageBox.Show("Can't remove record !!!");
            }

        }

        public void SaveProduct()
        {
            bool flag = true;
            if (products.Any())
            {
                _contextProduct.SaveNewProductList(products);
                MessageBox.Show("Save product successful !!!");
                flag = false;
            }
            if (_contextProduct.SaveProduct())
            {
                if (flag == true)
                {
                    MessageBox.Show("Save product successful !!!");
                }
            }
            else
            {
                if (!products.Any())
                {
                    MessageBox.Show("No records have been added !!!");
                }
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
