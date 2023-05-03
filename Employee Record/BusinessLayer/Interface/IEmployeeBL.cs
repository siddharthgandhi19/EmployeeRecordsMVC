using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
        public EmployeeModel GetEmployeeData(int EmployeeId);
        public bool DeleteEmployee(int EmployeeId);
    }
}
