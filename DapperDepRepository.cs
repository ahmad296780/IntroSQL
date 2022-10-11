using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IntroSQL
{
    public class DapperDepRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperDepRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (name, price, categoryID)" +
                " values (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct( double ProductID)
        {
            _connection.Execute("delete from products where ProductID = @ProductID;", new { ProductID });
        }

        public IEnumerable<Product> GetAll()
        {
            return _connection.Query<Product>("select * from products;");
        }

        public void UpdateProduct(string name, double price, int categoryID, int productID)
        {
            _connection.Execute("update products set name = @name, price = @price, categoryID = @categoryID  where productID = @productID;", 
                new {name,price, categoryID, productID});
        }
    }
}
