using System;
using Microsoft.EntityFrameworkCore;


namespace WebAppAspNetCore.Models
{
    public class BootCampContext : DbContext
    {

        
            public BootCampContext(DbContextOptions<BootCampContext> options)
                    : base(options)
            {
            }

            public DbSet<RunnerPerformance> RunnerPerformances { get; set; }

           public DbSet<Statistic> Statistics { get; set; }

    }
}