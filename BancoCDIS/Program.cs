using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCDIS
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu, withdraw = 0;
            int[] retiros = new int[10];
            bool resultado;
            //Ciclo que muestra el menu hasta que le es entrada la opcion 3 que ejecuta la salida del programa
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("-----------------------Banco CDIS-------------------------");
                Console.WriteLine("1. Ingresar la cantidad de retiros hechos por los usuarios.");
                Console.WriteLine("2. Revisar la cantidad entregada de billetes y monedas.");
                Console.WriteLine("3. Salida");
                Console.WriteLine();
                Console.Write("Ingresa la opcion: ");
                //Filtro para obtencion de opcion del menu 
                resultado = int.TryParse(Console.ReadLine(),out menu);
                if (resultado)
                {
                    switch (menu)
                    {
                        case 1:
                            //Funcion que permite capturar el numero de retiros a realizar
                            withdraw = Capturar();
                            //Funcion que permite asignar montos a la cantidad de retiros correspondientes 
                            retiros = Definir(withdraw);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine();
                            //Funcion que imprime los resultados en consola teniendo como parametros de entrada el arreglo con los montos de los retiros y la cantidad de retiros ingresados
                            Billetes(retiros, withdraw);
                            break;

                        case 3:
                            //Salida del programa
                            Console.Clear();
                            Console.WriteLine("Vuelve pronto!...");
                            Console.ReadLine();
                            break;
                        default:
                            //Operacion que permite identificar que no se ingreso una opcion permitida en el menu
                            Console.WriteLine("Opcion no definida, prueba de nuevo");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    //Deteccion de caracteres ingresados como opcion para el menu
                    Console.WriteLine("Dato ingresado invalido prueba nuevamente");
                    Console.ReadLine();
                }
            } while (menu != 3);

        }

        public static int Capturar()
        {
            int numero;
            string prueba;
            bool resultado;
            bool salida = true;
            do {
                Console.Clear();
                Console.Write("Cantidad de retiros: ");
                prueba = Console.ReadLine();
                resultado = int.TryParse(prueba, out numero);
                if (resultado)
                {
                    //Definicion de rango permitido
                    if (numero < 1 || numero > 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Numero fuera de rango vuelve a intentarlo");
                        Console.ReadLine();
                    }
                    else
                    {
                        salida = false;
                    }
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Dato no valido para la operacion.");
                    Console.WriteLine("Vuelve a intentarlo...");
                    Console.ReadLine();
                }

            } while (salida);
            return numero;
        }

        public static int[] Definir(int C)
        {
            int[] ret = new int[10];
            string prueba;
            bool resultado;
            bool salida = true;
            int posicion;
            for (int i = 0; i < C; i++)
            {
                do
                {
                    Console.Clear();
                    Console.Write("Ingresa el monto del retiro #" + (posicion=i+1) + ":");
                    prueba = Console.ReadLine();
                    resultado = int.TryParse(prueba, out ret[i]);
                    if (resultado)
                    {
                        //Definicion de rango permitido
                        if (ret[i] < 1 || ret[i] > 50000)
                        {
                            Console.Clear();
                            Console.WriteLine("Numero fuera de rango vuelve a intentarlo");
                            Console.ReadLine();
                        }
                        else
                        {
                            salida = false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Dato no valido para la operacion.");
                        Console.WriteLine("Vuelve a intentarlo...");
                        Console.ReadLine();
                    }
                } while (salida);
            }
            return ret;
        }
        public static void Billetes(int[] cantidades, int i )
        {
            if (i == 0)
            {
                //Deteccion de arreglo vacio
                Console.WriteLine("No se han ingresado valores, favor de pasar a la opcion 1");
                Console.ReadLine();
            }
            else
            {
                //For que imprime los resultados de la opcion 2
                for (int j = 0; j < i; j++)
                {
                    int numero;
                    numero = cantidades[j];
                    int posicion;
                    posicion = j + 1;
                    Console.WriteLine("Retiro #" + posicion+" Por la cantidad de: $"+numero);
                    Console.WriteLine();

                    CuentaBilletes(numero);

                }
                Console.WriteLine("Presione la tecla 'enter' para continuar...");
                Console.ReadLine();
            }
        }
        
        //Metodo que evalua la cantidad de billetes y monedas a entregar por cada retiro
        //Se le agregaron impresiones individuales para cada denominacion monetaria para evaluar mas facilmente el comportamiento del programa
        public static void CuentaBilletes(int evaluar)
        {
            string conversion;
            float resto;
            int CBilletes = 0, CMonedas = 0, SinDecimales;
            if (evaluar >= 500)
            {
                resto = evaluar / 500;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CBilletes = CBilletes + SinDecimales;
                evaluar = evaluar - (SinDecimales * 500);
                Console.WriteLine("Billetes de $500 entregados: " + SinDecimales);
            }
            if (evaluar >= 200)
            {
                resto = evaluar / 200;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CBilletes = CBilletes + SinDecimales;
                evaluar = evaluar - (SinDecimales * 200);
                Console.WriteLine("Billetes de $200 entregados: " + SinDecimales);
            }
            if(evaluar >= 100)
            {
                resto = evaluar / 100;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CBilletes = CBilletes + SinDecimales;
                evaluar = evaluar - (SinDecimales * 100);
                Console.WriteLine("Billetes de $100 entregados: " + SinDecimales);
            }
            if(evaluar >= 50)
            {
                resto = evaluar / 50;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CBilletes = CBilletes + SinDecimales;
                evaluar = evaluar - (SinDecimales * 50);
                Console.WriteLine("Billetes de $50 entregados: " + SinDecimales);
            }
            if (evaluar >= 20)
            {
                resto = evaluar / 20;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CBilletes = CBilletes + SinDecimales;
                evaluar = evaluar - (SinDecimales * 20);
                Console.WriteLine("Billetes de $20 entregados: " + SinDecimales);
            }
            if(evaluar >= 10)
            {
                resto = evaluar / 10;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CMonedas = CMonedas + SinDecimales;
                evaluar = evaluar - (SinDecimales * 10);
                Console.WriteLine("Monedas de $10 entregados: " + SinDecimales);
            }
            if (evaluar >= 5)
            {
                resto = evaluar / 5;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CMonedas = CMonedas + SinDecimales;
                evaluar = evaluar - (SinDecimales * 5);
                Console.WriteLine("Monedas de $5 entregados: " + SinDecimales);
            }
            if(evaluar >= 1)
            {
                resto = evaluar / 1;
                conversion = resto.ToString();
                SinDecimales = int.Parse(conversion);
                CMonedas = CMonedas + SinDecimales;
                evaluar = evaluar - (SinDecimales * 1);
                Console.WriteLine("Monedas de $1 entregados: " + SinDecimales);
            }
            Console.WriteLine();
            Console.WriteLine("Billetes entregados: "+CBilletes);
            Console.WriteLine("Monedas entregadas: " + CMonedas);
            Console.WriteLine();
        }
    }
}
