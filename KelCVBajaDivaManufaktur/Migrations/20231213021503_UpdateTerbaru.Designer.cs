﻿// <auto-generated />
using System;
using KelCVBajaDivaManufaktur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KelCVBajaDivaManufaktur.Migrations
{
    [DbContext(typeof(KelCVBajaDivaManufakturContext))]
    [Migration("20231213021503_UpdateTerbaru")]
    partial class UpdateTerbaru
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KelCVBajaDivaManufaktur.Models.BahanBaku", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NamaBahan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Satuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BahanBaku");
                });

            modelBuilder.Entity("KelCVBajaDivaManufaktur.Models.Pengguna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HakAkses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaPengguna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pengguna");
                });

            modelBuilder.Entity("KelCVBajaDivaManufaktur.Models.Produk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Deskripsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("GambarProduk")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Kategori")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaProduk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produk");
                });

            modelBuilder.Entity("KelCVBajaDivaManufaktur.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaSupplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoHP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("KelCVBajaDivaManufaktur.Models.Transaksi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CaraBayar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Jumlah")
                        .HasColumnType("int");

                    b.Property<string>("NamaMenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaPelanggan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TanggalBeli")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalBayar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Transaksi");
                });
#pragma warning restore 612, 618
        }
    }
}
