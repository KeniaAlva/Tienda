using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BL.Tienda
{
    //*Creacion de la lase contexto *//
    public class Contexto : DbContext
    {
        public Contexto() : base("Camisetas") //*Constructor*//
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  //* Instruccion para remover la pluralizacion de las tablas*//

            Database.SetInitializer(new DatosdeInicio()); //Agrega datos de inicio a la base de datos despues de eliminarla
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas  { get; set; }
    }
}
