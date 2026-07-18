using System;
using System.Collections;
using System.Runtime.Serialization;
class Program
{
    static void Main(string[]args)
{
    int nodecuenta, pin;
    string nombrecliente;
    double saldoinicial, limiteretiro, montoretirado,total;
    nodecuenta=100200300;
    pin=2580;
    nombrecliente="Juan Perez";
    saldoinicial=2750.50;
    limiteretiro=1200.00;
    montoretirado=350.00;
    //inicio de sesion
    Console.WriteLine("Ingrese numero de cuenta: ");
    int cuentaingresada=int.Parse(Console.ReadLine()!);
    Console.WriteLine("ingrese su pin: ");
    int piningresado= int.Parse(Console.ReadLine()!);
    total= limiteretiro-montoretirado;
    if (cuentaingresada==nodecuenta && piningresado==pin)
        {
            
            Console.WriteLine($"Bienvenido: {nombrecliente}");
            Console.WriteLine("1-Consultar saldo");
            Console.WriteLine("2-retirar dinero");
            Console.WriteLine("3- depositar dinero");
            Console.WriteLine("4- transferir dinero");
            Console.WriteLine("5- cambiar pin");
            Console.WriteLine("6-simular prestamo");
            Console.WriteLine("resumen de cuenta");
            Console.WriteLine("salir");
            int opcioningresada=int.Parse(Console.ReadLine()!);
            switch (opcioningresada)
            {
                case 1:
                    {
                        Console.WriteLine($"Su saldo actual es: {saldoinicial}");
                        Console.WriteLine($"Saldo disponible para retirar: {limiteretiro}");
                        
                        Console.WriteLine($"Limite restante del dia: { total}");
                    }
                    break;
                    case 2:
                    {
                        Console.WriteLine("Cuanto dinero va a retirar? ");
                        double retiro= double.Parse(Console.ReadLine()!);
                        if (retiro<=0)
                        {
                            Console.WriteLine("cantidad invalida");
                        }
                        else if (retiro > saldoinicial)
                        {
                            Console.WriteLine("No puede retirar mas saldo del disponible");
                        }
                        else if(retiro>total)
                        {
                            Console.WriteLine("No puede retirar mas del limite diario restante");
                        }
                        else if(retiro>500)
                        {
                            Console.WriteLine("No se puede retirar mas de $500 en una sola operacion");
                        }
                        else if (retiro % 10 != 0 )
                        {
                            Console.WriteLine("Solo se permiten multiplos de 10");
                        }
                    }
                    break;
                    case 3:
                    {
                        Console.WriteLine("Monto a depositar");
                        double montoadepositar=double.Parse(Console.ReadLine()!);
                        if (montoadepositar< 0)
                        {
                            Console.WriteLine("El monto debe ser mayor que 0");
                        }
                        else if  (montoadepositar> 5000)
                        {
                            Console.WriteLine("No puede superar la cantidad de $5000");
                        }
                        else if (montoadepositar> 2500.00)
                        {
                            Console.WriteLine("Sujeto a revision");
                        }
                        else
                        {
                            double nuevosaldo= montoadepositar+ saldoinicial;
                            Console.WriteLine($"Saldo actualizado. Nuevo saldo: {nuevosaldo}");
                        }
                    }
                    break;
                    case 4:
                    {
                        
                    }
                    break;
            }
        }
    else if (cuentaingresada== nodecuenta && piningresado!=pin)
        {
            Console.WriteLine("pin incorrecto");
        }
        else
        {
            Console.WriteLine("Cuenta no encontrada");
        }





}
}
