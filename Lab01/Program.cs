using System;

class Program
{
    static void Main()
    {
        int plata_cajero = 10000;
        int saldo;

        Console.WriteLine("--- Bienvenido a COCOCASH ---");
        Console.WriteLine();
        Console.WriteLine();

        bool continuar = true;

        // se asegura de que el usuario solo ingrese numero enteros, y en caso de error le pide repetir
        int LeerEntero()
        {
            while (true)
            {
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int v)) return v;
                Console.WriteLine("Error. Por favor ingrese un número entero:");
                Console.WriteLine();
            }
        }

        do
        {
            // Verifica verificamos si el cajero tiene dinero
            if (plata_cajero <= 0)
            {
                Console.WriteLine("Nos encontramos fuera de servicio, vuelva más tarde.");
                Console.WriteLine();
                Console.WriteLine("Gracias por su preferencia.");
                Console.WriteLine();
                continuar = false;
                break;
            }

            bool valido = false;
            do
            {
                Console.WriteLine("Por favor ingrese monto a retirar: ");
                Console.WriteLine();
                Console.Write("S/. ");
                int plata_retiro = LeerEntero();

                if (!(plata_retiro > 0 && plata_retiro % 10 == 0))// se verifica que el ultimo numero sea 0 y que el monto sea positivo
                {
                    Console.WriteLine();
                    Console.WriteLine("Monto invalido!. El ultimo numero debe ser 0.");
                    Console.WriteLine();
                    Console.WriteLine("Intente nuevamente");
                    Console.WriteLine();
                    Console.WriteLine("- Escriba 1 para reintentar.");
                    Console.WriteLine("- Escriba 2 para finalizar.");
                    int obcion = LeerEntero();

                    if (obcion == 2)
                    {
                        Console.WriteLine("Gracias por su preferencia");
                        continuar = false;
                        break;
                    }
                }
                else if (plata_retiro > plata_cajero)// se verifica que plata_retiro deve ser menor a plata_cajero
                {
                    Console.WriteLine();
                    Console.WriteLine("El monto ingresado debe ser menor o igual a: S/." + plata_cajero);
                    Console.WriteLine();
                    Console.WriteLine("Intente nuevamente");
                    Console.WriteLine();
                    Console.WriteLine("- Escriba 1 para reintentar.");
                    Console.WriteLine("- Escriba 2 para finalizar.");
                    int obcion = LeerEntero();

                    if (obcion == 2)
                    {
                        Console.WriteLine("Gracias por su preferencia");
                        continuar = false;
                        break;
                    }
                }
                else // si todo es correcto aqui se ejecuta el retiro de dinero y muestra el salo restante 
                {
                    saldo = plata_cajero - plata_retiro;
                    plata_cajero = saldo;

                    Console.WriteLine();
                    Console.WriteLine("--- Operacion exitosa ---");

                    // se calcula la cantidad de billetes a entregar segun el monto retirado
                    int monto = plata_retiro;

                    int monto1 = monto / 200;
                    monto %= 200;

                    int monto2 = monto / 100;
                    monto %= 100;

                    int monto3 = monto / 50;
                    monto %= 50;

                    int monto4 = monto / 20;
                    monto %= 20;

                    int monto5 = monto / 10;

                    Console.WriteLine("Se entregan:");
                    if (monto1 > 0) Console.WriteLine("Billetes de 200: " + monto1);
                    if (monto2 > 0) Console.WriteLine("Billetes de 100: " + monto2);
                    if (monto3 > 0) Console.WriteLine("Billetes de 50: " + monto3);
                    if (monto4 > 0) Console.WriteLine("Billetes de 20: " + monto4);
                    if (monto5 > 0) Console.WriteLine("Billetes de 10: " + monto5);

                    Console.WriteLine();
                    Console.WriteLine("Saldo restante: S/." + saldo);
                    Console.WriteLine();
                    valido = true; // salir del bucle interno

                    if (plata_cajero <= 0)
                    {
                        Console.WriteLine("Nos encontramos fuera de servicio, vuelva más tarde.");
                        Console.WriteLine("Gracias por su preferencia.");
                        continuar = false;
                        break;
                    }

                    Console.WriteLine("- Escriba 1 si desea realizar otra operacion.");
                    Console.WriteLine("- Escriba 2 para finalizar.");
                    int obcion = LeerEntero();

                    if (obcion == 2)
                    {
                        Console.WriteLine("Gracias por su preferencia");
                        continuar = false;
                        break;
                    }
                }

            } while (!valido);

        } while (continuar);
    }
}