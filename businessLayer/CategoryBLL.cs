using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class CategoryBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;

        Category _category;

        public CategoryBLL() 
        {
            _category = new Category();
            _mode = enMode.AddMode;
        }

        public Category CurrentCategory { get { return _category; } set { _category = value; } }


        //                          Get Method
        static public async Task<DataTable> GetAllCategories()
        {
            return await CategoryDLL.GetAllCategories();
        }
        public async Task<string> GetCategoryName(short CategoryID)
        {
            return await CategoryDLL.GetCategoryName(CategoryID);
        }
        public async Task<short> GetCategoryID(string CategoryName)
        {
            return await CategoryDLL.GetCategoryID(CategoryName);
        }


        //                          Add Method
        bool Add()
        {
            _category.CategoryID = CategoryDLL.Add(_category);
            return _category.CategoryID > -1;
        }
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddMode:
                    if (Add())
                    {
                        return true;
                    }else
                        return false;
            }
            return false;
                       
        }
    }
}
