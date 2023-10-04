﻿// <auto-generated />
using System;
using BrutePasta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrutePasta.Migrations
{
    [DbContext(typeof(BrutePastaDbContext))]
    [Migration("20231004012842_AlteracaoClientAndAdress7")]
    partial class AlteracaoClientAndAdress7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BrutePasta.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AddressId");

                    b.HasIndex("ClientId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BrutePasta.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BrutePasta.Models.DeliveryMan", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("OrderTax")
                        .HasColumnType("float");

                    b.HasKey("Cpf");

                    b.ToTable("DeliveryMan");
                });

            modelBuilder.Entity("BrutePasta.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantOrderId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RestaurantOrderId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("BrutePasta.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("float");

                    b.HasKey("PaymentId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("BrutePasta.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("BrutePasta.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("QtyAvailable")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BrutePasta.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("BrutePasta.Models.RestaurantOrder", b =>
                {
                    b.Property<int>("RestaurantOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryManCpf")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantOrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryManCpf");

                    b.HasIndex("PaymentId");

                    b.ToTable("RestaurantOrder");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DeliveryManCpf")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LicensePlate");

                    b.HasIndex("DeliveryManCpf");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("BrutePasta.Models.Address", b =>
                {
                    b.HasOne("BrutePasta.Models.Client", "Client")
                        .WithMany("Address")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BrutePasta.Models.Item", b =>
                {
                    b.HasOne("BrutePasta.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("BrutePasta.Models.RestaurantOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("RestaurantOrderId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BrutePasta.Models.Payment", b =>
                {
                    b.HasOne("BrutePasta.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("BrutePasta.Models.Product", b =>
                {
                    b.HasOne("BrutePasta.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BrutePasta.Models.RestaurantOrder", b =>
                {
                    b.HasOne("BrutePasta.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrutePasta.Models.DeliveryMan", "DeliveryMan")
                        .WithMany()
                        .HasForeignKey("DeliveryManCpf");

                    b.HasOne("BrutePasta.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("DeliveryMan");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("BrutePasta.Models.DeliveryMan", "DeliveryMan")
                        .WithMany()
                        .HasForeignKey("DeliveryManCpf");

                    b.Navigation("DeliveryMan");
                });

            modelBuilder.Entity("BrutePasta.Models.Client", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("BrutePasta.Models.RestaurantOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
