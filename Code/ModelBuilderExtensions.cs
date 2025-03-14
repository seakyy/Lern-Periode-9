using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_295.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed categories, dient als Beispielsdaten für die Datenbank
            // Wenn die Datenbank funktioniert, können diese Zeilen gelöscht oder wegkommentiert werden

            // Zeilen unten Grün = Datenbank funktioniert, Beispielsdaten werden nicht gebraucht.
            //Zeilen unten normal bzw weiss = Datenbank funktioniert nicht, Beispielsdaten werden gebraucht.


            /*
             modelBuilder.Entity<Category>()
    .HasData(
        new Category { Id = 1, Name = "Raw Materials" },
        new Category { Id = 2, Name = "Packaging" },
        new Category { Id = 3, Name = "Machinery" },
        new Category { Id = 4, Name = "Tools" },
        new Category { Id = 5, Name = "Office Supplies" }
    );

modelBuilder.Entity<Product>()
    .HasData(
        // Raw Materials
        new Product { Id = 1, Sku = "RAW-001", Name = "Steel Sheets", Description = "High-quality steel sheets for construction", Price = 200.00m, IsAvailable = true, CategoryId = 1 },
        new Product { Id = 2, Sku = "RAW-002", Name = "Aluminum Rods", Description = "Lightweight aluminum rods", Price = 150.00m, IsAvailable = true, CategoryId = 1 },
        new Product { Id = 3, Sku = "RAW-003", Name = "Copper Wire", Description = "High conductivity copper wire", Price = 300.00m, IsAvailable = true, CategoryId = 1 },
        
        // Packaging
        new Product { Id = 4, Sku = "PACK-001", Name = "Cardboard Boxes", Description = "Standard size cardboard boxes", Price = 10.00m, IsAvailable = true, CategoryId = 2 },
        new Product { Id = 5, Sku = "PACK-002", Name = "Plastic Wrap", Description = "Durable plastic wrap for packaging", Price = 15.00m, IsAvailable = true, CategoryId = 2 },
        new Product { Id = 6, Sku = "PACK-003", Name = "Bubble Wrap", Description = "Protective bubble wrap", Price = 12.00m, IsAvailable = true, CategoryId = 2 },
        
        // Machinery
        new Product { Id = 7, Sku = "MACH-001", Name = "Forklift", Description = "Industrial forklift for warehouse operations", Price = 5000.00m, IsAvailable = true, CategoryId = 3 },
        new Product { Id = 8, Sku = "MACH-002", Name = "Conveyor Belt", Description = "Automated conveyor belt system", Price = 7500.00m, IsAvailable = true, CategoryId = 3 },
        
        // Tools
        new Product { Id = 9, Sku = "TOOL-001", Name = "Drill Machine", Description = "Cordless power drill", Price = 100.00m, IsAvailable = true, CategoryId = 4 },
        new Product { Id = 10, Sku = "TOOL-002", Name = "Wrench Set", Description = "Set of adjustable wrenches", Price = 50.00m, IsAvailable = true, CategoryId = 4 },
        new Product { Id = 11, Sku = "TOOL-003", Name = "Screwdriver Kit", Description = "Precision screwdriver set", Price = 30.00m, IsAvailable = true, CategoryId = 4 },
        
        // Office Supplies
        new Product { Id = 12, Sku = "OFFICE-001", Name = "Printer Paper", Description = "A4 size printer paper", Price = 5.00m, IsAvailable = true, CategoryId = 5 },
        new Product { Id = 13, Sku = "OFFICE-002", Name = "Pens", Description = "Ballpoint pen set", Price = 8.00m, IsAvailable = true, CategoryId = 5 },
        new Product { Id = 14, Sku = "OFFICE-003", Name = "Stapler", Description = "Heavy-duty office stapler", Price = 12.00m, IsAvailable = true, CategoryId = 5 }
    );
             
            */
        }
    }
}
