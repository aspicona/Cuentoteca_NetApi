using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cuentoteca_netApi.Models;

public partial class CuentotecaContext : DbContext
{
    public CuentotecaContext()
    {
    }

    public CuentotecaContext(DbContextOptions<CuentotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autorizacione> Autorizaciones { get; set; }

    public virtual DbSet<Calificacionesyresenia> Calificacionesyresenias { get; set; }

    public virtual DbSet<Coleccione> Colecciones { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<NivelesLector> NivelesLectors { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<TiposNotific> TiposNotifics { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WENDER;Initial Catalog=cuentoteca;Integrated Security=True; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autorizacione>(entity =>
        {
            entity.HasKey(e => e.IdAutorizacion).HasName("PK__AUTORIZA__EE7919CF4A713CD4");

            entity.ToTable("AUTORIZACIONES");

            entity.Property(e => e.IdAutorizacion).HasColumnName("id_autorizacion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdSala).HasColumnName("id_sala");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Autorizaciones)
                .HasForeignKey(d => d.IdSala)
                .HasConstraintName("FK__AUTORIZAC__id_sa__4222D4EF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Autorizaciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__AUTORIZAC__id_us__412EB0B6");
        });

        modelBuilder.Entity<Calificacionesyresenia>(entity =>
        {
            entity.HasKey(e => e.IdCyr).HasName("PK__CALIFICA__D69702AA01BFF8EB");

            entity.ToTable("CALIFICACIONESYRESENIAS");

            entity.Property(e => e.IdCyr).HasColumnName("id_cyr");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.FechaCyr)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cyr");
            entity.Property(e => e.IdLector).HasColumnName("id_lector");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");

            entity.HasOne(d => d.IdLectorNavigation).WithMany(p => p.Calificacionesyresenia)
                .HasForeignKey(d => d.IdLector)
                .HasConstraintName("FK__CALIFICAC__id_le__398D8EEE");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Calificacionesyresenia)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__CALIFICAC__id_li__38996AB5");
        });

        modelBuilder.Entity<Coleccione>(entity =>
        {
            entity.HasKey(e => e.IdColeccion).HasName("PK__COLECCIO__57DDA7DE6B984827");

            entity.ToTable("COLECCIONES");

            entity.Property(e => e.IdColeccion).HasColumnName("id_coleccion");
            entity.Property(e => e.Editorial)
                .HasMaxLength(255)
                .HasColumnName("editorial");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__LIBROS__EC09C24ED65F9FA8");

            entity.ToTable("LIBROS");

            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.AnioPublicacion).HasColumnName("anio_publicacion");
            entity.Property(e => e.Autor)
                .HasMaxLength(255)
                .HasColumnName("autor");
            entity.Property(e => e.CodInterno)
                .HasMaxLength(50)
                .HasColumnName("cod_interno");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("datetime")
                .HasColumnName("fecha_baja");
            entity.Property(e => e.IdColeccion).HasColumnName("id_coleccion");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .HasColumnName("ISBN");
            entity.Property(e => e.MotivoBaja).HasColumnName("motivo_baja");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdColeccionNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdColeccion)
                .HasConstraintName("FK__LIBROS__id_colec__31EC6D26");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje).HasName("PK__MENSAJES__5B37C7F686356185");

            entity.ToTable("MENSAJES");

            entity.Property(e => e.IdMensaje).HasColumnName("id_mensaje");
            entity.Property(e => e.Asunto)
                .HasMaxLength(255)
                .HasColumnName("asunto");
            entity.Property(e => e.Texto).HasColumnName("texto");
        });

        modelBuilder.Entity<NivelesLector>(entity =>
        {
            entity.HasKey(e => e.IdNivel).HasName("PK__NIVELES___9CAF1C53CA8F64CA");

            entity.ToTable("NIVELES_LECTOR");

            entity.Property(e => e.IdNivel)
                .ValueGeneratedNever()
                .HasColumnName("id_nivel");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__NOTIFICA__8270F9A5DC042C1F");

            entity.ToTable("NOTIFICACIONES");

            entity.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEnvio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.IdEmisor).HasColumnName("id_emisor");
            entity.Property(e => e.IdMensaje).HasColumnName("id_mensaje");
            entity.Property(e => e.IdReceptor).HasColumnName("id_receptor");
            entity.Property(e => e.IdTipoNotif).HasColumnName("id_tipo_notif");

            entity.HasOne(d => d.IdEmisorNavigation).WithMany(p => p.NotificacioneIdEmisorNavigations)
                .HasForeignKey(d => d.IdEmisor)
                .HasConstraintName("FK__NOTIFICAC__id_em__3C69FB99");

            entity.HasOne(d => d.IdReceptorNavigation).WithMany(p => p.NotificacioneIdReceptorNavigations)
                .HasForeignKey(d => d.IdReceptor)
                .HasConstraintName("FK__NOTIFICAC__id_re__3D5E1FD2");

            entity.HasOne(d => d.IdTipoNotifNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdTipoNotif)
                .HasConstraintName("FK__NOTIFICAC__id_ti__3E52440B");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__PRESTAMO__5E87BE279AF0E814");

            entity.ToTable("PRESTAMOS");

            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_devolucion");
            entity.Property(e => e.FechaPrestamo)
                .HasColumnType("datetime")
                .HasColumnName("fecha_prestamo");
            entity.Property(e => e.IdLector).HasColumnName("id_lector");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.PlazoDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("plazo_devolucion");

            entity.HasOne(d => d.IdLectorNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdLector)
                .HasConstraintName("FK__PRESTAMOS__id_le__35BCFE0A");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__PRESTAMOS__id_li__34C8D9D1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROLES__6ABCB5E0AB4FEA1E");

            entity.ToTable("ROLES");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__SALAS__D18B015BD11B199C");

            entity.ToTable("SALAS");

            entity.Property(e => e.IdSala)
                .ValueGeneratedNever()
                .HasColumnName("id_sala");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiposNotific>(entity =>
        {
            entity.HasKey(e => e.IdTipoNotif).HasName("PK__TIPOS_NO__C16844903025E378");

            entity.ToTable("TIPOS_NOTIFIC");

            entity.Property(e => e.IdTipoNotif)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_notif");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__4E3E04AD6556C4C8");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdNivelLector).HasColumnName("id_nivel_lector");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdNivelLectorNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdNivelLector)
                .HasConstraintName("FK__USUARIOS__id_niv__29572725");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__USUARIOS__id_rol__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
