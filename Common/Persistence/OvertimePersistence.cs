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
    public class OvertimePersistence : IOvertimePersistence
    {
        MyContext myContext = new MyContext();
        bool status = false;

        IEmployeePersistence iEmployeePersistence = new EmployeePersistence();

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

        public List<Overtime> Get()
        {
            var get = myContext.Overtimes.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Overtime Get(int id)
        {
            var get = myContext.Overtimes.Find(id);
            return get;
        }

        public bool Insert(OvertimeVM overtimeVM)
        {

            var push = new Overtime(overtimeVM);
            push.Employees = iEmployeePersistence.Get(overtimeVM.Employee_Id);
            myContext.Entry(push.Employees).State = EntityState.Unchanged;
            myContext.Overtimes.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int id, string StatusApproval)
        {
            var get = Get(id);
            get.Employees = iEmployeePersistence.Get(get.Employee_Id);

            get.Update(StatusApproval);

            myContext.Entry(get.Employees).State = EntityState.Unchanged;
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
