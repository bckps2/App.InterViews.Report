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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterView", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInterView")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdProcess")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeInterView")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdProcess");

                    b.ToTable("InterViews");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Interviewer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("JobPosition")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Interviewers");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterviewInterviewer", b =>
                {
                    b.Property<Guid?>("InterviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InterviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InterviewId", "InterviewerId");

                    b.HasIndex("InterviewerId");

                    b.ToTable("InterviewInterviewers");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RangeSalarial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("IdentificationDocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.UserCompany", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("UserCompanies");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterView", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.Process", "Process")
                        .WithMany("Interviews")
                        .HasForeignKey("IdProcess")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Interviewer", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.Company", "Company")
                        .WithMany("Interviewers")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterviewInterviewer", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.InterView", "InterView")
                        .WithMany("InterviewInterviewers")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.InterViews.Report.Library.Entities.Interviewer", "Interviewer")
                        .WithMany("InterviewInterviewers")
                        .HasForeignKey("InterviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterView");

                    b.Navigation("Interviewer");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Process", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.Company", "Company")
                        .WithMany("Process")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.User", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.UserCompany", b =>
                {
                    b.HasOne("App.InterViews.Report.Library.Entities.Company", "Company")
                        .WithMany("UserCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.InterViews.Report.Library.Entities.User", "User")
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Company", b =>
                {
                    b.Navigation("Interviewers");

                    b.Navigation("Process");

                    b.Navigation("UserCompanies");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.InterView", b =>
                {
                    b.Navigation("InterviewInterviewers");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Interviewer", b =>
                {
                    b.Navigation("InterviewInterviewers");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Process", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("App.InterViews.Report.Library.Entities.User", b =>
                {
                    b.Navigation("UserCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
