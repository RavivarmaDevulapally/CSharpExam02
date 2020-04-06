using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Devulapally_Exam02.Models;

namespace Devulapally_Exam02.DAL
{
    public class ProjectInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            var employees = new List<Employee>
            {
            new Employee{FirstMidName="Carson",LastName="Alexander"},
            new Employee{FirstMidName="Meredith",LastName="Alonso"},
            new Employee{FirstMidName="Arturo",LastName="Anand"},
            
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
            var projects = new List<Project>
            {
            new Project{ProjectID=1050,Title="ProjectAZA"},
            new Project{ProjectID=1051,Title="ProjectJZA"},
            };
            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();
            var projectinform = new List<ProjectInfo>
            {
            new ProjectInfo{EmployeeID=1,ProjectID=1050,AssignmentDate=DateTime.Parse("2005-09-01")},
            new ProjectInfo{EmployeeID=2,ProjectID=1051,AssignmentDate=DateTime.Parse("2005-10-01")},
            
            };
            //ProjectInfo.ForEach(s => context.ProjectInform.Add(s));
            context.SaveChanges();
        }
    }
}