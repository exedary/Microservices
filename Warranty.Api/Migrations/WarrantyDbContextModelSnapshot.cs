﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Warranty.Api.Infrastructure.Database;

namespace Warranty.Api.Migrations
{
    [DbContext(typeof(WarrantyDbContext))]
    partial class WarrantyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Warranty.Api.Domain.Warranty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Comment")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<Guid>("ItemUid")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<TimeSpan>("WarrantyDate")
                        .HasColumnType("interval");

                    b.HasKey("Id")
                        .HasName("warranty_pkey");

                    b.HasIndex("ItemUid")
                        .IsUnique()
                        .HasDatabaseName("idx_warranty_item_uid");

                    b.ToTable("warranty");
                });
#pragma warning restore 612, 618
        }
    }
}
