using Lab2.Logics;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NorthwindContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new NorthwindContext();
            ProductManager productManager = new ProductManager();
            CategoryManager categoryManager = new CategoryManager();
            List<Product> products = productManager.GetProducts();
            List<Category> categories = categoryManager.GetCategory();
            LbProducts.ItemsSource = products;
            Category.ItemsSource = categories;
            Category.SelectedValuePath = "CategoryId";
            Category.DisplayMemberPath = "CategoryName";
            Category.SelectedIndex = -1;
            LbProducts.DataContext = this;

        }

        int count;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            var productId = _context.Products.OrderByDescending(p => p.ProductId).Select(p => p.ProductId).Take(1);
            count = productId.FirstOrDefault() + 1;
            product.ProductName = Name.Text;
            product.CategoryId = Convert.ToInt32(Category.SelectedValue);
            product.QuantityPerUnit = Quantity.Text;
            if (Discontinued.IsChecked == true)
            {
                product.Discontinued = true;
            }
            else
            {
                product.Discontinued = false;
            }
            product.UnitPrice = Convert.ToDecimal(Price.Text);
            _context.Products.AsTracking();
            _context.Products.Add(product);
            var currentItems = LbProducts.ItemsSource as ObservableCollection<Product>;
            if (currentItems == null)
            {
                currentItems = new ObservableCollection<Product>();
                foreach (var item in LbProducts.ItemsSource as List<Product>)
                {
                    currentItems.Add(item);
                }
                LbProducts.ItemsSource = currentItems;
                product.ProductId = ++count;
                currentItems.Add(product);
            }
            else
            {
                LbProducts.ItemsSource = currentItems;
                product.ProductId = ++count;
                currentItems.Add(product);
            }
            //_context.SaveChanges();
            //LbProducts.ItemsSource = _context.Products.ToList();
            clearData();
        }

        public void clearData()
        {
            Id.Text = string.Empty;
            Name.Text = string.Empty;
            Price.Text = string.Empty;
            Quantity.Text = string.Empty;
        }

        private void LbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = LbProducts.SelectedItem as Product;
            if (product != null)
            {
                Id.Text = product.ProductId.ToString();
                Name.Text = product.ProductName.ToString();
                Category.SelectedValue = product.CategoryId;
                Quantity.Text = product.QuantityPerUnit.ToString();
                if (product.Discontinued == true)
                {
                    Discontinued.IsChecked = true;
                }
                else
                {
                    Discontinued1.IsChecked = true;
                }
                Price.Text = product.UnitPrice.ToString();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var check = LbProducts.SelectedItem as Product;
            if (check != null)
            {
                int id = Convert.ToInt32(Id.Text);
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                    product.ProductName = Name.Text;
                    product.CategoryId = Convert.ToInt32(Category.SelectedValue);
                    product.QuantityPerUnit = Quantity.Text;
                    product.UnitPrice = Convert.ToDecimal(Price.Text);
                    if (Discontinued.IsChecked == true)
                    {
                        product.Discontinued = true;
                    }
                    else
                    {
                        product.Discontinued = false;
                    }
                }
                _context.SaveChanges();
                LbProducts.ItemsSource = _context.Products.ToList();
                clearData();
            }
            else
            {
                MessageBox.Show("select item product");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var check = LbProducts.SelectedItem as Product;
            if (check != null)
            {
                int id = Convert.ToInt32(Id.Text);
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    LbProducts.ItemsSource = _context.Products.ToList();
                    clearData();
                }
            }
            else
            {
                MessageBox.Show("select item product");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            LbProducts.ItemsSource = _context.Products.ToList();
        }
    }
}
