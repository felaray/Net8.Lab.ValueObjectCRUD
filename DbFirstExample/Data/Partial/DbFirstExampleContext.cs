#nullable disable
using System;
using System.Collections.Generic;
using DbFirstExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstExample.Data;

public partial class DbFirstExampleContext : DbContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        // valueObject
        modelBuilder.Entity<Job>().OwnsOne(p => p.Item, a =>
        {
            a.Property(p => p.WorkItemId).HasColumnName("Item_WorkItemId");
            a.Property(p => p.Description).HasColumnName("Item_Description");
            a.Property(p => p.WorkTypeId).HasColumnName("Item_WorkTypeId");
            a.Property(p => p.WorkTypeName).HasColumnName("Item_WorkTypeName");
        });

    }
}