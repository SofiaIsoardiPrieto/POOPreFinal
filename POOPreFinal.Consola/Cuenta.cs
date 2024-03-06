using System.Dynamic;

namespace POOPreFinal.Consola
{
    public abstract class Cuenta
    {
        private int numero;

        public int Numero
        {
            get { return numero; }
            
        }
        private string titular;

        public string Titular
        {
            get { return titular; }
        }
        private bool suspendida;

        public bool Suspendida
        {
            get { return suspendida; }
            set { suspendida = value; }
        }
      
        public decimal Saldo { get; set; }

        public Cuenta(int numeroCta, string titularCta)
        {
            numero = numeroCta;
            titular = titularCta;
            suspendida = false;
            Saldo = 0;
        }

        public abstract void Depositar(decimal monto);

        public override bool Equals(object obj)
        {
            if (obj is Cuenta cuenta)
            {
                return int.Equals(numero, cuenta.numero);
            }
            return false;

            //if (obj == null && !(obj is Cuenta))
            //{
            //    return false;
            //}
            //Cuenta cuenta = (Cuenta)obj;
            //return cuenta.numero == ((Cuenta)obj).numero;
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
            return $"La cuenta: {Numero}, del tutilar: {Titular}," +
                $" en estado de suspensión:{Suspendida}, con un saldo de {Saldo}";
        }
    }

    
}
