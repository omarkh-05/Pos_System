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
    public class ProductBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;

        private Product _product;

        public ProductBLL()
        {
            _product = new Product();
            _mode = enMode.AddMode;
        }

        public ProductBLL(Product product)
        {
            _product = product;
            _mode = enMode.UpdateMode;
        }

        public Product CurrentProduct
        {
            get { return _product; }
            set { _product = value; }
        }

        public bool Add()
        {
            _product.ProductID = ProductDLL.Add(_product);  // output is short
            return _product.ProductID > 0;
        }

        public bool Update()
        {
            return ProductDLL.Update(_product);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddMode:
                    if (Add())
                    {
                        _mode = enMode.UpdateMode;
                        return true;
                    }
                    return false;

                case enMode.UpdateMode:
                    return Update();
            }
            return false;
        }

        public static async Task<DataTable> GetAllProducts()
        {
            return await ProductDLL.GetAllProducts();
        }
        public static async Task<DataTable> GetProductsByCategory(short categoryId)
        {
            return await ProductDLL.GetProductsByCategory(categoryId);
        }
        public async Task<Product> GetProductByID(short productId)
        {
            return await ProductDLL.GetProductByID(productId);
        }
    }
}
