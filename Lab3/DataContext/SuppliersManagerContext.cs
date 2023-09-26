using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DataContext
{
    public class SuppliersManagerContext
    {
        private readonly NorthwindContext _context;

        public SuppliersManagerContext()
        {
            _context = new NorthwindContext();
        }

        public IQueryable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.AsNoTracking().AsQueryable();
        }
    }
}
