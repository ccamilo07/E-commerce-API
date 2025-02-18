using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    using Entity.Models;
    using Microsoft.EntityFrameworkCore;
    using Mysqlx.Crud;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Agrega tus tablas aquí
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<City> City {  get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
    }

}
