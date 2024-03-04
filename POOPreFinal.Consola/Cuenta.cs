using System.Dynamic;

namespace POOPreFinal.Consola
{
    public abstract class Cuenta
    {
        private int numero;
        private bool suspendida;
        private string titular;
        public int Numero { get; }
        public string Titular { get; }
        public bool Suspendida { get; set; }
        public decimal Saldo { get; set; }

        public Cuenta(int numeroCta, string titularCta)
        {
            Numero = numeroCta;
            Titular = titularCta;
            suspendida = false;
            Saldo = 0;
        }

        public abstract void Depositar(decimal monto);

        public override bool Equals(object obj)
        {
            if (obj == null && !(obj is Cuenta))
            {
                return false;
            }
            Cuenta cuenta = (Cuenta)obj;
            return cuenta.numero == ((Cuenta)obj).numero;
        }

        public override int GetHashCode()
        {
            return numero.GetHashCode();
        }

        public static bool operator ==(Cuenta cuenta1, Cuenta cuenta2)
        {
            if (cuenta1 is null || cuenta2 is null)
            {
                return false;
            }
            return cuenta1.Equals(cuenta2);
        }

        public static bool operator !=(Cuenta cuenta1, Cuenta cuenta2)
        {
            
            return !(cuenta1==cuenta2);
        }

        public abstract bool Retirar(decimal monto);

        public override string ToString()
        {
            return $"La cuenta: {numero}, del tutilar: {titular}, en estado de:{suspendida}, con un saldo de {Saldo}";
        }
    }

    
}
