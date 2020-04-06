using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Devulapally_Exam02.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        

        public virtual ICollection<ProjectInfo> ProjectInform { get; set; }
    }
}