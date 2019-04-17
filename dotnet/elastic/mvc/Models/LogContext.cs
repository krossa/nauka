using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class LogContext : DbContext
{
    public LogContext(DbContextOptions<LogContext> options)
        : base(options)
    {
    }

    public DbSet<Log> Log { get; set; }
}
