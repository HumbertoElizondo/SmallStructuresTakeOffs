using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmallStructuresTakeOffs.Models
{
    public class EFCoreDBcontext : DbContext
    {
        public EFCoreDBcontext(DbContextOptions<EFCoreDBcontext> opts)
            : base(opts) { }

        public DbSet<SmallStructure> SmallStructures { get; set; }
        public DbSet<C1580CB> C1580CBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C1580CB>(ar => ar.Property(p => p.C1580CBHeight).HasColumnType("decimal(18,4)"));
        }
    }
}
//namespace DataApp.Models
//{
//    public class EFDatabaseContext : DbContext
//    {

//        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opts)
//            : base(opts) { }

//        public DbSet<Product> Products { get; set; }
//        public DbSet<Supplier> Suppliers { get; set; }
//    }
//}
