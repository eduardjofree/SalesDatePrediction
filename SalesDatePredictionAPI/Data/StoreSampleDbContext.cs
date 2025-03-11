using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Data
{
    public class StoreSampleDbContext : DbContext
    {
        public StoreSampleDbContext(DbContextOptions<StoreSampleDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir claves primarias
            modelBuilder.Entity<Customer>().HasKey(c => c.custid);
            modelBuilder.Entity<Order>().HasKey(o => o.orderid);
            modelBuilder.Entity<Employee>().HasKey(e => e.empid);
            modelBuilder.Entity<Shipper>().HasKey(s => s.shipperid);
            modelBuilder.Entity<Product>().HasKey(p => p.productid);
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.orderid, od.productid });

            // Configurar relaciones
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Employee)
            //    .WithMany(e => e.Orders)
            //    .HasForeignKey(o => o.EmpId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Shipper)
            //    .WithMany(s => s.Orders)
            //    .HasForeignKey(o => o.ShipperId);

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Order)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.OrderId);

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Product)
            //    .WithMany(p => p.OrderDetails)
            //    .HasForeignKey(od => od.ProductId);
        }
    }
}
