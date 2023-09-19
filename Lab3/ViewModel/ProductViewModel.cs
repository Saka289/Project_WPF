using Lab3.DataContext;
using Lab3.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Lab3.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        private ProductManager _productManager;

        private CategoryManager _categoryManager;


        //Command
        public ICommand addProductCommand { get; set; }

        public ICommand deleteProductCommand { get; set; }

        public ICommand updateProductCommand { get; set; }

        //ObservableCollection
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                onPropertyChanged(nameof(Products));
            }
        }

        private ObservableCollection<Category> _category;
        public ObservableCollection<Category> Category
        {
            get { return _category; }
            set
            {
                _category = value;
                onPropertyChanged(nameof(Category));
            }
        }

        //get Value
        private Product selectedProduct = new Product();

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                onPropertyChanged(nameof(SelectedProduct));
            }
        }

        //Contructor
        public ProductViewModel()
        {
            _productManager = new ProductManager();
            Products = _productManager.dataProducts;
            _categoryManager = new CategoryManager();
            Category = _categoryManager.dataCategory;
            addProductCommand = new ReplayCommand(canAddProduct, addProduct);
            updateProductCommand = new ReplayCommand(canUpdateProduct, updateProduct);
            deleteProductCommand = new ReplayCommand(canDeleteProduct, deleteProduct);
        }

        private void addProduct(object obj)
        {
            _productManager.AddProduct(selectedProduct);
        }
        private void deleteProduct(object obj)
        {
            if (selectedProduct != null)
            {
                _productManager.RemoveProduct(SelectedProduct);
            }
            else
            {
                MessageBox.Show("Select item value in ListView");
            }
        }

        private void updateProduct(object obj)
        {
            if (selectedProduct != null)
            {
                _productManager.UpdateProduct(selectedProduct);
            }
            else
            {
                MessageBox.Show("Selected item value in ListView");
            }
        }

        private bool canUpdateProduct(object obj)
        {
            return true;
        }

        private bool canAddProduct(object obj)
        {
            return true;
        }
        private bool canDeleteProduct(object obj)
        {
            return true;
        }

    }
}
