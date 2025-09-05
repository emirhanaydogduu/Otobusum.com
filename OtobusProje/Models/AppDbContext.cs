using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OtobusProje.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bakim> Bakims { get; set; }

    public virtual DbSet<Bilet> Bilets { get; set; }

    public virtual DbSet<Durak> Duraks { get; set; }

    public virtual DbSet<Firma> Firmas { get; set; }

    public virtual DbSet<FirmaYorum> FirmaYorums { get; set; }

    public virtual DbSet<Odeme> Odemes { get; set; }

    public virtual DbSet<Otobu> Otobus { get; set; }

    public virtual DbSet<OtobusYorum> OtobusYorums { get; set; }

    public virtual DbSet<Personel> Personels { get; set; }

    public virtual DbSet<Rezervasyon> Rezervasyons { get; set; }

    public virtual DbSet<RotaDurak> RotaDuraks { get; set; }

    public virtual DbSet<Rotum> Rota { get; set; }

    public virtual DbSet<Sefer> Sefers { get; set; }

    public virtual DbSet<SeferYorum> SeferYorums { get; set; }

    public virtual DbSet<Sofor> Sofors { get; set; }

    public virtual DbSet<SoforYorum> SoforYorums { get; set; }

    public virtual DbSet<Yolcu> Yolcus { get; set; }

    public virtual DbSet<Yorum> Yorums { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bakim>(entity =>
        {
            entity.HasKey(e => e.BakimId).HasName("PK__Bakim__0F7162E5ED4A309F");

            entity.Property(e => e.BakimId).ValueGeneratedNever();

            entity.HasOne(d => d.Otobus).WithMany(p => p.Bakims)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bakim__otobus_id__619B8048");

            entity.HasOne(d => d.Personel).WithMany(p => p.Bakims)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bakim__personel___628FA481");
        });

        modelBuilder.Entity<Bilet>(entity =>
        {
            entity.HasKey(e => e.BiletId).HasName("PK__Bilet__033C9972EC0362BB");

            entity.Property(e => e.BiletId).ValueGeneratedNever();

            entity.HasOne(d => d.Sefer).WithMany(p => p.Bilets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bilet__sefer_id__693CA210");

            entity.HasOne(d => d.Yolcu).WithMany(p => p.Bilets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bilet__yolcu_id__68487DD7");
        });

        modelBuilder.Entity<Durak>(entity =>
        {
            entity.HasKey(e => e.DurakId).HasName("PK__Durak__DFDE714158CECB0B");

            entity.Property(e => e.DurakId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Firma>(entity =>
        {
            entity.HasKey(e => e.FirmaId).HasName("PK__Firma__5F84B8AD91DA020A");

            entity.Property(e => e.FirmaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<FirmaYorum>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("PK__FirmaYor__B0FA5C85B2B40CE0");

            entity.Property(e => e.YorumId).ValueGeneratedNever();

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaYorums).HasConstraintName("FK__FirmaYoru__firma__45BE5BA9");

            entity.HasOne(d => d.Yorum).WithOne(p => p.FirmaYorum).HasConstraintName("FK__FirmaYoru__yorum__44CA3770");
        });

        modelBuilder.Entity<Odeme>(entity =>
        {
            entity.HasKey(e => e.OdemeId).HasName("PK__Odeme__30746959D0F33946");

            entity.Property(e => e.OdemeId).ValueGeneratedNever();

            entity.HasOne(d => d.Bilet).WithMany(p => p.Odemes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Odeme__bilet_id__6C190EBB");
        });

        modelBuilder.Entity<Otobu>(entity =>
        {
            entity.HasKey(e => e.OtobusId).HasName("PK__Otobus__4CF290F25157024F");

            entity.Property(e => e.OtobusId).ValueGeneratedNever();

            entity.HasOne(d => d.Firma).WithMany(p => p.Otobus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Otobus__firma_id__4CA06362");
        });

        modelBuilder.Entity<OtobusYorum>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("PK__OtobusYo__B0FA5C85235E7CF3");

            entity.Property(e => e.YorumId).ValueGeneratedNever();

            entity.HasOne(d => d.Otobus).WithMany(p => p.OtobusYorums).HasConstraintName("FK__OtobusYor__otobu__498EEC8D");

            entity.HasOne(d => d.Yorum).WithOne(p => p.OtobusYorum).HasConstraintName("FK__OtobusYor__yorum__489AC854");
        });

        modelBuilder.Entity<Personel>(entity =>
        {
            entity.HasKey(e => e.PersonelId).HasName("PK__Personel__48A5539F69FE9315");

            entity.Property(e => e.PersonelId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rezervasyon>(entity =>
        {
            entity.HasKey(e => e.RezervasyonId).HasName("PK__Rezervas__770E0154E399A685");

            entity.Property(e => e.RezervasyonId).ValueGeneratedNever();

            entity.HasOne(d => d.Sefer).WithMany(p => p.Rezervasyons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rezervasy__sefer__6FE99F9F");

            entity.HasOne(d => d.Yolcu).WithMany(p => p.Rezervasyons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rezervasy__yolcu__6EF57B66");
        });

        modelBuilder.Entity<RotaDurak>(entity =>
        {
            entity.HasKey(e => new { e.RotaId, e.DurakId }).HasName("PK__Rota_Dur__07CAA3D8AF38FE19");

            entity.HasOne(d => d.Durak).WithMany(p => p.RotaDuraks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rota_Dura__durak__59063A47");

            entity.HasOne(d => d.Rota).WithMany(p => p.RotaDuraks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rota_Dura__rota___5812160E");
        });

        modelBuilder.Entity<Rotum>(entity =>
        {
            entity.HasKey(e => e.RotaId).HasName("PK__Rota__0A3744CCBC8FDAFD");

            entity.Property(e => e.RotaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Sefer>(entity =>
        {
            entity.HasKey(e => e.SeferId).HasName("PK__Sefer__AE50B52EFA215C81");

            entity.Property(e => e.SeferId).ValueGeneratedNever();

            entity.HasOne(d => d.Otobus).WithMany(p => p.Sefers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sefer__otobus_id__5BE2A6F2");

            entity.HasOne(d => d.Personel).WithMany(p => p.Sefers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sefer__personel___5DCAEF64");

            entity.HasOne(d => d.Rota).WithMany(p => p.Sefers).HasConstraintName("FK__Sefer__rota_id__5EBF139D");

            entity.HasOne(d => d.Sofor).WithMany(p => p.Sefers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sefer__sofor_id__5CD6CB2B");
        });

        modelBuilder.Entity<SeferYorum>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("PK__SeferYor__B0FA5C8586A56446");

            entity.Property(e => e.YorumId).ValueGeneratedNever();

            entity.HasOne(d => d.Sefer).WithMany(p => p.SeferYorums).HasConstraintName("FK__SeferYoru__sefer__41EDCAC5");

            entity.HasOne(d => d.Yorum).WithOne(p => p.SeferYorum).HasConstraintName("FK__SeferYoru__yorum__40F9A68C");
        });

        modelBuilder.Entity<Sofor>(entity =>
        {
            entity.HasKey(e => e.SoforId).HasName("PK__Sofor__8B25EFF8222A5BB1");

            entity.Property(e => e.SoforId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SoforYorum>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("PK__SoforYor__B0FA5C85D79B0A5B");

            entity.Property(e => e.YorumId).ValueGeneratedNever();

            entity.HasOne(d => d.Sofor).WithMany(p => p.SoforYorums).HasConstraintName("FK__SoforYoru__sofor__4D5F7D71");

            entity.HasOne(d => d.Yorum).WithOne(p => p.SoforYorum).HasConstraintName("FK__SoforYoru__yorum__4C6B5938");
        });

        modelBuilder.Entity<Yolcu>(entity =>
        {
            entity.HasKey(e => e.YolcuId).HasName("PK__Yolcu__A54471A5F81F16AA");

            entity.Property(e => e.YolcuId).ValueGeneratedNever();
            entity.Property(e => e.TcNo).IsFixedLength();
        });

        modelBuilder.Entity<Yorum>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("PK__Yorum__B0FA5C855DA639AD");

            entity.Property(e => e.Tarih).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Yolcu).WithMany(p => p.Yorums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Yorum__yolcu_id__3E1D39E1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
