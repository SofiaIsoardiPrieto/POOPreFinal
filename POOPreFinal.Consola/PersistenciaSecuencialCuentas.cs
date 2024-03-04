using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POOPreFinal.Consola
{
    public class PersistenciaSecuencialCuentas : IPersistencia<Cuenta>
    {
        private string path = Environment.CurrentDirectory;
        private string archivo = "Cuentas.Xml";
        private string nombreArchivo;

        public PersistenciaSecuencialCuentas()
        {
            nombreArchivo = Path.Combine(path, archivo);
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
                serializer.Serialize(escritor, archivo);
            }
        }
    }
}
