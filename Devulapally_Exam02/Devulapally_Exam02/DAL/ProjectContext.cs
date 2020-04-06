using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Devulapally_Exam02.Models;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Devulapally_Exam02.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectInfo> ProjectInform { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}