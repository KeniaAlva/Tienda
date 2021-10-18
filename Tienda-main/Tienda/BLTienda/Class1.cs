using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class SeguridadBL
    {
        public bool Autorizar(string usuario, string contrasena)
        {
            if (usuario == "admin1" && contrasena == "123")
            {
                return true;
            }
            else
            {
                if (usuario == "Admin2" && contrasena == "456")
                {
                    return true;
                }
            }
            return false;
        }
    }
 }

        
         


 
