using metal.Application.InterFace.Contexts;
using metal.Common.Bugeto_Store.Common.Roles;
using metal.Domain.Entities.Carts;
using metal.Domain.Entities.Finance;
using metal.Domain.Entities.HomePages;
using metal.Domain.Entities.likedto;
using metal.Domain.Entities.Media;
using metal.Domain.Entities.Orders;
using metal.Domain.Entities.posters;
using metal.Domain.Entities.Products;
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

        public DbSet<Role> Roles { get; set; }
        public DbSet<Userinrole> Userinroles { get; set; }

        public DbSet<element1> element1 { get; set; }
        public DbSet<element2> element2 { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<CategoryImages> CategoryImages { get; set; }
        public DbSet<Slider> Slider { get; set; }

        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaImages> MediaImages { get; set; }
        public DbSet<MediaTexts> MediaTexts { get; set; }
        public DbSet<MediaProducts> MediaProducts { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<RequestPay> RequestPays { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Defav> Defavs { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Like> likes { get; set; }
        public DbSet<likechild> likechildren { get; set; }
        public DbSet<dCartItem> dCartItems { get; set; }
        public DbSet<dOrderDetail> dOrderDetails { get; set; }
        public DbSet<size> sizes { get; set; }
        public DbSet<texra> texras { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
           .HasOne(p => p.User)
            .WithMany(p => p.Orders)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
            .HasMany(p => p.likes)
            .WithOne(u => u.user)
            .HasForeignKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasMany(i => i.likechild)
                .WithOne(l => l.like)
                .HasForeignKey(x => x.likeid)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<likechild>()
                .HasOne(i => i.like)
                .WithMany(l => l.likechild)
                .HasForeignKey(x => x.likeid)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<likechild>()
                .HasOne(i => i.products)
                .WithMany()
                .HasForeignKey(x => x.productid)
                .OnDelete(DeleteBehavior.NoAction);


            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.EmailAdress).IsUnique();


            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);


        }



        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Userinrole>().HasQueryFilter(p => !p.IsRemoved);
            //       modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            //      modelBuilder.Entity<Userinrole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CategoryImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Adresse>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Defav>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Like>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<likechild>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<dCartItem>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<dOrderDetail>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
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
