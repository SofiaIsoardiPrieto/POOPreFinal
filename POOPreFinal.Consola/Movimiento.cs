using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POOPreFinal.Consola
{
    public enum TipoOperacion
    {
        Deposito,
        Retiro
    }
    public class Movimiento
    {

        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Monto { get; set; }
        public int NumeroCuenta { get; set; }
        public TipoOperacion  Operacion { get; set; }

        public Movimiento( TipoOperacion operacion, int numeroCuenta , decimal monto,string descripcion)
        {
            Descripcion = descripcion;
            FechaHora = DateTime.Now;
            Monto = monto;
            NumeroCuenta = numeroCuenta;
            Operacion = operacion;
        }
        public override string ToString() => 
            $"Cuenta N°:{NumeroCuenta}, tipo de operación: {Operacion}, monto: {Monto}. {Descripcion}";
    }
}
