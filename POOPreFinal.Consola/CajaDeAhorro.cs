using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOPreFinal.Consola
{
    internal class CajaDeAhorro:Cuenta
    {
        public CajaDeAhorro(int numeroCta, string titularCta) : base(numeroCta, titularCta) { }

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
