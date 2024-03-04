using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POOPreFinal.Consola
{
    public class Movimiento
    {
        public Movimiento(int numeroDeCuenta, string tipoDeMovimiento, decimal monto)
        {
            this.numeroDeCuenta = numeroDeCuenta;
            TipoDeMovimiento = tipoDeMovimiento;
            Monto = monto;
        }

        public int numeroDeCuenta { get; set; }
        public string TipoDeMovimiento { get; set; }
        public decimal Monto { get; set; }
    }
}
