using System;

namespace ATM
{
    public class Cajero
    {
        string[] movimientos = new string []{};
        double[] cantidades;
        string linea;
        float saldo;
        int x = 0;

        public static void Main(string[] args)
        {
            Cajero c = new Cajero();
            string usuario = "18111306";
            string contra = "administrador";
            string op;
            int intentos = 0;
            try
            {
                while (intentos != 3)
                {
                    Console.Clear();
                    Console.WriteLine("INGRESE SU USUARIO");
                    string tarjeta = Console.ReadLine();
                    if (tarjeta == usuario)
                    {
                        Console.WriteLine("Ingrese su contraseña");
                        string pass = Console.ReadLine();
                        if (pass == contra)
                        {
                            Console.Clear();
                            op = c.imprimir_menu();
                            do
                            {
                                switch (op)
                                {
                                    case "1":
                                        c.RetiroEfectivo();
                                        break;
                                    case "2":
                                        c.Deposito();
                                        break;
                                    case "3":
                                        c.ConsultarSaldo();
                                        break;
                                    case "5":
                                        c.ver_movimientos();
                                        break;
                                    case "6":
                                        c.salir();
                                        break;
                                }
                                op = c.imprimir_menu();
                            } while (op != "7");
                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta, intente nuevamente");
                            Console.ReadKey();
                            intentos++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usuario incorrecto, intente nuevamente");
                        Console.ReadKey();
                        intentos++;
                    }
                }
                if (intentos == 3)
                {
                    Console.WriteLine("Cuenta bloqueda");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                c.imprimir_menu();
            }
        }//Fin del metodo static
        public string imprimir_menu()
        {
            Console.Clear();
            Console.WriteLine("***Operaciones basicas***");
            Console.WriteLine("1. RETIRAR");
            Console.WriteLine("2. DEPOSITAR");
            Console.WriteLine("3. CONSULTAR");
            Console.WriteLine("4. TRANSFERIR");
            Console.WriteLine("5. VER MOVIMIENTOS");
            Console.WriteLine("6. SALIR");
            Console.WriteLine("Ingrese una opcion:");
            linea = Console.ReadLine();
            return linea;
        }//fin de imprimir_menu------------------------------------------------------------------------------------------------
        public void RetiroEfectivo()
        {
            try
            {
                Console.WriteLine("Ingrese la cantidad a retirar:");
                int retiro = Convert.ToInt32(Console.ReadLine());
                if (validar_multiplo(retiro) == true)
                {

                    if (saldo >= retiro)
                    {
                        DateTime fecha = DateTime.Now;
                        saldo = saldo + retiro;
                        Console.WriteLine("Monto a retirar:" + retiro);
                        Console.WriteLine("Balance Anterior:"+ saldo);
                        Console.WriteLine("Nuevo Balance:" +saldo_nuevo(retiro));

                        int mas = movimientos.Length + 1;
                        string[] auxi = new string[mas];//Creo un vector auxiliar con el nuevo tamaño
                        Array.Copy(movimientos, auxi, movimientos.Length);//Copio los datos del antiguo vector al auxiliar
                        movimientos = new string[mas];//Modifico el tamaño del antiguo vector
                        Array.Copy(auxi, movimientos,mas);//Regreso los valores al vector original

                        //Guardo el movimiento en el vector
                        for (x = 0; x < movimientos.Length; x++)
                        {
                            if ((movimientos[x] == null))
                            {
                                movimientos[x] = "Retiro por $"+retiro;
                            }//Fin del if
                        }//Fin del for
                    }
                    else
                    {
                        Console.WriteLine("Usted no dispode de saldo suficiente");
                        Console.ReadKey();
                        imprimir_menu();
                    }
                    // Esperar para volver
                    Console.ReadKey();
                    imprimir_menu();
                }
                if (validar_multiplo(retiro) == false)
                {
                    Console.WriteLine("Unicamente se aceptan multiplos de 5");
                    imprimir_menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "VOLVIENDO AL MENU...");
                Console.ReadKey();
                imprimir_menu();
            }
        }
        public Boolean validar_multiplo(int a)
        {
            if (a % 5 == 0)
            {
                return true;
            }
            return false;
        }
        public int saldo_nuevo(int a)
        {
            int nuevo = (int)(saldo - a);
            return nuevo;
        }
        public void Deposito()
        {
            Console.WriteLine("Ingrese la cantidad que desea depositar: ");
            try
            {
                int cant = Int32.Parse(Console.ReadLine());
                if (validar_multiplo(cant) == true)
                {
                    DateTime fecha = DateTime.Now;
                    saldo = saldo+cant;
                    Console.WriteLine("El deposito fue exitoso");
                    ConsultarSaldo();

                    int mas = movimientos.Length + 1;
                    string[] auxi = new string[mas];//Creo un vector auxiliar con el nuevo tamaño
                    Array.Copy(movimientos, auxi, movimientos.Length);//Copio los datos del antiguo vector al auxiliar
                    movimientos = new string[mas];//Modifico el tamaño del antiguo vector
                    Array.Copy(auxi, movimientos, mas);//Regreso los valores al vector original

                    //Guardo el movimiento en el vector
                    for (x = 0; x < movimientos.Length; x++)
                    {
                        if ((movimientos[x] == null))
                        {
                            movimientos[x] = "Desposito por $" + cant;
                        }//Fin del if
                    }//Fin del for
                    Console.ReadKey();
                    imprimir_menu();

                }
                else
                {
                    Console.WriteLine("Unicamente se aceptan multiplos de $5");
                    Console.ReadKey();
                    imprimir_menu();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "VOLVIENDO AL MENU...");
                Console.ReadKey();
                imprimir_menu();
            }
        }
        public void ConsultarSaldo()
        {
            Console.WriteLine("Su balance es de $ " + saldo);
            Console.ReadKey();
            imprimir_menu();
        }
        public void ver_movimientos()
        {
            for (x = 0; x < movimientos.Length; x++)
            {
                Console.WriteLine(movimientos[x]);
            }
            Console.WriteLine("\n");
            Console.ReadKey();
            imprimir_menu();
        }
        public void salir()
        {
            Environment.Exit(1);
        }
    }
}
