using metal.Domain.Entities.Carts;
using metal.Domain.Entities.Finance;
using metal.Domain.Entities.HomePages;
using metal.Domain.Entities.likedto;
using metal.Domain.Entities.Media;
using metal.Domain.Entities.Orders;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace metal.Application.InterFace.Contexts
{
    public interface IDataBaseContext
    {

        public DbSet<Role> Roles { get; set; }
        public DbSet<Userinrole> Userinroles { get; set; }
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
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangeAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
