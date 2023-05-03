using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeRecords.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmployeeBL iIEmployeeBL;
        public EmpController(IEmployeeBL iIEmployeeBL)

        {
            this.iIEmployeeBL = iIEmployeeBL;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();
            lstemployee = iIEmployeeBL.GetAllEmployees().ToList();
            return View(lstemployee);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                iIEmployeeBL.AddEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult GetEmployeeData(int EmployeeId)
        {
            if (EmployeeId == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = iIEmployeeBL.GetEmployeeData(EmployeeId);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }


        [HttpGet]
        public IActionResult Edit(int EmployeeId)
        {
            if (EmployeeId == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = iIEmployeeBL.GetEmployeeData(EmployeeId);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int EmployeeId, [Bind] EmployeeModel employeeModel)
        {
            if (EmployeeId != employeeModel.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iIEmployeeBL.UpdateEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }
        [HttpGet]
        public IActionResult Delete(int EmployeeId)
        {
            if (EmployeeId == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = iIEmployeeBL.GetEmployeeData(EmployeeId);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int EmployeeId)
        {
            iIEmployeeBL.DeleteEmployee(EmployeeId);
            return RedirectToAction("Index");
        }

    }
}
