using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static BLTienda.CategoriasBL;

namespace BLTienda
{
    public class Contexto: DbContext //Heredando clases para que DbContext (otra clase) tenga acceso a la base de datos
    {
        public Contexto(): base("Camisetas") //Instanciando la clase base de DbContext
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//crear modelo o base de datos
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Remover tablas pluralizadas al modelo
            Database.SetInitializer(new DatosDeInicio()); 
        }


        public DbSet<Producto> Productos { get; set; }//DbSet es una lista de base de datos y Productos es la tabla
        public DbSet<Categoria> Categorias { get; set;}
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
