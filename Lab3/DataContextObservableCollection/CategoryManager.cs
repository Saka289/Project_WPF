using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DataContext
{
    public class CategoryManager
    {
        private readonly CategoryManagerContext _contextCategory;

        public ObservableCollection<Category> dataCategory { get; set; }

        public CategoryManager()
        {
            _contextCategory = new CategoryManagerContext();
            dataCategory = new ObservableCollection<Category>();
            LoadCategory();
        }

        public void LoadCategory()
        {
            var categoryList = _contextCategory.GetCategory();
            foreach (var cate in categoryList)
            {
                dataCategory.Add(cate);
            }
        }
    }
}
