using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace IntroSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //^^^^MUST HAVE USING DIRECTIVES^^^^

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            DapperDepRepository obj = new DapperDepRepository(conn);

            var productRepo = new DapperDepRepository(conn);

            productRepo.DeleteProduct(950);

            var products = productRepo.GetAll();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine();
            }

            obj.CreateProduct("ahaa", 11.99, 2);
            var write = obj.GetAll();
            obj.UpdateProduct("NNAHAA", 14.99, 3, 947);
            obj.DeleteProduct(947);
            write.ToList().ForEach(write => Console.WriteLine($"NAME : {write.Name} ," +
                                                              $"PRICE : {write.Price}," +
                                                              $"PRODUCT ID : {write.ProductID}"));

            // obj.UpdateProduct("NNAHAA", 14.99, 3, 947);
            Console.WriteLine("--------");
            //obj.CreateProduct(22, "xyz", 33);
            var repo = new DepartmentsRepository(conn);
            repo.InsertDepartment("ahmad department");

            var departments = repo.GetAllDepartments();
            foreach (var item in departments)
            {
                Console.WriteLine($"NAME  : {item.Name} ," +
                                  $" ID : {item.Departmentid}");
                ;

            }
        }
    }
}
