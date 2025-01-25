﻿// <auto-generated />
using System;
using Ecommerce_WatchShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce_WatchShop.Migrations
{
    [DbContext(typeof(DongHoContext))]
    [Migration("20250125083134_ChangeDatabase_20")]
    partial class ChangeDatabase_20
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce_WatchShop.Models.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(100)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("BillId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.BlogImage", b =>
                {
                    b.Property<int>("BlogImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogImageId"));

                    b.Property<int?>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogImageId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(100)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("varchar(200)");

                    b.Property<DateOnly?>("Dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("CustomerId");

                    b.HasIndex("AccountId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Footer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.FooterLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FooterLinks");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.ProductComment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductComments");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.ProductImage", b =>
                {
                    b.Property<int>("ProductImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductImageId"));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.ProductRating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRatings");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Type")
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Account", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Bill", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.BlogImage", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Blog", "Blog")
                        .WithMany("BlogImages")
                        .HasForeignKey("BlogId");

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Customer", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Favorite", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Customer", "Customer")
                        .WithMany("Favorites")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Ecommerce_WatchShop.Models.Product", "Product")
                        .WithMany("Favorites")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Invoice", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Bill", "Bill")
                        .WithMany("Invoices")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce_WatchShop.Models.Product", "Product")
                        .WithMany("Invoices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Product", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("Ecommerce_WatchShop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.ProductComment", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Customer", "Customer")
                        .WithMany("ProductComments")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Ecommerce_WatchShop.Models.Product", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.ProductImage", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.ProductRating", b =>
                {
                    b.HasOne("Ecommerce_WatchShop.Models.Customer", "Customer")
                        .WithMany("ProductRatings")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Ecommerce_WatchShop.Models.Product", "Product")
                        .WithMany("ProductRatings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Account", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Bill", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Blog", b =>
                {
                    b.Navigation("BlogImages");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Favorites");

                    b.Navigation("ProductComments");

                    b.Navigation("ProductRatings");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Product", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Invoices");

                    b.Navigation("ProductComments");

                    b.Navigation("ProductImages");

                    b.Navigation("ProductRatings");
                });

            modelBuilder.Entity("Ecommerce_WatchShop.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
