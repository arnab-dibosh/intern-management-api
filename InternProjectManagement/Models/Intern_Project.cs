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
        public int ID { get; set; }
        public int Intern_ID { get; set; }
        public int Project_ID { get; set; }
    }
}
