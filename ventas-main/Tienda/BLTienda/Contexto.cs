using BL.Tienda;
using BLTienda;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static BLTienda.CategoriasBL;

namespace BLTienda
{
    public class Contexto: DbContext //Heredando clases para que DbContext (otra clase) tenga acceso a la base de datos
    {
        internal object Clientes;

        public Contexto(): base("Ropa") //Instanciando la clase base de DbContext
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//crear modelo o base de datos
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Remover tablas pluralizadas al modelo
            Database.SetInitializer(new DatosDeInicio()); //Agrega los datos de inicio a la base de datos despues de eliminar la tabla
        }


        public DbSet<Producto> Productos { get; set; }//DbSet es una lista de base de datos y Productos es la tabla
        public DbSet<Categoria> Categorias { get; set;}
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public object Usuario { get; internal set; }
    }

}
