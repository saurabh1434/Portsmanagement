﻿// <auto-generated />
using System;
using MaritimeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PortsManagement.Migrations
{
    [DbContext(typeof(MaritimeContext))]
    [Migration("20240604190507_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortsManagement.Models.Port", b =>
                {
                    b.Property<string>("PortCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortCode");

                    b.HasIndex("PortCode")
                        .IsUnique();

                    b.ToTable("Ports");

                    b.HasData(
                        new
                        {
                            PortCode = "PORT1",
                            AddedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9752),
                            LastEditedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9756),
                            Name = "Port One"
                        },
                        new
                        {
                            PortCode = "PORT2",
                            AddedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9757),
                            LastEditedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9758),
                            Name = "Port Two"
                        });
                });

            modelBuilder.Entity("PortsManagement.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("PortCode");

                    b.HasIndex("Name", "PortCode")
                        .IsUnique();

                    b.ToTable("Terminals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9859),
                            IsActive = true,
                            LastEditedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9860),
                            Latitude = 10.0,
                            Longitude = 20.0,
                            Name = "Terminal 1A",
                            PortCode = "PORT1"
                        },
                        new
                        {
                            Id = 2,
                            AddedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9862),
                            IsActive = true,
                            LastEditedDate = new DateTime(2024, 6, 4, 19, 5, 6, 767, DateTimeKind.Utc).AddTicks(9862),
                            Latitude = 30.0,
                            Longitude = 40.0,
                            Name = "Terminal 2A",
                            PortCode = "PORT2"
                        });
                });

            modelBuilder.Entity("PortsManagement.Models.Terminal", b =>
                {
                    b.HasOne("PortsManagement.Models.Port", "Port")
                        .WithMany("Terminals")
                        .HasForeignKey("PortCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Port");
                });

            modelBuilder.Entity("PortsManagement.Models.Port", b =>
                {
                    b.Navigation("Terminals");
                });
#pragma warning restore 612, 618
        }
    }
}
