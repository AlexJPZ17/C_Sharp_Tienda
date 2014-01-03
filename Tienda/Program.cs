using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    class Program
    {
        static void Main(string[] args)
        {

            string inicial;
            Console.ForegroundColor = ConsoleColor.White;

            menu entrar = new menu();
            Console.WriteLine("Bienvenido a la tienda");
            inicial = Console.ReadLine();
            entrar.start(inicial);
        }
    }
    //struct es un tipo de valor que se utilizar para encapsular pequeños grupos de variables
    public struct Producto
    {
        public string ID;
        public string Nombre;
        public double Precio;

        public Producto(string id, string nombre, double precio)
        {

            ID = id;
            Nombre = nombre;
            Precio = precio;
        }
    }
    class menu
    {

        //Arreglos
        Producto[] listaDeGolosinas = new Producto[] { 

	            //Entrada por el teclado "A1" como la id, Nombre del golosina "Doritos", Precio del producto 4
	            new Producto("A1", "Galletas", 5),	           
                new Producto("B1", "Refresco", 10),
	            new Producto("C1", "Pizza", 15),	            
                new Producto("D1", "Chocolate", 6),
	            new Producto("E1", "Doritos", 4),	            
	 
	        };
        private double SolicitarPago()
        {

            bool pagoCorrecto = false;

            double res = 0;

            while (!pagoCorrecto)
            {

                Console.WriteLine("Como desea pagar con: 10, 5");

                try
                {

                    res = double.Parse(Console.ReadLine());
                    if (res != 5 && res != 10)
                        Console.WriteLine("Pago no valido");
                    else
                        pagoCorrecto = true;

                }
                catch
                {

                    Console.WriteLine("Por favor, Como desea pagar con: 10, 5");

                }
            }

            return res;
        }
        public void start(string entrar)
        {

            //Dictionary se utiliza cuando tenemos muchos elementos diferentes
            //
            Dictionary<String, Producto> ProductosEnLaTienda = new Dictionary<string, Producto>();
            //hacemos un ciclo for para listaDeProductos
            for (int i = 0; i < listaDeGolosinas.Length; i++)
                ProductosEnLaTienda.Add(listaDeGolosinas[i].ID, listaDeGolosinas[i]);

            double total = 0;
            string des = "";

            // hacemos un ciclo do while para des
            do
            {
                Console.WriteLine("Venta de golosinas");
                //La instrucción foreach  recorrer ProductosEnLaMaquina y lo repitge 
                foreach (Producto p in ProductosEnLaTienda.Values)
                    Console.WriteLine(p.ID + " --- " + p.Nombre);

                string producto = Console.ReadLine().ToUpper();
                //hacemos un while para ProductosEnLaMaquina para evaluar lo que se ingrece por la consila 
                while (!ProductosEnLaTienda.ContainsKey(producto))
                {

                    Console.WriteLine("Golosinas no disponible, por favor seleccione otro.");
                    producto = Console.ReadLine().ToUpper();

                }

                Console.WriteLine("Su monto apagar es: " + ProductosEnLaTienda[producto].Precio.ToString() + "$ Dolar");

                double pago = SolicitarPago();

                //hacemos un while
                while (pago < ProductosEnLaTienda[producto].Precio)
                {

                    Console.WriteLine("Faltan " + (ProductosEnLaTienda[producto].Precio - pago).ToString() + " Dolar");
                    pago += SolicitarPago();

                }

                Console.WriteLine("Su cambio: " + (pago - ProductosEnLaTienda[producto].Precio).ToString());

                total += ProductosEnLaTienda[producto].Precio;

                Console.WriteLine("Su pago fue de: " + total.ToString() + " Dolar");
                Console.WriteLine("¿Desea realizar otra compra?");

                des = Console.ReadLine();

            } while (des.ToLower() == "s" || des.ToLower() == "si");

            Console.ReadLine();
        }

    }

}



