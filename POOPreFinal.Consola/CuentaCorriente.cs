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
        public int CantidadSobregiros { set { cantidadSobregiros=value; } }

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
            if (monto <= (Saldo + Sobregiro))
            {
                Saldo -= monto;
                return true;
            }
            else
            {
                cantidadSobregiros++;
                if (cantidadSobregiros >= 3)
                {
                    Suspendida = true; 
                }
                return false;
            }
        }
    }
}
