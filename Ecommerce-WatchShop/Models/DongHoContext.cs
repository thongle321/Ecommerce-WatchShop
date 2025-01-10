using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_WatchShop.Models;

public partial class DongHoContext : DbContext
{
    public DongHoContext()
    {
    }

    public DongHoContext(DbContextOptions<DongHoContext> options) : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogImage> BlogImages { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductComment> ProductComments { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductRating> ProductRatings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<WarehouseReceipt> WarehouseReceipts { get; set; }

    public virtual DbSet<Footer> Footers { get; set; }

    public virtual DbSet<FooterLink> FooterLinks { get; set; }
}
