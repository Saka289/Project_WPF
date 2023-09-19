﻿using Lab3.DataContext;
using Lab3.DataContextObservableCollection;
using Lab3.Models;
using System.Collections.ObjectModel;
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

        public ICommand saveProductCommand { get; set; }

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
            saveProductCommand = new ReplayCommand(canSaveProduct, saveProduct);
        }

        private void addProduct(object obj)
        {
            _productManager.AddProduct(selectedProduct);
        }
        private void deleteProduct(object obj)
        {
            _productManager.RemoveProduct(SelectedProduct);
        }

        private void updateProduct(object obj)
        {
            _productManager.UpdateProduct(selectedProduct);
        }

        private void saveProduct(object obj)
        {
            _productManager.SaveProduct();
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
        private bool canSaveProduct(object obj)
        {
            return true;
        }
    }
}
