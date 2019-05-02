using Core.Base;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class OvertimeFile : BaseModel
    {
        public string Name { get; set; }
        public int Overtime_Id { get; set; }

        [ForeignKey("Overtime_Id")]
        public virtual Overtime Overtimes { get; set; }

        public OvertimeFile() { }

        public OvertimeFile(OvertimeFileVM overtimeFileVM)
        {
            this.Name = overtimeFileVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}