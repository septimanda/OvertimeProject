using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.ViewModels
{
    public class OvertimeVM
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Reason { get; set; }
        public int TotalOvertime { get; set; }
        public int Payment { get; set; }
        public string StatusApproval { get; set; }
        public int Employee_Id { get; set; }
    }
}