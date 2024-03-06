using System;
using System.Collections.Generic;
using System.IO;

namespace POOPreFinal.Consola
{
    public class PersistenciaSecuencialCuentas : IPersistencia<Cuenta>
    {
        private string path = Environment.CurrentDirectory;
        private string archivo = "Cuentas.txt";
        private string nombreArchivo= "C:\\_PROGRAMACION_\\2º Año\\POO\\CIMINO\\PreFinal\\POOPreFinal\\POOPreFinal.Consola\\Cuentas.txt";


        public PersistenciaSecuencialCuentas()
        {
            //nombreArchivo = Path.Combine(path, archivo);
        }
        public List<Cuenta> Cargar()
        {
            List<Cuenta> lista = new List<Cuenta>();
            if (!File.Exists(archivo))
            {
                return lista;
            }

            using (var lector = new StreamReader(nombreArchivo))
            {
                while (!lector.EndOfStream)
                {
                    var linea = lector.ReadLine();
                    Cuenta cuenta = ConstruirCuenta(linea);
                    lista.Add(cuenta);
                }
            }
            return lista;
        }

        private Cuenta ConstruirCuenta(string linea)
        {
            //tipo de cuenta, número de cuenta, titular y saldo
            Cuenta cuenta;
            var campos = linea.Split(',');
            var tipoCuenta = campos[0];
            if (campos.Length == 5)
            {
                var numero = int.Parse(campos[1]);
                var titular = campos[2];
                var saldo = decimal.Parse(campos[3]);
                var sobregiro = decimal.Parse(campos[4]);
                cuenta = new CuentaCorriente(numero, titular, sobregiro);
                cuenta.Saldo = saldo;
            }
            else if (tipoCuenta == "CajaDeAhorro")
            {
                var numero = int.Parse(campos[1]);
                var titular = campos[2];
                var saldo = decimal.Parse(campos[3]);
                cuenta = new CajaDeAhorro(numero, titular);
                cuenta.Saldo = saldo;
            }
            else
            {
                var numero = int.Parse(campos[1]);
                var titular = campos[2];
                var saldo = decimal.Parse(campos[3]);
                var sobregiro = decimal.Parse(campos[4]);
                cuenta = new CuentaCorriente(numero, titular, sobregiro);
                cuenta.Saldo = saldo;
            }


            return cuenta;
        }

        public void Guardar(List<Cuenta> datos)
        {
            try
            {
                using (var escritor = new StreamWriter(nombreArchivo))
                {
                    foreach (var cuenta in datos)
                    {
                        var linea = ConstruirLinea(cuenta);
                        Console.WriteLine( $"escribe la linea: {linea}");
                        escritor.WriteLine(linea);

                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
            }

        }

        private string ConstruirLinea(Cuenta cuenta)
        {
            //tipo de cuenta, número de cuenta, titular y saldo
            //nesesito el sobregiro en CuentaCorriente
            if (cuenta.GetType() == typeof(CuentaCorriente))
            {
                return $"{cuenta.GetType().Name},{cuenta.Numero},{cuenta.Titular},{((CuentaCorriente)cuenta).Sobregiro}";
            }
            return $"{cuenta.GetType().Name},{cuenta.Numero},{cuenta.Titular},{cuenta.Saldo}";


        }
    }
}
