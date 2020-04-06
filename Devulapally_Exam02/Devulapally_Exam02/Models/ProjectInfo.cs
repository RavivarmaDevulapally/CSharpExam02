using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Devulapally_Exam02.Models
{
    public class ProjectInfo
    {
        public int ProjectInfoID { get; set; }
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }
        public DateTime AssignmentDate { get; set; }

        public virtual Project Projects { get; set; }
        public virtual Employee Employees { get; set; }

        
    }
}