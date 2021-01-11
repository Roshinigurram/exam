using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using mvcforassessment.Models;

namespace mvcforassessment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<mvcforassessment.Models.Employee> Employee { get; set; }
        public DbSet<mvcforassessment.Models.Department> Department { get; set; }
    }
}
