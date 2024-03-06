using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POOPreFinal.Consola
{
    public class Banco
    {

        private List<Cuenta> cuentas = new List<Cuenta>();
        private List<Movimiento> movimientos = new List<Movimiento>();
        private string nombre;

        public List<Movimiento> Movimientos { get; }

        public void AgregarCuenta(Cuenta cuenta)
        {
            cuentas.Add(cuenta);
        }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            movimientos.Add(movimiento);
        }

        private Banco()
        {

        }

        public Banco(string nombreEntidad)
        {
            nombre = nombreEntidad;
        }

        public Cuenta BuscarCuenta(int numeroCuenta)
        {
            foreach (var item in cuentas)
            {
                if (item.Numero==numeroCuenta)
                {
                    return item;
                }
            }
            return null;
        }

        public void Cargar()
        {
            PersistenciaSecuencialCuentas persistencia = new PersistenciaSecuencialCuentas();
            persistencia.Cargar();
        }

        public void Depositar(int numeroCuenta, decimal monto)
        {
            var cuenta = BuscarCuenta(numeroCuenta);
           
            if (!(cuenta is null))
            {
                if (cuenta.GetType()==typeof( CajaDeAhorroDolares))
                {
                    ((CajaDeAhorroDolares)cuenta).Depositar(monto);
                }
                else
                {
                    cuenta.Saldo += monto; 
                    AgregarMovimiento(new Movimiento(numeroCuenta, "deposito", monto));
                }
 
            }
            
        }

        public override bool Equals(object obj)
        {

            if (obj == null && !(obj is Banco))
            {
                return false;
            }
            Banco banco = (Banco)obj;
            return banco.nombre == ((Banco)obj).nombre;
        }

        public static string operator +(Banco banco, Cuenta cuenta)
        {
            if (banco!=cuenta)
            {
                banco.AgregarCuenta(cuenta);
                return $"Cuenta n: {cuenta} agregada exitosamente";
            }
            return $"La cuenta n: {cuenta} ya existe";
        }
        public static bool operator ==(Banco banco, Cuenta cuenta)
        {
            foreach (var item in banco.cuentas)
            {
                if (item==cuenta)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Banco banco, Cuenta cuenta)
        {
            return !(banco == cuenta);
        }
        public static explicit operator string(Banco v)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" Banco:{v.nombre}");
            foreach (var item in v.cuentas)
            {
                sb.AppendLine($"Cuenta:{item.Numero} - {item.Saldo} - {item.Suspendida}");
            }
            return sb.ToString();
        }

        public void Retirar(int numeroDeCuenta, decimal monto)
        {
            var cuenta = BuscarCuenta(numeroDeCuenta);
            if (!(cuenta is null))
            {
                if (cuenta.GetType()==typeof(CuentaCorriente))
                {
                   ((CuentaCorriente) cuenta).Retirar(monto);
                    
                }
                else if (cuenta.GetType() == typeof(CajaDeAhorro))
                {
                    ((CajaDeAhorro)cuenta).Retirar(monto);

                }
                else
                {
                    ((CajaDeAhorroDolares)cuenta).Retirar(monto);
                }
                
            }
            else
            {
               Console.WriteLine("La cuenta no existe.");
            }
        }

        public void GuardarCuentas()
        {
            PersistenciaSecuencialCuentas persistencia = new PersistenciaSecuencialCuentas();
            persistencia.Guardar(cuentas);
        }
    }
}
