using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IntroSQL
{
    public class DepartmentsRepository : IDepartmentrepository
    {
        private readonly IDbConnection _connection;

        //Constructor
        public DepartmentsRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM DEPARTMENTS;");
        }
        public void InsertDepartment(string name)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (NAME) VALUES (@NAME)", new { name });
        }
    }
}
