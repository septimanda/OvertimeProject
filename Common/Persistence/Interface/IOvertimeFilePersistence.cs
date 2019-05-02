using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.Interface
{
    public interface IOvertimeFilePersistence
    {
        List<OvertimeFile> Get();
        OvertimeFile Get(int id);
        bool Insert(OvertimeFileVM overtimeFileVM);
        bool Delete(int id);
    }
}
