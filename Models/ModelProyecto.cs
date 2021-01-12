namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelProyecto : DbContext
    {
        public ModelProyecto()
            : base("name=ModelProyecto3")
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<CategoriasProducto> CategoriasProducto { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Devolucion> Devolucion { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<FacturasVentas> FacturasVentas { get; set; }
        public virtual DbSet<Garantia> Garantia { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Tipoclientes> Tipoclientes { get; set; }
        public virtual DbSet<TipoEmpleados> TipoEmpleados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>()
                .Property(e => e.IdCategoria)
                .IsFixedLength();

            modelBuilder.Entity<Categorias>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Categorias>()
                .Property(e => e.Ubicacion)
                .IsFixedLength();

            modelBuilder.Entity<CategoriasProducto>()
                .Property(e => e.IdCatProductos)
                .IsFixedLength();

            modelBuilder.Entity<CategoriasProducto>()
                .Property(e => e.IdCategoria)
                .IsFixedLength();

            modelBuilder.Entity<CategoriasProducto>()
                .Property(e => e.IdProducto)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.IdTipocliente)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.PrimerNombre)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.SegundoNombre)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.PrimerApellido)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.SegundoApellido)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefono)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.FacturasVentas)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.CedulaCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compras>()
                .Property(e => e.IdCompra)
                .IsFixedLength();

            modelBuilder.Entity<Compras>()
                .Property(e => e.IdProveedor)
                .IsFixedLength();

            modelBuilder.Entity<Compras>()
                .Property(e => e.IdProducto)
                .IsFixedLength();

            modelBuilder.Entity<Compras>()
                .Property(e => e.IdEmpleado)
                .IsFixedLength();

            modelBuilder.Entity<Devolucion>()
                .Property(e => e.IdDevolucion)
                .IsFixedLength();

            modelBuilder.Entity<Devolucion>()
                .Property(e => e.IdGarantia)
                .IsFixedLength();

            modelBuilder.Entity<Devolucion>()
                .Property(e => e.IdProducto)
                .IsFixedLength();

            modelBuilder.Entity<Devolucion>()
                .Property(e => e.ValorDevuelto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.IdEmpleado)
                .IsFixedLength();

            modelBuilder.Entity<Empleados>()
                .Property(e => e.PrimerNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.SegundoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.PrimerApellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.SegundoApellido)
                .IsFixedLength();

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Telefono)
                .IsFixedLength();

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.TipoEmpleado)
                .IsFixedLength();

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.FacturasVentas)
                .WithRequired(e => e.Empleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FacturasVentas>()
                .Property(e => e.IdFacturaVenta)
                .IsFixedLength();

            modelBuilder.Entity<FacturasVentas>()
                .Property(e => e.IdProducto)
                .IsFixedLength();

            modelBuilder.Entity<FacturasVentas>()
                .Property(e => e.IdEmpleado)
                .IsFixedLength();

            modelBuilder.Entity<Garantia>()
                .Property(e => e.IdGarantia)
                .IsFixedLength();

            modelBuilder.Entity<Garantia>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.IdProducto)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .Property(e => e.Estado)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .Property(e => e.Tipo)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .Property(e => e.Tamaño)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .Property(e => e.Empaque)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .Property(e => e.Clasificacion)
                .IsFixedLength();

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.Compras)
                .WithRequired(e => e.Productos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.FacturasVentas)
                .WithRequired(e => e.Productos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.IdProveedor)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Telefono)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.CodigoCiiu)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Direccion)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Compras)
                .WithRequired(e => e.Proveedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipoclientes>()
                .Property(e => e.IdTipoCliente)
                .IsFixedLength();

            modelBuilder.Entity<Tipoclientes>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipoclientes>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Tipoclientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoEmpleados>()
                .Property(e => e.IdTipoEmpleado)
                .IsFixedLength();

            modelBuilder.Entity<TipoEmpleados>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoEmpleados>()
                .HasMany(e => e.Empleados)
                .WithOptional(e => e.TipoEmpleados)
                .HasForeignKey(e => e.TipoEmpleado);
        }
    }
}
