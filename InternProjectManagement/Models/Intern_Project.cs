using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternProjectManagement.Models
{
    public class Intern_Project
    {
        [Key]
        public int id { get; set; }
        public int intern_id { get; set; }
        public int project_id { get; set; }
    }
}
