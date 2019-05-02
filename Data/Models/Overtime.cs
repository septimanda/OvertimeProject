using Core.Base;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class Overtime : BaseModel
    {
        public DateTimeOffset Date { get; set; }
        public string Reason { get; set; }
        public int TotalOvertime { get; set; }
        public int Payment { get; set; }
        public string StatusApproval { get; set; }
        public int Employee_Id { get; set; }

        [ForeignKey("Employee_Id")]
        public virtual Employee Employees { get; set; }

        public Overtime() { }

        public Overtime(OvertimeVM overtimeVM)
        {
            this.Date = overtimeVM.Date;
            this.Reason = overtimeVM.Reason;
            this.TotalOvertime = overtimeVM.TotalOvertime;
            this.Payment = overtimeVM.Payment;
            this.StatusApproval = "Pending";
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(string statusApproval)
        {
            this.StatusApproval = statusApproval;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}