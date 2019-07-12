using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZILDING_CORE.Models;

namespace ZILDING_CORE
{
    public class ZildingDBContext : DbContext
    {
        public ZildingDBContext()
        {
        }
        public ZildingDBContext(DbContextOptions<ZildingDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> RolesList { get; set; }
    }
}
