using Core.Base;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }

        public Employee() { }

        public Employee(EmployeeVM employeeVM)
        {
            this.Name = employeeVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(EmployeeVM employeeVM)
        {
            this.Name = employeeVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}