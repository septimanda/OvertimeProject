using BusinessLogic.Application.Interface;
using Common.Persistence.Interface;
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeePersistence _employeePersistence;

        public EmployeeApplication(IEmployeePersistence employeePersistence)
        {
            _employeePersistence = employeePersistence;
        }

        public List<Employee> Get()
        {
            return _employeePersistence.Get();
        }

        public Employee Get(int id)
        {
            return _employeePersistence.Get(id);
        }

        public bool Insert(EmployeeVM employeeVM)
        {
            if (string.IsNullOrEmpty(employeeVM.Name) || string.IsNullOrWhiteSpace(employeeVM.Name))
            {
                return false;
            }
            else
            {
                return _employeePersistence.Insert(employeeVM);
            }
        }

        public bool Update(int id, EmployeeVM employeeVM)
        {
            if (string.IsNullOrEmpty(employeeVM.Id.ToString()) || string.IsNullOrWhiteSpace(employeeVM.Id.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(employeeVM.Name) || string.IsNullOrWhiteSpace(employeeVM.Name))
            {
                return false;
            }
            else
            {
                return _employeePersistence.Update(id, employeeVM);
            }
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || string.IsNullOrWhiteSpace(id.ToString()))
            {
                return false;
            }
            else
            {
                return _employeePersistence.Delete(id);
            }
        }

    }
}
