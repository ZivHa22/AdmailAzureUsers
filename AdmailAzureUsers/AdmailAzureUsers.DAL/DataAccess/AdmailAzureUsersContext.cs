using System;
using System.Collections.Generic;
using AdmailAzureUsers.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmailAzureUsers.DAL.DataAccess;

public partial class AdmailAzureUsersContext : DbContext
{
    public AdmailAzureUsersContext()
    {
    }

    public AdmailAzureUsersContext(DbContextOptions<AdmailAzureUsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AzureUser> AzureUsers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DV8BF2T\\SQLEXPRESS;Database=AdmailAzureUsers;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AzureUser>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Domain).HasMaxLength(50);
            entity.Property(e => e.ClientId).HasMaxLength(50);
            entity.Property(e => e.ClientSecret).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
