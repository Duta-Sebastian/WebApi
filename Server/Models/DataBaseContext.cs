using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.Models
{

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absente> Absentes { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<ClaseProfesor> ClaseProfesors { get; set; } = null!;
        public virtual DbSet<ClsElv> ClsElvs { get; set; } = null!;
        public virtual DbSet<DirigentieProfesori> DirigentieProfesoris { get; set; } = null!;
        public virtual DbSet<Discipline> Disciplines { get; set; } = null!;
        public virtual DbSet<Elevi> Elevis { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<ProfDisc> ProfDiscs { get; set; } = null!;
        public virtual DbSet<Profesori> Profesoris { get; set; } = null!;
        public virtual DbSet<ProfesoriClasa> ProfesoriClasas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:CatalogOnlineDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absente>(entity =>
            {
                entity.HasKey(e => new { e.Data, e.IdElev, e.IdDisciplina })
                    .HasName("PK_Absente__5B54E803CBBE7AA0");

                entity.ToTable("Absente");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.IdElev).HasColumnName("id_elev");

                entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");

                entity.Property(e => e.Absente1).HasColumnName("absente");

                entity.Property(e => e.Motivat).HasColumnName("motivat");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.Absentes)
                    .HasForeignKey(d => d.IdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Absente_Discipline");

                entity.HasOne(d => d.IdElevNavigation)
                    .WithMany(p => p.Absentes)
                    .HasForeignKey(d => d.IdElev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Absente_Elevi");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.ToTable("Clase");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clasa)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClaseProfesor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Clase_Profesor");

                entity.Property(e => e.IdClasa).HasColumnName("id_clasa");

                entity.Property(e => e.IdDisc).HasColumnName("id_disc");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");

                entity.HasOne(d => d.IdClasaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Profesor_Clase");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Profesor_Profesori");
            });

            modelBuilder.Entity<ClsElv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClsElv");

                entity.Property(e => e.IdClasa).HasColumnName("id_clasa");

                entity.Property(e => e.IdElev).HasColumnName("id_elev");

                entity.HasOne(d => d.IdClasaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClsElv");

                entity.HasOne(d => d.IdElevNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdElev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClsElv_elev");
            });

            modelBuilder.Entity<DirigentieProfesori>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Dirigentie_Profesori");

                entity.Property(e => e.IdClasa).HasColumnName("id_clasa");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => e.IdDisciplina)
                    .HasName("PK__Discipli__3E5AFB63F146D3A7");

                entity.ToTable("Discipline");

                entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");

                entity.Property(e => e.Denumire)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("denumire");
            });

            modelBuilder.Entity<Elevi>(entity =>
            {
                entity.ToTable("Elevi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clasa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeCurent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nume_Curent");

                entity.Property(e => e.NumeDefault)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nume_Default");

                entity.Property(e => e.ParolaCurenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Parola_Curenta");

                entity.Property(e => e.ParolaDefault)
                    .IsUnicode(false)
                    .HasColumnName("Parola_Default");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.Data, e.IdElev, e.IdDisciplina })
                    .HasName("PK__Note_5B54E803CBBE7AA0");

                entity.ToTable("Note");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.IdElev).HasColumnName("id_elev");

                entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");

                entity.Property(e => e.Note1).HasColumnName("note");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_Discipline");

                entity.HasOne(d => d.IdElevNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdElev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_Elevi");
            });

            modelBuilder.Entity<ProfDisc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProfDisc");

                entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfDisc_Discipline");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfDisc_Profesori");
            });

            modelBuilder.Entity<Profesori>(entity =>
            {
                entity.ToTable("Profesori");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clasa).IsUnicode(false);

                entity.Property(e => e.Dirigentie).IsUnicode(false);

                entity.Property(e => e.Disciplina).IsUnicode(false);

                entity.Property(e => e.NumeCurent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nume_Curent");

                entity.Property(e => e.NumeDefault)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nume_Default");

                entity.Property(e => e.ParolaCurenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Parola_Curenta");

                entity.Property(e => e.ParolaDefault)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Parola_Default");
            });

            modelBuilder.Entity<ProfesoriClasa>(entity =>
            {
                entity.HasKey(e => e.IdClasa);

                entity.ToTable("Profesori_Clasa");

                entity.Property(e => e.IdClasa)
                    .ValueGeneratedNever()
                    .HasColumnName("id_clasa");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");

                entity.HasOne(d => d.IdClasaNavigation)
                    .WithOne(p => p.ProfesoriClasa)
                    .HasForeignKey<ProfesoriClasa>(d => d.IdClasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesori_Clasa_Clase");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany(p => p.ProfesoriClasas)
                    .HasForeignKey(d => d.IdProf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesori_Clasa_Profesori");



            });
            modelBuilder.Entity<ClsNumD>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Nume_Default);
                entity.Property(e => e.Clasa);
            });

            modelBuilder.Entity<Clase1>(entity =>
                {
                    entity.HasNoKey();
                    entity.Property(e => e.Clasa);
                });
            modelBuilder.Entity<AfisareNote>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.note);
                entity.Property(e => e.Data);
            });
            modelBuilder.Entity<AdaugaNota>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Result);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public virtual DbSet<Clase1> Class_1 { get; set; } = null!;
        public virtual DbSet<AfisareNote> AfsNote { get; set; } = null!;
        public virtual DbSet<AdaugaNota> AdgNota { get;set ; } = null!;
        public virtual DbSet<ClsNumD> ClsNumDs { get; set; } = null!;
    }
}
