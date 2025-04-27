using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.DBModels;

public partial class MvctutorialContext : DbContext
{
    public MvctutorialContext()
    {
    }

    public MvctutorialContext(DbContextOptions<MvctutorialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accounting> Accountings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MVCTutorial;User Id=SA;Password=mvcTutorial123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounting>(entity =>
        {
            entity.HasKey(e => e.Sn);

            entity.ToTable("Accounting");

            entity.Property(e => e.Sn).HasColumnName("SN");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
