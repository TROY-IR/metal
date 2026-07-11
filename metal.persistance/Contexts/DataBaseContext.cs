using metal.Application.InterFace.Contexts;
using metal.Common.Bugeto_Store.Common.Roles;
using metal.Domain.Entities.posters;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;



namespace metal.persistance.Contexts
{
    public class DataBaseContext: DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions op) :base(op)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Userinrole> Userinroles { get; set; }

        public DbSet<element1> element1 { get; set; }
        public DbSet<element2> element2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });



            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }

        

        public Task<int> SaveChangeAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
