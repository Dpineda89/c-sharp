using System;
using System.Collections.Generic;

namespace inventario
{
    class Program
    {
        static string[,] productos = new string[5,3]
        {
            { "001", "iPhoneX", "0" },
            { "002", "Laptop Dell", "5" },
            { "003", "Monitor Samsung", "2" },
            { "004", "Mouse", "100" },
            { "005", "Headset", "25" },
        };

        static List<string> movimientos= new List<string>();

        static void listarProductos() {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Listado de Productos");
            Console.WriteLine("********************");
            Console.WriteLine("Codigo, Descripcion y Existencia");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(productos[i, 0] + " | " + productos[i, 1] + " | " + productos[i, 2]);
            }

            Console.ReadLine();
        }
            static bool movimientoInventario(string codigo, int cantidad, string tipoMovimiento) {
            for (int i = 0; i < 5; i++)
            {
                if (productos[i, 0] == codigo) {        
                    if (tipoMovimiento == "+") {
                        productos[i, 2] = (Int32.Parse(productos[i, 2]) + cantidad).ToString();
                    } else {
                        productos[i, 2] = (Int32.Parse(productos[i, 2]) - cantidad).ToString();
                    }
                    return true;
                }
            }
                return false;
            }        
            

        static void ingresoDeInventario() {
            string codigo = "";
            string cantidad = "";

            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Ingreso de Productos al Inventario");
            Console.WriteLine("**********************************");
            Console.Write("Ingrese el codigo del producto: ");
            codigo = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto: ");
            cantidad = Console.ReadLine();

            movimientoInventario(codigo, Int32.Parse(cantidad), "+");
        }

        static void salidaDeInventario() {
            string codigo = "";
            string cantidad = "";

            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("salida de Productos al Inventario");
            Console.WriteLine("**********************************");
            Console.Write("Ingrese el codigo del producto: ");
            codigo = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto: ");
            cantidad = Console.ReadLine();

            movimientoInventario(codigo, Int32.Parse(cantidad), "-");
        }

         static void negativoDeInventario() {
            string codigo = "";
            string cantidad = "";

            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Ingrese el Ajuste Negativo del Productos al Inventario");
            Console.WriteLine("**********************************");
            Console.Write("Ingrese el codigo del producto: ");
            codigo = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto: ");
            cantidad = Console.ReadLine();

            bool resultado = movimientoInventario(codigo, Int32.Parse(cantidad), "+");
            if(resultado)
            {
                string valor = codigo + " | " + Int32.Parse(cantidad) + " | +";
                movimientos.Add(valor); 
            }
            else
            {
                Console.WriteLine("No se encontro un producto con el codigo ingresado");
            }
        }

        static void positivoDeInventario() {
            string codigo = "";
            string cantidad = "";

            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Ingrese el Ajuste Positivo del Productos al Inventario");
            Console.WriteLine("**********************************");
            Console.Write("Ingrese el codigo del producto: ");
            codigo = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto: ");
            cantidad = Console.ReadLine();

            bool resultado = movimientoInventario(codigo, Int32.Parse(cantidad), "+");
            if(resultado)
            {
                string valor = codigo + " | " + Int32.Parse(cantidad) + " | +";
                movimientos.Add(valor); 
            }
            else
            {
                Console.WriteLine("No se encontro un producto con el codigo ingresado");
            }
        }

        static void ajusteDeInventario()
        {
            string tipoMovimiento;
            Console.WriteLine("Que tipo de ajuste hara: 1.Positivo 2.Negativo");
            tipoMovimiento = Console.ReadLine();
            switch (tipoMovimiento)
            {
            case "1":
                positivoDeInventario();
                break;
            case "2":
                negativoDeInventario();
                break;
            
            default:
                break;
            }
        }

        static void printMovimientos()
        {
            Console.WriteLine("HISTORIAL DE AJUSTES");
            foreach(var item in movimientos)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");
        }
        static void Main(string[] args)  {
            string opcion = "";

            while (true) {

        Console.WriteLine("Sistema de Invenntario");
        Console.WriteLine();
        Console.WriteLine("**********************");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1 - Productos");
        Console.WriteLine("2 - Ingreso de Inventario");
        Console.WriteLine("3 - Salida de Inventario");
        Console.WriteLine("4 - Ajuste de Inventario");
        Console.WriteLine("5 - Mostrar historial de Ajustes de Inventario");
        Console.WriteLine("0 - Salir ");
        Console.WriteLine("Ingrese una opcion del menu: ");
        opcion = Console.ReadLine();
        
        switch (opcion)
        {
        case "1":
            listarProductos();
            break;
        case "2":
            ingresoDeInventario();
            break;

        case "3":
            salidaDeInventario();
            break;
        case "4":
            ajusteDeInventario();
            break;
        case "5":
            printMovimientos();
            break;
        default:
            break;

        }
        Console.WriteLine();

        if (opcion == "0") {
            break;
        }
        }
        }
    }
}