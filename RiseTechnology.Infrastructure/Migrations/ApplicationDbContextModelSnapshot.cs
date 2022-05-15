﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiseTechnology.Infrastructure.Persistence.Context;

#nullable disable

namespace RiseTechnology.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RiseTechnology.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Company = "Ys Company",
                            Name = "Yildirim",
                            Surname = "Soker"
                        },
                        new
                        {
                            Id = 2,
                            Company = "AV Company",
                            Name = "Ali",
                            Surname = "Veli"
                        });
                });

            modelBuilder.Entity("RiseTechnology.Domain.Entities.PersonContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactDescription")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("ContactType")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonContact", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactDescription = "yildirimsoker@gmail.com",
                            ContactType = "Email",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            ContactDescription = "05380867056",
                            ContactType = "PhoneNumber",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 3,
                            ContactDescription = "27.814786,22.053289",
                            ContactType = "Location",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 4,
                            ContactDescription = "aliveli@gmail.com",
                            ContactType = "Email",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 5,
                            ContactDescription = "05422305462",
                            ContactType = "PhoneNumber",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 6,
                            ContactDescription = "39.482845,60.399189",
                            ContactType = "Location",
                            PersonId = 2
                        });
                });

            modelBuilder.Entity("RiseTechnology.Domain.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ReportPath")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ReportStatusType")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("RiseTechnology.Domain.Entities.PersonContact", b =>
                {
                    b.HasOne("RiseTechnology.Domain.Entities.Person", "Person")
                        .WithMany("PersonContact")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("RiseTechnology.Domain.Entities.Person", b =>
                {
                    b.Navigation("PersonContact");
                });
#pragma warning restore 612, 618
        }
    }
}
