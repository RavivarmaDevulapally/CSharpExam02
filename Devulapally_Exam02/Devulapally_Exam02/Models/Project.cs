using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Devulapally_Exam02.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID { get; set; }
        public string Title { get; set; }
        //public int Credits { get; set; }

        public virtual ICollection<ProjectInfo> ProjectInform { get; set; }
    }
}