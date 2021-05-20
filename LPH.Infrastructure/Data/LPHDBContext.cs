#define _TEST_
#undef _TEST_
using LPH.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace LPH.Infrastructure.Data
{
    public partial class LPHDBContext : DbContext
    {
        public LPHDBContext()
        {

        }

        public LPHDBContext(DbContextOptions<LPHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orden> Ordenes { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<OrdenComment> Comentarios { get; set; }

        public virtual DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if _TEST_
            if (!optionsBuilder.IsConfigured)
            {
               
            }
#endif


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent APi
            //modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            //modelBuilder.Entity<OrdenComment>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id);
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //    entity.Property(e => e.Comentario)
            //    .HasMaxLength(512)
            //    .IsUnicode(false);

            //    entity.HasOne(d => d.IdOrdenNavigation)
            //       .WithMany(p => p.Comments)
            //       .HasForeignKey(d => d.IdOrden)
            //       .OnDelete(DeleteBehavior.ClientSetNull)
            //       .HasConstraintName("fk_OrdenComment_Orden");

            //    entity.HasOne(e => e.IdUserNavigation)
            //    .WithMany(p => p.Comments)
            //    .HasForeignKey(e => e.IdUser)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("fk_OrdenComment_User");


            //});

            //modelBuilder.Entity<Orden>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Archivo)
            //        .HasMaxLength(128)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FechaRealizacionDeseada).HasColumnType("date");

            //    entity.Property(e => e.Localizacion)
            //        .IsRequired()
            //        .HasMaxLength(128)
            //        .IsUnicode(false);

            //    entity.Property(e => e.MaterialBarda)
            //        .HasMaxLength(32)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Tematica)
            //        .IsRequired()
            //        .HasMaxLength(512)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.IdUserNavigation)
            //        .WithMany(p => p.Ordenes)
            //        .HasForeignKey(d => d.IdUser)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("fk_ordenes_usuarios");
            //});



            //modelBuilder.Entity<Usuario>(entity =>
            //{

            //    entity.HasKey(e => e.Id);

            //    entity.Property(e => e.Id).ValueGeneratedNever();


            //    entity.Property(e => e.Apellido)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FechaNacimiento).HasColumnType("date");

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Telefono)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            #endregion

            modelBuilder.Entity<OrdenComment>(entity =>
            {
                entity.HasOne(e => e.IdOrdenNavigation)
                .WithMany(m => m.Comments)
                .HasForeignKey(e => e.IdOrden)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.IdUserNavigation)
                .WithMany(p => p.Comments)
                .HasForeignKey(e => e.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasOne(e => e.IdOrdenNavigation)
                .WithMany(o => o.Files)
                .HasForeignKey(e => e.IdOrden)
                .OnDelete(DeleteBehavior.Restrict);
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

