using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;initial Catalog=MultiShopCargoDb;User=sa;Password=Admin123456*");
        }
        public DbSet<CargoCompany> cargoCompanies { get; set; }
        public DbSet<CargoDetail> cargoDetails { get; set; }
        public DbSet<CargoCustomer> cargoCustomers { get; set; }
        public DbSet<CargoOperation> cargoOperations { get; set; }
    }
}
