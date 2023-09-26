using Lab3.DataContext;
using Lab3.DataContextObservableCollection;
using Lab3.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Lab3.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly ProductManager _productManager;

        private readonly CategoryManager _categoryManager;

        private readonly SuppliersManager _suppliersManager;

        //Command
        public ICommand addProductCommand { get; set; }

        public ICommand deleteProductCommand { get; set; }

        public ICommand updateProductCommand { get; set; }

        public ICommand saveProductCommand { get; set; }

        public ICommand clearProductCommand { get; set; }



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

        private ObservableCollection<Supplier> _suppliers;

        public ObservableCollection<Supplier> Suppliers
        {
            get { return _suppliers; }
            set
            {
                _suppliers = value;
                onPropertyChanged(nameof(Suppliers));
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
            _suppliersManager = new SuppliersManager();
            Suppliers = _suppliersManager.dataSuppliers;
            addProductCommand = new ReplayCommand(canAddProduct, addProduct);
            updateProductCommand = new ReplayCommand(canUpdateProduct, updateProduct);
            deleteProductCommand = new ReplayCommand(canDeleteProduct, deleteProduct);
            saveProductCommand = new ReplayCommand(canSaveProduct, saveProduct);
            clearProductCommand = new ReplayCommand(canClearProduct, clearProduct);
        }

        private void clearProduct(object obj)
        {
            SelectedProduct = new Product();
        }

        private void addProduct(object obj)
        {
            _productManager.AddProduct(selectedProduct);
            clearProduct(obj);
        }
        private void deleteProduct(object obj)
        {
            _productManager.RemoveProduct(SelectedProduct);
            clearProduct(obj);
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
        private bool canClearProduct(object obj)
        {
            return true;
        }
    }
}
