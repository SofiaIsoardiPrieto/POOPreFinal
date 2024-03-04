using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOPreFinal.Consola
{
    public  interface IPersistencia<T> where T : Cuenta
    {

         List<T> Cargar();

         void Guardar(List<T> datos);
        
    }
}
