using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOPreFinal.Consola
{
    public class CuentaCorriente : Cuenta
    {
        public decimal Sobregiro { get; }
        private int cantidadSobregiros; 
        public int CantidadSobregiros { get { return cantidadSobregiros; } }

        public CuentaCorriente(int numeroCta, string titularCta, decimal sobregiro) : base(numeroCta, titularCta)
        {
            Sobregiro = sobregiro;
           
        }

        public override void Depositar(decimal monto)
        {
            Saldo += monto;
        }

        public override bool Retirar(decimal monto)
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
