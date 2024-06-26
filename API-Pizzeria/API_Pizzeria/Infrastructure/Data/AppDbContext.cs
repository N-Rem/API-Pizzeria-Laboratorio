using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //dbset recive una entidad y permite traducirlo a una tabla y la tabla con ese nombre se traduce a entidad
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => up.Id);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserProducts)
                .HasForeignKey(up => up.ProductId);


            modelBuilder.Entity<User>()
                .Property(u => u.Rol)
                .HasConversion(new EnumToStringConverter<User.UserRol>());

            modelBuilder.Entity<User>().HasData(CreateUserSeedData());
            modelBuilder.Entity<Product>().HasData(CreateProductSeedData());

        }

        private User[] CreateUserSeedData()
        {
            return new User[]
            {
            new User { Id = 1, UserName = "Nicolas", Password = "Nicolas123", Rol = User.UserRol.SuperAdmin },
            new User { Id = 2, UserName = "Anabella", Password = "Anabella123", Rol = User.UserRol.SuperAdmin },
            new User { Id = 3, UserName = "Delfina", Password = "Delfina123", Rol = User.UserRol.SuperAdmin },
            new User { Id = 5, UserName = "marta_admin", Password = "marta123", Rol = User.UserRol.Admin },
            new User { Id = 6, UserName = "john_admin", Password = "johnAdmin123", Rol = User.UserRol.Admin },
            new User { Id = 7, UserName = "jane_admin", Password = "janeAdmin123", Rol = User.UserRol.Admin },
            new User { Id = 8, UserName = "alice", Password = "alice123", Rol = User.UserRol.Client },
            new User { Id = 9, UserName = "bob", Password = "bob123", Rol = User.UserRol.Client },
            new User { Id = 10, UserName = "charlie", Password = "charlie123", Rol = User.UserRol.Client },
            new User { Id = 11, UserName = "dave", Password = "dave123", Rol = User.UserRol.Client },
            new User { Id = 12, UserName = "eve", Password = "eve123", Rol = User.UserRol.Client },
            new User { Id = 13, UserName = "frank", Password = "frank123", Rol = User.UserRol.Client },
            new User { Id = 14, UserName = "grace", Password = "grace123", Rol = User.UserRol.Client }
            };
        } 

        private Product[] CreateProductSeedData()
        {
            return new Product[]
            {
            new Product { Id = 1, Name = "Napolitana", Description = "Delicious pizza with tomato sauce, mozzarella, and anchovies.", Price = 10, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 2, Name = "Margherita", Description = "Classic pizza with tomato sauce, mozzarella, and fresh basil.", Price = 8, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 3, Name = "Pepperoni", Description = "Pizza with tomato sauce, mozzarella, and spicy pepperoni.", Price = 12, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 4, Name = "Hawaiian", Description = "Tropical pizza with tomato sauce, mozzarella, ham, and pineapple.", Price = 11, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 5, Name = "Four Cheese", Description = "Pizza with mozzarella, cheddar, parmesan, and gorgonzola.", Price = 13, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 6, Name = "Vegetarian", Description = "Pizza with tomato sauce, mozzarella, mushrooms, peppers, and onions.", Price = 9, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 7, Name = "Barbecue", Description = "Pizza with BBQ sauce, mozzarella, shredded chicken, onions, and corn.", Price = 14, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 8, Name = "Seafood", Description = "Pizza with tomato sauce, mozzarella, mussels, clams, and shrimp.", Price = 15, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 9, Name = "Spicy Sausage", Description = "Pizza with tomato sauce, mozzarella, and spicy Italian sausage.", Price = 13, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 10, Name = "Truffle Mushroom", Description = "Pizza with truffle cream, mozzarella, and assorted mushrooms.", Price = 16, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 11, Name = "Buffalo Chicken", Description = "Pizza with buffalo sauce, mozzarella, and spicy chicken strips.", Price = 14, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 12, Name = "Pesto Delight", Description = "Pizza with pesto sauce, mozzarella, cherry tomatoes, and arugula.", Price = 12, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 13, Name = "Mexican", Description = "Pizza with tomato sauce, mozzarella, jalapenos, and ground beef.", Price = 14, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 14, Name = "Prosciutto", Description = "Pizza with tomato sauce, mozzarella, and thinly sliced prosciutto.", Price = 15, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 15, Name = "Greek", Description = "Pizza with tomato sauce, mozzarella, feta cheese, and black olives.", Price = 13, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" },
            new Product { Id = 16, Name = "Capricciosa", Description = "Pizza with tomato sauce, mozzarella, ham, mushrooms, and artichokes.", Price = 14, Stock = 1000, ImageUrl = "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg" }

            };
        }


    }
}
