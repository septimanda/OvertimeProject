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
    public class OvertimeApplication : IOvertimeApplication
    {
        private readonly IOvertimePersistence _overtimePersistence;

        public OvertimeApplication(IOvertimePersistence overtimePersistence)
        {
            _overtimePersistence = overtimePersistence;
        }

        public List<Overtime> Get()
        {
            return _overtimePersistence.Get();
        }

        public Overtime Get(int id)
        {
            return _overtimePersistence.Get(id);
        }

        public bool Insert(OvertimeVM overtimeVM)
        {
            if (string.IsNullOrEmpty(overtimeVM.Reason) || string.IsNullOrWhiteSpace(overtimeVM.Reason))
            {
                return false;
            }
            else
            {
                return _overtimePersistence.Insert(overtimeVM);
            }
        }

        public bool Update(int id, OvertimeVM overtimeVM)
        {
            if (string.IsNullOrEmpty(overtimeVM.Id.ToString()) || string.IsNullOrWhiteSpace(overtimeVM.Id.ToString()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(overtimeVM.StatusApproval) || string.IsNullOrWhiteSpace(overtimeVM.StatusApproval))
            {
                return false;
            }
            else
            {
                return _overtimePersistence.Update(id, overtimeVM.StatusApproval);
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
                return _overtimePersistence.Delete(id);
            }
        }
    }
}
