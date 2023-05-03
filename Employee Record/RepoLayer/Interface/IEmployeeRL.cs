using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmployeeRL
    {
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
        public EmployeeModel GetEmployeeData(int EmployeeId);
        public bool DeleteEmployee(int EmployeeId);
    }
}
