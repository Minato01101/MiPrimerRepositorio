using System;

class Program
{
    static int[] numeros;

    static void Main()
    {
        bool salir = false;
        numeros = new int[0];

        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    IngresarNumeros();
                    break;
                case "2":
                    MostrarNumerosIngresados();
                    break;
                case "3":
                    EditarNumeroEspecifico();
                    break;
                case "4":
                    EliminarNumero();
                    break;
                case "5":
                    CompararNumeros();
                    break;
                case "6":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Programa finalizado. Gracias por utilizar nuestro sistema.");
        Console.ReadLine();
    }

    static void MostrarMenu()
    {
        Console.WriteLine("----------- Menú -----------");
        Console.WriteLine("1. Ingresar Números");
        Console.WriteLine("2. Mostrar Números Ingresados");
        Console.WriteLine("3. Editar Número Específico");
        Console.WriteLine("4. Eliminar Número");
        Console.WriteLine("5. Comparar Números");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void IngresarNumeros()
    {
        Console.Write("Ingrese la cantidad de números a ingresar: ");
        int cantidad;
        bool esValido = int.TryParse(Console.ReadLine(), out cantidad);

        if (esValido && cantidad > 0)
        {
            int[] nuevosNumeros = new int[numeros.Length + cantidad];

            // Copiar los números existentes al nuevo arreglo
            for (int i = 0; i < numeros.Length; i++)
            {
                nuevosNumeros[i] = numeros[i];
            }

            for (int i = numeros.Length; i < nuevosNumeros.Length; i++)
            {
                Console.Write("Ingrese el número {0}: ", i + 1);
                esValido = int.TryParse(Console.ReadLine(), out nuevosNumeros[i]);

                if (!esValido)
                {
                    Console.WriteLine("Valor inválido. Por favor, intente nuevamente.");
                    i--;
                }
            }

            numeros = nuevosNumeros;

            Console.WriteLine("Números ingresados correctamente.");
        }
        else
        {
            Console.WriteLine("Cantidad inválida. Por favor, intente nuevamente.");
        }
    }

    static void MostrarNumerosIngresados()
    {
        if (numeros.Length > 0)
        {
            Console.WriteLine("Números ingresados:");

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine("Número {0}: {1}", i + 1, numeros[i]);
            }
        }
        else
        {
            Console.WriteLine("No se han ingresado números aún.");
        }
    }

    static void EditarNumeroEspecifico()
    {
        if (numeros.Length > 0)
        {
            Console.Write("Ingrese el índice del número a editar (0-{0}): ", numeros.Length - 1);
            int indice;
            bool esValido = int.TryParse(Console.ReadLine(), out indice);

            if (esValido && indice >= 0 && indice < numeros.Length)
            {
                Console.Write("Ingrese el nuevo valor: ");
                esValido = int.TryParse(Console.ReadLine(), out numeros[indice]);

                if (esValido)
                {
                    Console.WriteLine("Número editado correctamente.");
                }
                else
                {
                    Console.WriteLine("Valor inválido. No se realizó la edición.");
                }
            }
            else
            {
                Console.WriteLine("Índice inválido. Por favor, intente nuevamente.");
            }
        }
        else
        {
            Console.WriteLine("No se han ingresado números aún.");
        }
    }

    static void EliminarNumero()
    {
        if (numeros.Length > 0)
        {
            Console.Write("Ingrese el índice del número a eliminar (0-{0}): ", numeros.Length - 1);
            int indice;
            bool esValido = int.TryParse(Console.ReadLine(), out indice);

            if (esValido && indice >= 0 && indice < numeros.Length)
            {
                int[] nuevosNumeros = new int[numeros.Length - 1];

                for (int i = 0, j = 0; i < numeros.Length; i++)
                {
                    nuevosNumeros[j] = numeros[i];
                        j++;
                    
                }

                numeros = nuevosNumeros;

                Console.WriteLine("Número eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Índice inválido. Por favor, intente nuevamente.");
            }
        }
        else
        {
            Console.WriteLine("No se han ingresado números aún.");
        }
    }

    static void CompararNumeros()
    {
        if (numeros.Length > 0)
        {
            int maximo = int.MinValue;
            int minimo = int.MaxValue;

            foreach (int numero in numeros)
            {
                if (numero > maximo)
                {
                    maximo = numero;
                }

                if (numero < minimo)
                {
                    minimo = numero;
                }
            }

            Console.WriteLine("Número máximo: {0}", maximo);
            Console.WriteLine("Número mínimo: {0}", minimo);
        }
        else
        {
            Console.WriteLine("No se han ingresado números aún.");
        }
    }
}
