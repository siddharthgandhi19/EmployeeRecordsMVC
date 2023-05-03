using BusinessLayer.Interface;
using CommonLayer.Models;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static BusinessLayer.Services.EmployeeBL;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {

        IEmployeeRL iIEmployeeRL;
        public EmployeeBL(IEmployeeRL iIEmployeeRL)
        {
            this.iIEmployeeRL = iIEmployeeRL;
        }

        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return iIEmployeeRL.AddEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            try
            {
                return iIEmployeeRL.DeleteEmployee(EmployeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return iIEmployeeRL.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        public EmployeeModel GetEmployeeData(int EmployeeId)
        {
            try
            {
                return iIEmployeeRL.GetEmployeeData(EmployeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return iIEmployeeRL.UpdateEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
