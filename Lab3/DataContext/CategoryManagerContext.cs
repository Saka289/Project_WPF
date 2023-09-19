using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DataContext
{
    public class CategoryManagerContext
    {
        private readonly NorthwindContext _context;

        public CategoryManagerContext()
        {
            _context = new NorthwindContext();
        }

        public List<Category> GetCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
