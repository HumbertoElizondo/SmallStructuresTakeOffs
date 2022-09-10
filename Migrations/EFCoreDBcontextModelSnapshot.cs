﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmallStructuresTakeOffs.Models;

#nullable disable

namespace SmallStructuresTakeOffs.Migrations
{
    [DbContext(typeof(EFCoreDBcontext))]
    partial class EFCoreDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CatchBasin", b =>
                {
                    b.Property<int>("CatchBasinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatchBasinId"), 1L, 1);

                    b.Property<decimal>("CBBaseThickness")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CBCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CBHeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CBLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CBRebFandI")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CBRebPurch")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CBSqRingL")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CBVertBars")
                        .HasColumnType("int");

                    b.Property<decimal>("CBWallThickness")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CBWidth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProjId")
                        .HasColumnType("bigint");

                    b.HasKey("CatchBasinId");

                    b.HasIndex("ProjId");

                    b.ToTable("CatchBasins");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CatchBasin");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.P1569_1M", b =>
                {
                    b.Property<int>("P1569_1MId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("P1569_1MId"), 1L, 1);

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("P1569_1MCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P1569_1MDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Reb3FandI")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Reb3Purch")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Reb4FandI")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Reb4Purch")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("P1569_1MId");

                    b.ToTable("P1569_1Ms");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProjectId"), 1L, 1);

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.RebarToPurchase", b =>
                {
                    b.Property<int>("RebarToPurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RebarToPurchaseId"), 1L, 1);

                    b.Property<decimal>("RebarNomLengths")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RebarRequest")
                        .HasColumnType("int");

                    b.Property<int>("RebarToPurchaseNomination")
                        .HasColumnType("int");

                    b.Property<int>("RebarToPurchaseQuantity")
                        .HasColumnType("int");

                    b.HasKey("RebarToPurchaseId");

                    b.ToTable("RebarToPurchase");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.RebarWasting", b =>
                {
                    b.Property<int>("RebarWastingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RebarWastingId"), 1L, 1);

                    b.Property<bool>("IsItAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("RebarRequestId")
                        .HasColumnType("int");

                    b.Property<decimal>("RebarWastingLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RebarWastingNomination")
                        .HasColumnType("int");

                    b.Property<int>("RebarWastingQuantity")
                        .HasColumnType("int");

                    b.Property<int>("RebarWastingReqNo")
                        .HasColumnType("int");

                    b.Property<int>("ReqNo")
                        .HasColumnType("int");

                    b.HasKey("RebarWastingId");

                    b.HasIndex("RebarRequestId");

                    b.ToTable("RebarWastings");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.SD630Headwall", b =>
                {
                    b.Property<int>("SD630HeadwallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SD630HeadwallId"), 1L, 1);

                    b.Property<string>("HWCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PipeNo")
                        .HasColumnType("int");

                    b.Property<decimal>("RebNo4Purch")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RebNo4Req")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SD630Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SD630_A")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_B")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_C")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_D")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_E")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_F")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_G")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_I_D")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SD630_L")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ThisHeadwall")
                        .HasColumnType("int");

                    b.HasKey("SD630HeadwallId");

                    b.ToTable("SD630Headwalls");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.SmallStructure", b =>
                {
                    b.Property<int>("SmStId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SmStId"), 1L, 1);

                    b.Property<string>("HWcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThisStructure")
                        .HasColumnType("int");

                    b.HasKey("SmStId");

                    b.ToTable("SmallStructures");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.RebarRequest", b =>
                {
                    b.Property<int>("RebarRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RebarRequestId"), 1L, 1);

                    b.Property<long?>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("RebReqDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RebReqProjId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("RebarRequestLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RebarRequestNomination")
                        .HasColumnType("int");

                    b.Property<int>("RebarRequestQty")
                        .HasColumnType("int");

                    b.Property<string>("Structure")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RebarRequestId");

                    b.HasIndex("ProjectId");

                    b.ToTable("RebarRequests");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBc1510SglT1", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.HasDiscriminator().HasValue("CBc1510SglT1");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBc1520T3", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.Property<int>("CBConfg")
                        .HasColumnType("int")
                        .HasColumnName("CBc1520T3_CBConfg");

                    b.Property<int>("CBwings")
                        .HasColumnType("int")
                        .HasColumnName("CBc1520T3_CBwings");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CBc1520T3_Genres");

                    b.HasDiscriminator().HasValue("CBc1520T3");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBc1580", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.HasDiscriminator().HasValue("CBc1580");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBc1591", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.Property<int>("CBConfg")
                        .HasColumnType("int")
                        .HasColumnName("CBc1591_CBConfg");

                    b.Property<int>("CBCurbType")
                        .HasColumnType("int")
                        .HasColumnName("CBc1591_CBCurbType");

                    b.Property<int>("CBSlottedDrain")
                        .HasColumnType("int")
                        .HasColumnName("CBc1591_CBSlottedDrain");

                    b.Property<int>("CBwings")
                        .HasColumnType("int")
                        .HasColumnName("CBc1591_CBwings");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CBc1591_Genres");

                    b.HasDiscriminator().HasValue("CBc1591");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBc1592", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.Property<int>("CBConfg")
                        .HasColumnType("int")
                        .HasColumnName("CBc1592_CBConfg");

                    b.Property<int>("CBCurbType")
                        .HasColumnType("int");

                    b.Property<int>("CBSlottedDrain")
                        .HasColumnType("int");

                    b.Property<int>("CBwings")
                        .HasColumnType("int")
                        .HasColumnName("CBc1592_CBwings");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CBc1592_Genres");

                    b.HasDiscriminator().HasValue("CBc1592");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBd21", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.HasDiscriminator().HasValue("CBd21");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CBp1569", b =>
                {
                    b.HasBaseType("SmallStructuresTakeOffs.Models.CatchBasin");

                    b.Property<int>("CBConfg")
                        .HasColumnType("int");

                    b.Property<int>("CBp1569Types")
                        .HasColumnType("int");

                    b.Property<int>("CBp1569Wings")
                        .HasColumnType("int");

                    b.Property<int>("CBwings")
                        .HasColumnType("int");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("CBp1569");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.CatchBasin", b =>
                {
                    b.HasOne("SmallStructuresTakeOffs.Models.Project", "Project")
                        .WithMany("CatchBasins")
                        .HasForeignKey("ProjId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.RebarWasting", b =>
                {
                    b.HasOne("SmallStructuresTakeOffs.RebarRequest", "RebarRequest")
                        .WithMany("RebarWastings")
                        .HasForeignKey("RebarRequestId");

                    b.Navigation("RebarRequest");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.RebarRequest", b =>
                {
                    b.HasOne("SmallStructuresTakeOffs.Models.Project", null)
                        .WithMany("RebarRequests")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.Models.Project", b =>
                {
                    b.Navigation("CatchBasins");

                    b.Navigation("RebarRequests");
                });

            modelBuilder.Entity("SmallStructuresTakeOffs.RebarRequest", b =>
                {
                    b.Navigation("RebarWastings");
                });
#pragma warning restore 612, 618
        }
    }
}
