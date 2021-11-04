using BL.Tienda;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLTienda
{
    /*Creacion de una clase contexto*/
    public class Contexto: DbContext   //Heredando clases para que DbContext tenga acceso a la base de datos
    {
        public Contexto(): base("Ropa") //Instanciando la clase base de DbContext
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//crear modelo o base de datos
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Remover tablas pluralizadas al modelo
            Database.SetInitializer(new DatosdeInicio());   //Agrega datos de inicio a la base de datos despues de eliminara
        }

        public DbSet<Producto> Productos { get; set; }//DbSet es una lista de base de datos
        public DbSet<Categoria> Categorias { get; set; } //Dbset es una lista de categorias 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}

        
   