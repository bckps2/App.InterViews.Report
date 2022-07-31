﻿// <auto-generated />
using System;
using App.InterViews.Report.Db.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.InterViews.Report.Migrations.Migrations
{
    [DbContext(typeof(DbDataContext))]
    partial class DbDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Company", b =>
                {
                    b.Property<int>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompany"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCompany");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InformationInterView", b =>
                {
                    b.Property<int>("IdInformation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInformation"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInterView")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterViewIdInterView")
                        .HasColumnType("int");

                    b.Property<string>("InterViewersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeInterView")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdInformation");

                    b.HasIndex("InterViewIdInterView");

                    b.ToTable("InformationInterViews");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterView", b =>
                {
                    b.Property<int>("IdInterView")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInterView"), 1L, 1);

                    b.Property<int>("CompanyIdCompany")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RangeSalarial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInterView");

                    b.HasIndex("CompanyIdCompany");

                    b.ToTable("InterViews");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InformationInterView", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.InterView", "InterView")
                        .WithMany("InformationInterViews")
                        .HasForeignKey("InterViewIdInterView")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterView");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterView", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.Company", "Company")
                        .WithMany("InterViews")
                        .HasForeignKey("CompanyIdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Company", b =>
                {
                    b.Navigation("InterViews");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterView", b =>
                {
                    b.Navigation("InformationInterViews");
                });
#pragma warning restore 612, 618
        }
    }
}
