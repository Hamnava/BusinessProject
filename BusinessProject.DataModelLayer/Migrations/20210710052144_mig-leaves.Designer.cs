﻿// <auto-generated />
using System;
using BusinessProject.DataModelLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessProject.DataModelLayer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210710052144_mig-leaves")]
    partial class migleaves
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.Leave", b =>
                {
                    b.Property<int>("LeaveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FromDate_Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FromTime_Saati")
                        .HasColumnType("datetime2");

                    b.Property<byte>("LeaveAccept")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("LeaveRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("LeaveType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("ToDate_Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ToTime_Saati")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID_Confirm")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID_Request")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LeaveID");

                    b.HasIndex("UserID_Confirm");

                    b.HasIndex("UserID_Request");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<float>("MainSalary")
                        .HasColumnType("real");

                    b.Property<float>("PayedAmount")
                        .HasColumnType("real");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("RemianSalary")
                        .HasColumnType("real");

                    b.Property<float>("Tax")
                        .HasColumnType("real");

                    b.Property<float>("TotalPayed")
                        .HasColumnType("real");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("bonus")
                        .HasColumnType("real");

                    b.HasKey("PaymentId");

                    b.HasIndex("JobID");

                    b.HasIndex("UserID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.SystemJobs", b =>
                {
                    b.Property<int>("JobsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobsLevel")
                        .HasColumnType("int");

                    b.Property<string>("JobsName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobsID");

                    b.ToTable("SystemJobs_tbl");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.SystemRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.SystemUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MilliCode")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignatureImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.UserJob", b =>
                {
                    b.Property<int>("UserJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndJobDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHaveJob")
                        .HasColumnType("bit");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartJobDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserJobId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("UserJobs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.Leave", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", "User_Confirm")
                        .WithMany()
                        .HasForeignKey("UserID_Confirm");

                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", "User_Request")
                        .WithMany()
                        .HasForeignKey("UserID_Request");

                    b.Navigation("User_Confirm");

                    b.Navigation("User_Request");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.Payment", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemJobs", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Jobs");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessProject.DataModelLayer.Entities.UserJob", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemJobs", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Jobs");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BusinessProject.DataModelLayer.Entities.SystemUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
