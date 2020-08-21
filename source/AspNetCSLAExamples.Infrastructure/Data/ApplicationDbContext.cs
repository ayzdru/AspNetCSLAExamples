using System;
using System.Collections.Generic;
using System.Text;
using AspNetCSLAExamples.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCSLAExamples.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
