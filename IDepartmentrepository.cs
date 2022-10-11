using System;
using System.Collections.Generic;
using System.Text;

namespace IntroSQL
{
    public interface IDepartmentrepository
    {
        IEnumerable<Departments> GetAllDepartments();
        void InsertDepartment(string name);
    }
}
