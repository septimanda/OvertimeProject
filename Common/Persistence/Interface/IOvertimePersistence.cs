using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.Interface
{
    public interface IOvertimePersistence
    {
        List<Overtime> Get();
        Overtime Get(int id);
        bool Insert(OvertimeVM overtimeVM);
        bool Update(int id, string StatusApproval);
        bool Delete(int id);
    }
}
