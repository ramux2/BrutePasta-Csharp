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
    [Migration("20230925231345_AddPaymentIntoOrder")]
    partial class AddPaymentIntoOrder
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

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BrutePasta.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
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

                    b.HasKey("ClientId");

                    b.HasIndex("AddressId");

                    b.ToTable("Client");
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

            modelBuilder.Entity("BrutePasta.Models.Motoboy", b =>
                {
                    b.Property<int>("MotoboyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("OrderTax")
                        .HasColumnType("float");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("MotoboyId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Motoboy");
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

                    b.Property<int>("MotoboyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantOrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("MotoboyId");

                    b.HasIndex("PaymentId");

                    b.ToTable("RestaurantOrder");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("BrutePasta.Models.Client", b =>
                {
                    b.HasOne("BrutePasta.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
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

            modelBuilder.Entity("BrutePasta.Models.Motoboy", b =>
                {
                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
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
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrutePasta.Models.Motoboy", "Motoboy")
                        .WithMany()
                        .HasForeignKey("MotoboyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrutePasta.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Motoboy");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BrutePasta.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BrutePasta.Models.RestaurantOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
