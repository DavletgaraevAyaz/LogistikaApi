using LogistikaApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data;

namespace LogistikaApi.DBContext
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecord { get; set; }
        public DbSet<MovementType> MovementType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductMovement> ProductMovements { get; set; }
        public DbSet<Model.Route> Route { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
