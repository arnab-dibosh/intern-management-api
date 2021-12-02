using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternProjectManagement.Models
{
    public class InternProjectManagementContext : DbContext
    {
        public InternProjectManagementContext
            (DbContextOptions<InternProjectManagementContext> options) : base(options)
        {

        }

        public DbSet<Intern> Intern { get; set; }
        public DbSet<Project> Project { get; set; }

        public DbSet<Intern_Project> Intern_Project { get; set; }
    }
}
