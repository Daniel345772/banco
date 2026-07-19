using System;
using System.Collections;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        int nodecuenta, pin;
        string nombrecliente;
        double saldoinicial, limiteretiro, montoretirado, total;
        nodecuenta = 100200300;
        pin = 2580;
        nombrecliente = "Juan Perez";
        saldoinicial = 2750.50;
        limiteretiro = 1200.00;
        montoretirado = 350.00;

        Console.WriteLine("Ingrese numero de cuenta: ");
        int cuentaingresada = int.Parse(Console.ReadLine()!);
        Console.WriteLine("ingrese su pin: ");
        int piningresado = int.Parse(Console.ReadLine()!);
        
        total = limiteretiro - montoretirado;

        if (cuentaingresada == nodecuenta && piningresado == pin)
        {
            Console.WriteLine($"Bienvenido: {nombrecliente}");
            Console.WriteLine("1-Consultar saldo");
            Console.WriteLine("2-retirar dinero");
            Console.WriteLine("3- depositar dinero");
            Console.WriteLine("4- transferir dinero");
            Console.WriteLine("5- cambiar pin");
            Console.WriteLine("6-simular prestamo");
            Console.WriteLine("7- resumen de cuenta");
            Console.WriteLine("8- salir");
            
            int opcioningresada = int.Parse(Console.ReadLine()!);
            switch (opcioningresada)
            {
                case 1:
                    {
                        Console.WriteLine($"Su saldo actual es: ${saldoinicial:F2}");
                        Console.WriteLine($"Saldo disponible para retirar: ${limiteretiro:F2}");
                        Console.WriteLine($"Limite restante del dia: ${total:F2}");
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("Cuanto dinero va a retirar? ");
                        double retiro = double.Parse(Console.ReadLine()!);
                        if (retiro <= 0)
                        {
                            Console.WriteLine("cantidad invalida");
                        }
                        else if (retiro > saldoinicial)
                        {
                            Console.WriteLine("No puede retirar mas saldo del disponible");
                        }
                        else if (retiro > total)
                        {
                            Console.WriteLine("No puede retirar mas del limite diario restante");
                        }
                        else if (retiro > 500)
                        {
                            Console.WriteLine("No se puede retirar mas de $500 en una sola operacion");
                        }
                        else if (retiro % 10 != 0)
                        {
                            Console.WriteLine("Solo se permiten multiplos de 10");
                        }
                        else
                        {
                            saldoinicial = saldoinicial - retiro;
                            montoretirado = montoretirado + retiro;
                            total = limiteretiro - montoretirado;
                            Console.WriteLine("Realizado exitosamente. Monto retirado: $" + retiro.ToString("F2"));
                            Console.WriteLine("Nuevo saldo actual: $" + saldoinicial.ToString("F2"));
                        }
                    }
                    break;

                case 3:
                    {
                        Console.WriteLine("Monto a depositar");
                        double montoadepositar = double.Parse(Console.ReadLine()!);
                        if (montoadepositar <= 0)
                        {
                            Console.WriteLine("El monto debe ser mayor que 0");
                        }
                        else if (montoadepositar > 5000)
                        {
                            Console.WriteLine("No puede superar la cantidad de $5000");
                        }
                        else
                        {
                            saldoinicial = saldoinicial + montoadepositar;
                            if (montoadepositar > 2500.00)
                            {
                                Console.WriteLine("Sujeto a revision");
                            }
                            Console.WriteLine($"Saldo actualizado. Nuevo saldo: ${saldoinicial:F2}");
                        }
                    }
                    break;

                case 4:
                    {
                        Console.WriteLine("Ingrese la cuenta destino (9 dígitos):");
                        int cuentaDestino = int.Parse(Console.ReadLine()!);

                        Console.WriteLine("Ingrese el monto a transferir:");
                        double montoTransferir = double.Parse(Console.ReadLine()!);

                        double comision = 0;
                        if (montoTransferir <= 500) { comision = 2.00; }
                        else if (montoTransferir <= 1000) { comision = 5.00; }
                        else { comision = 8.00; }

                        if (cuentaDestino == nodecuenta)
                        {
                            Console.WriteLine("Operación rechazada: No puede transferir a su propia cuenta.");
                        }
                        else if (cuentaDestino < 100000000 || cuentaDestino > 999999999)
                        {
                            Console.WriteLine("Operación rechazada: La cuenta destino debe tener exactamente 9 dígitos.");
                        }
                        else if (montoTransferir <= 0)
                        {
                            Console.WriteLine("Operación rechazada: El monto debe ser mayor que cero.");
                        }
                        else if ((montoTransferir + comision) > saldoinicial)
                        {
                            Console.WriteLine("Operación rechazada: Saldo insuficiente para cubrir la transferencia y la comisión.");
                        }
                        else
                        {
                            saldoinicial = saldoinicial - (montoTransferir + comision);
                            Console.WriteLine("\n--- COMPROBANTE DE TRANSFERENCIA ---");
                            Console.WriteLine($"Cuenta destino: {cuentaDestino}");
                            Console.WriteLine($"Monto enviado:  ${montoTransferir:F2}");
                            Console.WriteLine($"Comisión:       ${comision:F2}");
                            Console.WriteLine($"Saldo restante: ${saldoinicial:F2}");
                            Console.WriteLine("------------------------------------\n");
                        }
                    }
                    break;
               
                case 5:
                    {
                        Console.WriteLine("Ingrese su PIN actual:");
                        int pinActual = int.Parse(Console.ReadLine()!);

                        Console.WriteLine("Ingrese su nuevo PIN (4 dígitos):");
                        int nuevoPin = int.Parse(Console.ReadLine()!);

                        Console.WriteLine("Confirme su nuevo PIN:");
                        int confirmacionPin = int.Parse(Console.ReadLine()!);

                        if (pinActual != pin)
                        {
                            Console.WriteLine("Operación rechazada: El PIN actual es incorrecto.");
                        }
                        else if (nuevoPin == pin)
                        {
                            Console.WriteLine("Operación rechazada: El nuevo PIN no puede ser igual al anterior.");
                        }
                        else if (nuevoPin < 1000 || nuevoPin > 9999)
                        {
                            Console.WriteLine("Operación rechazada: El PIN debe tener exactamente 4 dígitos y no puede iniciar con cero.");
                        }
                        else if (nuevoPin != confirmacionPin)
                        {
                            Console.WriteLine("Operación rechazada: La confirmación no coincide con el nuevo PIN.");
                        }
                        else
                        {
                            pin = nuevoPin;
                            Console.WriteLine("PIN actualizado correctamente.");
                        }
                    }
                    break;

                case 6:
                    {
                        Console.WriteLine("Cuanto dinero solicita? ");
                        double montosolicitado = double.Parse(Console.ReadLine()!);
                        if (montosolicitado > 15000)
                        {
                            Console.WriteLine("Requiere aprobación del gerente.");
                        }
                        else
                        {
                            Console.WriteLine("Cuanto sera el plazo?");
                            Console.WriteLine("1) 12, 2) 24 o 3) 36 meses?");
                            int plazo = int.Parse(Console.ReadLine()!);
                            switch (plazo)
                            {
                                case 1:
                                    {
                                        double tasa12 = montosolicitado * 0.08;
                                        double totalprestamo = montosolicitado + tasa12;
                                        double cuotamensual = totalprestamo / 12;
                                        Console.WriteLine("el interes sera de: " + tasa12);
                                        Console.WriteLine("Total a pagar: " + totalprestamo);
                                        Console.WriteLine("Su cuota mensual sera:" + cuotamensual);
                                    }
                                    break;
                                case 2:
                                    {
                                        double tasa24 = montosolicitado * 0.12;
                                        double totalprestamo = montosolicitado + tasa24;
                                        double cuotamensual = totalprestamo / 24;
                                        Console.WriteLine("el interes sera de: " + tasa24);
                                        Console.WriteLine("Total a pagar: " + totalprestamo);
                                        Console.WriteLine("Su cuota mensual sera:" + cuotamensual);
                                    }
                                    break;
                                case 3:
                                    {
                                        double tasa36 = montosolicitado * 0.18;
                                        double totalprestamo = montosolicitado + tasa36;
                                        double cuotamensual = totalprestamo / 36;
                                        Console.WriteLine("el interes sera de: " + tasa36);
                                        Console.WriteLine("Total a pagar: " + totalprestamo);
                                        Console.WriteLine("Su cuota mensual sera:" + cuotamensual);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Opción de plazo inválida. Seleccione 1, 2 o 3.");
                                    break;
                            }
                        }
                    }
                    break;

                case 7:
                    {
                        string estadoCliente = "";
                        if (saldoinicial > 2000) { estadoCliente = "Cliente Oro"; }
                        else if (saldoinicial >= 1000 && saldoinicial <= 1999) { estadoCliente = "Cliente Plata"; }
                        else { estadoCliente = "Cliente Bronce"; }

                        string mensajeFinanciero = "";
                        if (saldoinicial > 5000) { mensajeFinanciero = "Excelente capacidad financiera"; }
                        else if (saldoinicial >= 2000 && saldoinicial <= 5000) { mensajeFinanciero = "Finanzas saludables"; }
                        else if (saldoinicial >= 1000 && saldoinicial <= 1999) { mensajeFinanciero = "Controle sus gastos"; }
                        else { mensajeFinanciero = "Nivel de saldo bajo"; }

                        Console.WriteLine("       RESUMEN DE CUENTA         ");
                        Console.WriteLine($"Cliente:             {nombrecliente}");
                        Console.WriteLine($"Número de cuenta:    {nodecuenta}");
                        Console.WriteLine($"Saldo actual:        ${saldoinicial:F2}");
                        Console.WriteLine($"Monto retirado hoy:  ${montoretirado:F2}");
                        Console.WriteLine($"Límite restante:     ${total:F2}");
                        Console.WriteLine($"Estado de la cuenta: {estadoCliente}");
                        Console.WriteLine($"Nota financiera:     {mensajeFinanciero}");
                        Console.WriteLine("=================================");
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;

                case 8:
                    Console.WriteLine("Gracias por utilizar BancoTech");
                    break;
            }
        }
        else if (cuentaingresada == nodecuenta && piningresado != pin)
        {
            Console.WriteLine("pin incorrecto");
        }
        else
        {
            Console.WriteLine("Cuenta no encontrada");
        }
    }
}