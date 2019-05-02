using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Interface
{
    public interface IOvertimeFileApplication
    {
        List<OvertimeFile> Get();
        OvertimeFile Get(int id);
        bool Insert(OvertimeFileVM overtimeFileVM);
        bool Delete(int id);
    }
}
