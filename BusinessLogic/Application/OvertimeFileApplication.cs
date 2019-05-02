using BusinessLogic.Application.Interface;
using Common.Persistence;
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
    public class OvertimeFileApplication : IOvertimeFileApplication
    {
        private readonly IOvertimeFilePersistence _overtimeFilePersistence;

        public OvertimeFileApplication(IOvertimeFilePersistence overtimeFilePersistence)
        {
            _overtimeFilePersistence = overtimeFilePersistence;
        }

        public List<OvertimeFile> Get()
        {
            return _overtimeFilePersistence.Get();
        }

        public OvertimeFile Get(int id)
        {
            return _overtimeFilePersistence.Get(id);
        }

        public bool Insert(OvertimeFileVM overtimeFileVM)
        {
            if (string.IsNullOrEmpty(overtimeFileVM.Name) || string.IsNullOrWhiteSpace(overtimeFileVM.Name))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(overtimeFileVM.Overtime_Id.ToString()) || string.IsNullOrWhiteSpace(overtimeFileVM.Overtime_Id.ToString()))
            {
                return false;
            }
            else
            {
                return _overtimeFilePersistence.Insert(overtimeFileVM);
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
                return _overtimeFilePersistence.Delete(id);
            }
        }
    }
}
