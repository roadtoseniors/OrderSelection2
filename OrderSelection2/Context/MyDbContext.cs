using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrderSelection2.Entities;

namespace OrderSelection2.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categotial> Categotials { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicesOrder> ServicesOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=orderselection2;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categotial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categotial_pk");

            entity.ToTable("categotial");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Categorial).HasColumnName("categorial");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pk");

            entity.ToTable("clients");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DateOfBirthd).HasColumnName("date_of_birthd");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.PersonalSale).HasColumnName("personal_sale");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employers_pk");

            entity.ToTable("employers");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DateOfBirthd).HasColumnName("date_of_birthd");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Passport).HasColumnName("passport");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.TypeLogin).HasColumnName("type_login");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Employers)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("employers_role_id_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pk");

            entity.ToTable("order");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Categorial).HasColumnName("categorial");
            entity.Property(e => e.ClientsId).HasColumnName("clients_id");
            entity.Property(e => e.DateCloseOrder).HasColumnName("date_close_order");
            entity.Property(e => e.DateOpenOrder).HasColumnName("date_open_order");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ExecutorId).HasColumnName("executor_id");
            entity.Property(e => e.InArchive).HasColumnName("inArchive?");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.Sum).HasColumnName("sum");

            entity.HasOne(d => d.CategorialNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Categorial)
                .HasConstraintName("order_categotial_id_fk");

            entity.HasOne(d => d.Clients).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientsId)
                .HasConstraintName("order_clients_id_fk");

            entity.HasOne(d => d.Manager).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("order_employers_id_fk");

            entity.HasOne(d => d.OrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatus)
                .HasConstraintName("order_order_status_id_fk");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_status_pk");

            entity.ToTable("order_status");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.OrderStatus1).HasColumnName("order_status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pk");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Role1).HasColumnName("role");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pk");

            entity.ToTable("services");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.NameServices).HasColumnName("name_services");
            entity.Property(e => e.PriceServices).HasColumnName("price_services");
        });

        modelBuilder.Entity<ServicesOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_order_pk");

            entity.ToTable("services_order");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ServicesId).HasColumnName("services_id");

            entity.HasOne(d => d.Order).WithMany(p => p.ServicesOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("services_order_order_id_fk");

            entity.HasOne(d => d.Services).WithMany(p => p.ServicesOrders)
                .HasForeignKey(d => d.ServicesId)
                .HasConstraintName("services_order_services_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
