﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reverse_Engineering_EF_CORE;

public partial class Another2Context : DbContext
{
    public Another2Context()
    {
    }

    public Another2Context(DbContextOptions<Another2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Traveller> Travellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=Another2; User id=SA; Password=S@ndrine1!; Encrypt=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Traveller>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
