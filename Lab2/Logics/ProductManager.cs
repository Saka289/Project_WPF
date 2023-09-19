using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Logics
{
    class ProductManager
    {
        NorthwindContext _context;

        public ProductManager()
        {
            _context = new NorthwindContext();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.Include(c => c.Category).ToList();
        }
    }
}
