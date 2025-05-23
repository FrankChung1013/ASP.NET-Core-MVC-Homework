﻿using System;
using System.Collections.Generic;
using Homework_SkillTree.Api;
using Homework_SkillTree.Domain.Entities.DAO;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Api.Context;

public partial class SkillTreeHomeworkDbContext : DbContext
{
    public SkillTreeHomeworkDbContext()
    {
    }

    public SkillTreeHomeworkDbContext(DbContextOptions<SkillTreeHomeworkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountBook> AccountBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SkillTreeHomeworkDB;User Id=SA;Password=mvcTutorial123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountBook>(entity =>
        {
            entity.ToTable("AccountBook");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dateee).HasColumnType("datetime");
            entity.Property(e => e.Remarkkk).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
