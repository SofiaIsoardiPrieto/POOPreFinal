using System;

namespace POOPreFinal.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creación de la entidad bancaria
            Banco banco = new Banco("Banco Del Plata");
            //Creación de las cuentas
            CajaDeAhorro cuenta1 = new CajaDeAhorro(1, "Juan");
            CuentaCorriente cuenta2 = new CuentaCorriente(2, "Maria", 100);
            CajaDeAhorroDolares cuenta3 = new CajaDeAhorroDolares(3, "Pedro");
            CajaDeAhorro cuenta4 = new CajaDeAhorro(1, "Juan"); //Cuenta repetida
            CuentaCorriente cuenta5 = new CuentaCorriente(5, "Brandy", 100);
            CajaDeAhorroDolares cuenta6 = new CajaDeAhorroDolares(6, "Petrus");
            //Agregar las cuentas a la entidad bancaria
            Console.WriteLine(banco + cuenta1);
            Console.WriteLine(banco + cuenta2);
            Console.WriteLine(banco + cuenta3);
            Console.WriteLine(banco + cuenta4);// cuenta repetida no debería de   haber ingresado
            Console.WriteLine(banco + cuenta5);
            Console.WriteLine(banco + cuenta6);
            Console.WriteLine((string)banco);
            //Depósitos
            banco.Depositar(1, 10000);
            banco.Depositar(2, 10000);
            banco.Depositar(3, 1000);//depósito dólares debería de tomar únicamente 200
            banco.Depositar(4, 10000); //cuenta inexistente
            banco.Depositar(5, 10000);
            banco.Depositar(6, 100);
            //Retiros
            banco.Retirar(1, 1000);// todo joya
            banco.Retirar(2, 200000);//Fondos insuficientes
            banco.Retirar(2, 200000);//Fondos insuficientes
            banco.Retirar(2, 200000);//Fondos insuficientes - Cta suspendida
            banco.Retirar(3, 1000);//fondos en dólares insuficientes
            banco.Retirar(4, 10000); //cuenta inexistente
            Console.WriteLine((string)banco);//Controlar que los saldos sean los esperados
            //Persistir los datos
            banco.GuardarCuentas();
        }
    }
}
