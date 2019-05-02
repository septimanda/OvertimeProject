using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext") { }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeFile> OvertimeFiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}