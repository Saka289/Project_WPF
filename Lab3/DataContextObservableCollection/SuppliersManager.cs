using Lab3.DataContext;
using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DataContextObservableCollection
{
    public class SuppliersManager
    {

        private readonly SuppliersManagerContext _contextSuppliers;

        public ObservableCollection<Supplier> dataSuppliers { get; set; }

        public SuppliersManager()
        {
            _contextSuppliers = new SuppliersManagerContext();
            dataSuppliers = new ObservableCollection<Supplier>();
            loadSuppliers();
        }

        public void loadSuppliers()
        {
            var suppliersList = _contextSuppliers.GetSuppliers();
            foreach (var supplier in suppliersList)
            {
                dataSuppliers.Add(supplier);
            }
        }
    }
}
