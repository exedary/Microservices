﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Warehouse.Api.Infrastructure.Database;

namespace Warehouse.Api.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    [Migration("20210106122022_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Warehouse.Api.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AvailableCount")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id")
                        .HasName("items_pkey");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableCount = 10000,
                            Model = "LEGO 8070",
                            Size = "M"
                        },
                        new
                        {
                            Id = 2,
                            AvailableCount = 10000,
                            Model = "LEGO 8880",
                            Size = "L"
                        },
                        new
                        {
                            Id = 3,
                            AvailableCount = 10000,
                            Model = "LEGO 42070",
                            Size = "L"
                        });
                });

            modelBuilder.Entity("Warehouse.Api.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Canceled")
                        .HasColumnType("boolean");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<Guid>("OrderItemUid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderUid")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("order_item_pkey");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderItemUid")
                        .IsUnique()
                        .HasDatabaseName("idx_order_item_order_item_uid");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Warehouse.Api.Domain.Order", b =>
                {
                    b.HasOne("Warehouse.Api.Domain.Item", "Item")
                        .WithMany("Orders")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("fk_order_item_item_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Warehouse.Api.Domain.Item", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
