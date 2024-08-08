using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeFirstExample.Entities;

namespace CodeFirstExample.Data
{
    public class CodeFirstExampleContext : DbContext
    {
        public CodeFirstExampleContext (DbContextOptions<CodeFirstExampleContext> options)
            : base(options)
        {
        }

        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //seed data for 10 type
            modelBuilder.Entity<WorkType>().HasData(
                new WorkType { Id = 1, Name = "維護" },
                new WorkType { Id = 2, Name = "開發" },
                new WorkType { Id = 3, Name = "測試" },
                new WorkType { Id = 4, Name = "部署" },
                new WorkType { Id = 5, Name = "分析" },
                new WorkType { Id = 6, Name = "設計" },
                new WorkType { Id = 7, Name = "管理" },
                new WorkType { Id = 8, Name = "支援" },
                new WorkType { Id = 9, Name = "研究" },
                new WorkType { Id = 10, Name = "其他" }
            );

            //seed data for 10 work items
            modelBuilder.Entity<WorkItem>().HasData(
                new WorkItem { Id = 1, Description = "修復系統錯誤", WorkTypeId = 1 },
                new WorkItem { Id = 2, Description = "新增功能", WorkTypeId = 2 },
                new WorkItem { Id = 3, Description = "測試功能", WorkTypeId = 3 },
                new WorkItem { Id = 4, Description = "部署功能", WorkTypeId = 4 },
                new WorkItem { Id = 5, Description = "分析需求", WorkTypeId = 5 },
                new WorkItem { Id = 6, Description = "設計系統", WorkTypeId = 6 },
                new WorkItem { Id = 7, Description = "管理專案", WorkTypeId = 7 },
                new WorkItem { Id = 8, Description = "支援客戶", WorkTypeId = 8 },
                new WorkItem { Id = 9, Description = "研究新技術", WorkTypeId = 9 },
                new WorkItem { Id = 10, Description = "其他工作", WorkTypeId = 10 }
                );


            modelBuilder.Entity<WorkItem>()
                .HasOne(wi => wi.WorkType)
                .WithMany(wt => wt.WorkItems)
                .HasForeignKey(wi => wi.WorkTypeId);

            modelBuilder.Entity<Job>().OwnsOne(j => j.Item, wi =>
            {
                wi.Property(p => p.WorkItemId);
                wi.Property(p => p.Description);
                wi.Property(p => p.WorkTypeId);
                wi.Property(p => p.WorkTypeName);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Your_Connection_String_Here");

        }

    }
}
