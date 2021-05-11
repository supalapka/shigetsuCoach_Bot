using shigetsuCoach_Bot.Data.Files;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace shigetsuCoach_Bot.Data
{
    class MyDbContext : DbContext
    {
        public MyDbContext(): base("DbConnectionString")
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
