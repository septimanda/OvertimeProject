using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Interface
{
    public interface IOvertimeApplication
    {
        List<Overtime> Get();
        Overtime Get(int id);
        bool Insert(OvertimeVM overtimeVM);
        bool Update(int id, OvertimeVM overtimeVM);
        bool Delete(int id);
    }
}
