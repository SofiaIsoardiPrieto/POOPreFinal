using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace POOPreFinal.Consola
{
    public class PersistenciaMovimientosXML : IPersistencia<Cuenta>
    {
       // private string path = Environment.CurrentDirectory;
        //private string archivo = "Ventas.Xml";
        private string nombreArchivo= "C:\\_PROGRAMACION_\\2º Año\\POO\\CIMINO\\PreFinal\\POOPreFinal\\POOPreFinal.Consola\\Cuentas.xml";

        public PersistenciaMovimientosXML()
        {
            //nombreArchivo = Path.Combine(path, archivo);
        }
 
        public List<Cuenta> Cargar()
        {
            using (var lector = new StreamReader(nombreArchivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Cuenta>));
                return serializer.Deserialize(lector) as List<Cuenta>;
            }
        }

        public void Guardar(List<Cuenta> datos)
        {
            using (var escritor = new StreamWriter(nombreArchivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Cuenta>));
                serializer.Serialize(escritor, datos);
            }
        }
    }
}

