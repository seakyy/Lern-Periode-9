using Microsoft.EntityFrameworkCore;
using System;

namespace WebAPI_295.Models
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Datenbank mit Beispieldaten befüllen
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { Id = 1, Name = "Elektronik" },
                new ItemCategory { Id = 2, Name = "Werkzeuge" },
                new ItemCategory { Id = 3, Name = "Bürobedarf" },
                new ItemCategory { Id = 4, Name = "Möbel" },
                new ItemCategory { Id = 5, Name = "Lebensmittel" }
            );

            modelBuilder.Entity<Item>().HasData(
    new Item { Id = 1, Sku = "ELEC-101", Name = "Gaming Laptop", Description = "Leistungsfähiger Laptop mit RTX 4070", Price = 1599.99M, IsAvailable = true, CategoryId = 1 },
    new Item { Id = 2, Sku = "ELEC-102", Name = "4K Monitor", Description = "32-Zoll UHD-Monitor mit HDR", Price = 399.99M, IsAvailable = true, CategoryId = 1 },
    new Item { Id = 3, Sku = "ELEC-103", Name = "Wireless Kopfhörer", Description = "Noise Cancelling Bluetooth-Kopfhörer", Price = 199.99M, IsAvailable = true, CategoryId = 1 },
    new Item { Id = 4, Sku = "ELEC-104", Name = "Smartphone", Description = "5G-Smartphone mit OLED-Display", Price = 899.99M, IsAvailable = true, CategoryId = 1 },

    new Item { Id = 5, Sku = "TOOL-201", Name = "Akkuschrauber", Description = "18V Akkuschrauber mit 2 Akkus", Price = 79.99M, IsAvailable = true, CategoryId = 2 },
    new Item { Id = 6, Sku = "TOOL-202", Name = "Bohrmaschine", Description = "750W Hochleistungsbohrer", Price = 129.99M, IsAvailable = true, CategoryId = 2 },
    new Item { Id = 7, Sku = "TOOL-203", Name = "Werkzeugkasten", Description = "50-teiliges Werkzeugset", Price = 59.99M, IsAvailable = true, CategoryId = 2 },
    new Item { Id = 8, Sku = "TOOL-204", Name = "Schweißgerät", Description = "Profi-Schweißgerät für Industrie", Price = 499.99M, IsAvailable = true, CategoryId = 2 },

    new Item { Id = 9, Sku = "OFF-301", Name = "Bürostuhl", Description = "Ergonomischer Drehstuhl mit Armlehnen", Price = 149.99M, IsAvailable = true, CategoryId = 3 },
    new Item { Id = 10, Sku = "OFF-302", Name = "Schreibtisch", Description = "Höhenverstellbarer Schreibtisch", Price = 299.99M, IsAvailable = true, CategoryId = 3 },
    new Item { Id = 11, Sku = "OFF-303", Name = "Drucker", Description = "Laserdrucker für Bürogebrauch", Price = 199.99M, IsAvailable = true, CategoryId = 3 },
    new Item { Id = 12, Sku = "OFF-304", Name = "Tintenpatronen", Description = "Packung mit 4 Patronen (CMYK)", Price = 49.99M, IsAvailable = true, CategoryId = 3 },

    new Item { Id = 13, Sku = "FURN-401", Name = "Regal", Description = "Modulares Regal mit 5 Ebenen", Price = 79.99M, IsAvailable = true, CategoryId = 4 },
    new Item { Id = 14, Sku = "FURN-402", Name = "Couch", Description = "3-Sitzer Sofa mit Kunstlederbezug", Price = 599.99M, IsAvailable = true, CategoryId = 4 },
    new Item { Id = 15, Sku = "FURN-403", Name = "Schrank", Description = "Kleiderschrank mit Schiebetüren", Price = 349.99M, IsAvailable = true, CategoryId = 4 },
    new Item { Id = 16, Sku = "FURN-404", Name = "Esstisch", Description = "Holztisch für 6 Personen", Price = 499.99M, IsAvailable = true, CategoryId = 4 },

    new Item { Id = 17, Sku = "FOOD-501", Name = "Bio-Kaffee", Description = "500g Arabica-Kaffeebohnen", Price = 12.99M, IsAvailable = true, CategoryId = 5 },
    new Item { Id = 18, Sku = "FOOD-502", Name = "Müsli", Description = "1kg Bio-Müsli mit Nüssen", Price = 7.99M, IsAvailable = true, CategoryId = 5 },
    new Item { Id = 19, Sku = "FOOD-503", Name = "Olivenöl", Description = "1L kaltgepresstes Olivenöl", Price = 14.99M, IsAvailable = true, CategoryId = 5 },
    new Item { Id = 20, Sku = "FOOD-504", Name = "Mineralwasser", Description = "6x 1,5L Sprudelwasser", Price = 3.99M, IsAvailable = true, CategoryId = 5 }
);


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "password", Role = "Admin" },
                new User { Id = 2, Username = "lagerist", Password = "password", Role = "WarehouseManager" },
                new User { Id = 3, Username = "user1", Password = "password", Role = "User" }
            );
        }
    }
}