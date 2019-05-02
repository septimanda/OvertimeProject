using Common.Persistence.Interface;
using Data.Context;
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence
{
    public class EmployeePersistence : IEmployeePersistence
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            myContext.Entry(get).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Employee> Get()
        {
            var get = myContext.Employees.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Employee Get(int id)
        {
            var get = myContext.Employees.Find(id);
            return get;
        }

        public bool Insert(EmployeeVM employeeVM)
        {

            var push = new Employee(employeeVM);
            myContext.Employees.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int id, EmployeeVM employeeVM)
        {
            var get = Get(id);
            get.Update(employeeVM);
            myContext.Entry(get).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
