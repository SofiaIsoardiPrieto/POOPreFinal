using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOPreFinal.Consola
{
    public class CajaDeAhorroDolares : Cuenta
    {
        public CajaDeAhorroDolares(int numeroCta, string titularCta) : base(numeroCta, titularCta)
        {
        }

        public override void Depositar(decimal monto)
        {
            if (monto>=200)
            {
                Saldo += 200;
            }
            else
            {
                Saldo += monto;
            }

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
