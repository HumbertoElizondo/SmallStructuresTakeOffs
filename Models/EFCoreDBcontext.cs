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

        public DbSet<CatchBasin> CatchBasins { get; set; }
        public DbSet<CBc1580> CBc1580s { get; set; }
        public DbSet<CBc1581> CBc1581s { get; set; }
        public DbSet<CBc1510SglT1> CBc1510SglT1s { get; set; }
        public DbSet<CBc1520T3> CBc1520T3s { get; set; }
        public DbSet<CBc1530> CBc1530s { get; set; }
        public DbSet<CBc1591> CBc1591s { get; set; }
        public DbSet<CBc1592> CBc1592s { get; set; }
        public DbSet<CBd21> CBd21s { get; set; }
        public DbSet<CBdetD> cBdetDs { get; set; }
        public DbSet<CBdetE> cBdetEs { get; set; }
        //public DbSet<SD630Headwall> SD630Headwalls { get; set; }
        //public DbSet<SmallStructure> SmallStructures { get; set; }
        public DbSet<P1569_1> P1569_1s { get; set; }
        public DbSet<CBp1570> CBp1570s { get; set; }
        public DbSet<CBp1572> CBp1572s { get; set; }
        public DbSet<CBp1569_2> CBp1569_2s { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RebarRequest> RebarRequests { get; set; }
        public DbSet<RebarWasting> RebarWastings { get; set; }
        public DbSet<RebarToPurchase> RebarToPurchase { get; set; }
        //public DbSet<Headwall> Headwalls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CBc1580>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBc1510SglT1>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBc1520T3>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBc1530>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBc1591>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBc1592>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBd21>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBdetD>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBdetE>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBp1569_2>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBp1570>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBp1572>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<CBc1581>(ar => ar.Property(p => p.CBHeight).HasColumnType("decimal(18,2)"));

        }

    }
}
