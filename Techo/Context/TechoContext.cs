using Microsoft.EntityFrameworkCore;

namespace Techo.Models
{
    public partial class TechoContext : DbContext
    {
        public TechoContext()
        {
        }

        public TechoContext(DbContextOptions<TechoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contribuyente> Contribuyentes { get; set; }
        public virtual DbSet<EntidadParticipativa> EntidadParticipativas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
////            if (!optionsBuilder.IsConfigured)
////            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
////                optionsBuilder.UseSqlServer("Server=DESKTOP-QG4O76G\\pablo;Database=Sanitarios;Trusted_Connection=True;");
////            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Contribuyente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Apellido).HasMaxLength(64);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128);

                //entity.Property(e => e.NumeroDocumento)
                //    .IsRequired()
                //    .HasMaxLength(12);

                entity.Property(e => e.Telefono).HasMaxLength(20);

                entity.HasIndex(x => x.EntidadParticipativaId);

                //entity.HasOne(d => d.EntidadParticipativa)
                //    .WithMany(p => p.Contribuyentes)
                //    .HasForeignKey(d => d.EntidadParticipativa)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Clientes_EntidadParticipativa");
            });

            //modelBuilder.Entity<MediosPago>(entity =>
            //{
            //    entity.ToTable("MediosPago");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasMaxLength(32);
            //});

            //modelBuilder.Entity<Producto>(entity =>
            //{
            //    //entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.Id).UseIdentityColumn(1,1);

            //    entity.Property(e => e.CodigoBarra)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Descripcion)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasMaxLength(64);

            //    entity.Property(e => e.PrecioCosto).HasColumnType("decimal(18, 2)");

            //    //entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");

            //    entity.HasOne(d => d.Proveedor)
            //        .WithMany(p => p.Productos)
            //        .HasForeignKey(d => d.ProveedorId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Productos_Proveedores");

            //    entity.Property(e => e.Medida).IsRequired().HasMaxLength(20);
            //    entity.Property(e => e.Material).IsRequired().HasMaxLength(20);
            //    entity.Property(e => e.Marca).IsRequired().HasMaxLength(20);
            //});

            //modelBuilder.Entity<Proveedores>(entity =>
            //{
            //    //entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.Id).UseIdentityColumn();

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasMaxLength(64);

            //    entity.Property(e => e.Ganancia).HasColumnType("decimal(18, 2)");

            //    //entity.HasOne(d => d.Bonificaciones).WithMany(p => p.Bonificaciones)

            //    //entity.HasKey(p => new {p.})
            //});

            modelBuilder.Entity<EntidadParticipativa>(entity =>
            {
                entity.ToTable("EntidadParticipativa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            //modelBuilder.Entity<Venta>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Fecha).HasColumnType("datetime");

            //    entity.HasOne(d => d.MedioPago)
            //        .WithMany(p => p.Venta)
            //        .HasForeignKey(d => d.MedioPagoId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Ventas_Clientes");
            //});

            //modelBuilder.Entity<VentasAfip>(entity =>
            //{
            //    entity.HasKey(e => e.VentaId);

            //    entity.ToTable("VentasAfip");

            //    entity.Property(e => e.VentaId).ValueGeneratedNever();

            //    entity.Property(e => e.Comprobante)
            //        .IsRequired()
            //        .HasMaxLength(64);

            //    entity.HasOne(d => d.Venta)
            //        .WithOne(p => p.VentasAfip)
            //        .HasForeignKey<VentasAfip>(d => d.VentaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_VentasAfip_Ventas");
            //});

            //modelBuilder.Entity<VentasDetalle>(entity =>
            //{
            //    entity.HasKey(e => new { e.VentaId, e.ProductoId });

            //    entity.ToTable("VentasDetalle");

            //    entity.Property(e => e.PrecioUnitarioVenta).HasColumnType("decimal(18, 2)");

            //    entity.HasOne(d => d.Producto)
            //        .WithMany(p => p.VentasDetalles)
            //        .HasForeignKey(d => d.ProductoId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_VentasDetalle_Productos");

            //    entity.HasOne(d => d.Venta)
            //        .WithMany(p => p.VentasDetalles)
            //        .HasForeignKey(d => d.VentaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_VentasDetalle_Ventas");
            //});

            //modelBuilder.Entity<VentasPosnet>(entity =>
            //{
            //    entity.HasKey(e => e.VentaId);

            //    entity.ToTable("VentasPosnet");

            //    entity.Property(e => e.VentaId).ValueGeneratedNever();

            //    entity.Property(e => e.Cupon)
            //        .IsRequired()
            //        .HasMaxLength(32);

            //    entity.Property(e => e.Fecha).HasColumnType("datetime");

            //    entity.HasOne(d => d.Venta)
            //        .WithOne(p => p.VentasPosnet)
            //        .HasForeignKey<VentasPosnet>(d => d.VentaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_VentasPosnet_Ventas");
            //});

            //modelBuilder.Entity<Bonificaciones>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnType("smallint").UseIdentityColumn(1, 1);
            //});

            //modelBuilder.Entity<ProveedoresBonificaciones>(entity => {
            //    entity.HasKey(bp => new { bp.IdBonificacion, bp.IdProveedor });

            //    entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            //    entity.HasOne(bp => bp.Bonificacion).WithMany(p => p.ProveedoresBonificaciones).HasForeignKey(fk => fk.IdBonificacion);

            //    entity.HasOne(bp => bp.Proveedor).WithMany(b => b.ProveedoresBonificaciones).HasForeignKey(fk => fk.IdProveedor);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public bool DatabaseOnline()
        {

            return true;
        }
    }
}