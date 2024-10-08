﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using DbFirstExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstExample.Data;

public partial class DbFirstExampleContext : DbContext
{
    public DbFirstExampleContext(DbContextOptions<DbFirstExampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Job> Job { get; set; }

    public virtual DbSet<WorkItem> WorkItem { get; set; }

    public virtual DbSet<WorkType> WorkType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.ItemDescription)
                .IsRequired()
                .HasColumnName("Item_Description");
            entity.Property(e => e.ItemWorkItemId).HasColumnName("Item_WorkItemId");
            entity.Property(e => e.ItemWorkTypeId).HasColumnName("Item_WorkTypeId");
            entity.Property(e => e.ItemWorkTypeName)
                .IsRequired()
                .HasColumnName("Item_WorkTypeName");
            entity.Property(e => e.Title).IsRequired();
        });

        modelBuilder.Entity<WorkItem>(entity =>
        {
            entity.HasIndex(e => e.WorkTypeId, "IX_WorkItem_WorkTypeId");

            entity.Property(e => e.Description).IsRequired();

            entity.HasOne(d => d.WorkType).WithMany(p => p.WorkItem).HasForeignKey(d => d.WorkTypeId);
        });

        modelBuilder.Entity<WorkType>(entity =>
        {
            entity.Property(e => e.Name).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}