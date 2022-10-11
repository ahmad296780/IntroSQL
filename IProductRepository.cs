using System;
using System.Collections.Generic;
using System.Text;

namespace IntroSQL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void CreateProduct(string name , double price, int categoryID);
        void UpdateProduct(string name, double price, int categoryID, int productID);
        void DeleteProduct( double productID);
        
    }
}
