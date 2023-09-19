using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Logics
{
    class CategoryManager
    {
        NorthwindContext _context;

        public CategoryManager()
        {
            _context = new NorthwindContext();
        }
        public List<Category> GetCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
