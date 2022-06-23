﻿// <auto-generated />
using System;
using EstoqueAlarmaq.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstoqueAlarmaq.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EstoqueAlarmaq.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.OrderService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Client")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tecnico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderServices");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.OrderServiceProductObject", b =>
                {
                    b.Property<int>("IdOrderServiceProductObject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdOrderService")
                        .HasColumnType("int");

                    b.Property<int>("IdProductObject")
                        .HasColumnType("int");

                    b.Property<int?>("OrderServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductObjectId")
                        .HasColumnType("int");

                    b.HasKey("IdOrderServiceProductObject");

                    b.HasIndex("OrderServiceId");

                    b.HasIndex("ProductObjectId");

                    b.ToTable("OrderServiceProductObject");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.ProductObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsObjects");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.OrderServiceProductObject", b =>
                {
                    b.HasOne("EstoqueAlarmaq.Domain.OrderService", "OrderService")
                        .WithMany("OrderServiceProductObjects")
                        .HasForeignKey("OrderServiceId");

                    b.HasOne("EstoqueAlarmaq.Domain.ProductObject", "ProductObject")
                        .WithMany()
                        .HasForeignKey("ProductObjectId");

                    b.Navigation("OrderService");

                    b.Navigation("ProductObject");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.ProductObject", b =>
                {
                    b.HasOne("EstoqueAlarmaq.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EstoqueAlarmaq.Domain.OrderService", b =>
                {
                    b.Navigation("OrderServiceProductObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
