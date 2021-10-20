using System;

namespace Conteo_caracteres
{
    class Program
    {
        static void Main(string[] args)
        {

            string frase, aux;
            int j;
            int vocales = 0;
            int acentos = 0;
            int numeros = 0;
            int consonantes = 0;
            char i;

            Console.WriteLine("Bienvenido al contador de vocales y consonantes");
            Console.WriteLine("Por favor, escriba la frase que desea contar.");
            frase = Console.ReadLine();


            /*char[] arrchars = frase.ToCharArray();*/
            aux = frase.Replace(" ", "");

            for (j = 0; j < aux.Length; j++)
            {
                i = aux[j];
                int c = char.ToLower(i);

                if ((c == 'a') | (c == 'e') | (c == 'i') | (c == 'o') | (c == 'a'))
                {
                    vocales++;
                }
                else if ((c == 'á') | (c == 'é') | (c == 'í') | (c == 'ó') | (c == 'ú'))
                {
                    vocales++;
                    acentos++;
                }
                else if ((c == '1') | (c == '2') | (c == '3') | (c == '4') | (c == '5') | (c == '6') | (c == '7') | (c == '8') | (c == '9') | (c == '0'))
                {
                    numeros++;
                }
                else
                {
                    consonantes++;
                }
            }
            Console.WriteLine("La frase tiene "+ aux.Length + " caracteres");
            Console.WriteLine("  "+frase+" tiene " + vocales + " vocales");
            Console.WriteLine("  " + frase + " tiene " + acentos + " vocales con acento");
            if (acentos == 0)
            {
                Console.WriteLine("La frase no tiene acentos.");
            }
            Console.WriteLine("  " + frase +" tiene " + consonantes + " consonantes");
            Console.WriteLine("  " + frase +" tiene " + numeros + " numeros");
            Console.ReadKey();
        }
    }
}
