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
    public class OvertimeFilePersistence : IOvertimeFilePersistence
    {
        MyContext myContext = new MyContext();
        bool status = false;

        IOvertimePersistence iOvertimePersistence = new OvertimePersistence();

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

        public List<OvertimeFile> Get()
        {
            var get = myContext.OvertimeFiles.Include("Overtimes").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public OvertimeFile Get(int id)
        {
            var get = myContext.OvertimeFiles.Find(id);
            return get;
        }

        public bool Insert(OvertimeFileVM overtimeFileVM)
        {

            var push = new OvertimeFile(overtimeFileVM);
            push.Overtimes = iOvertimePersistence.Get(overtimeFileVM.Overtime_Id);
            myContext.Entry(push.Overtimes).State = EntityState.Unchanged;
            myContext.OvertimeFiles.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
