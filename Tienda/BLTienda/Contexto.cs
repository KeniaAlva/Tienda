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
        public Contexto(): base("Camisetas") //Instanciando la clase base de DbContext
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//crear modelo o base de datos
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Remover tablas pluralizadas al modelo
        }

        public DbSet<Producto> Productos { get; set; }//DbSet es una lista de base de datos
    }
}
