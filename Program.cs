using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

/*
 * ------------------------------- N E X U S 6 ------------------------------------------
 * Lista criada com os 25 numeros ------------------------------------------------------- OTIMIZADO, PODE PRINTAR A QUANTIDADE DESEJADA DE NUMEROS
 * Escolher randomicamente 15 numeros da lista ------------------------------------------ OK
 * Refazer o processo 11 vezes no total ------------------------------------------------- OTIMIZADO COM FUCKING CLASSES
 * Comparar todos os 11 jogos e ver se todos os numeros foram utilizados ---------------- NAO
 * Comparar todos os jogos para realizar um novo jogo com a média de numeros escolhidos.. NÃO
 * Printar as novas listas de maneira coerente e organizada na tela --------------------- SIM
 * Menu interativo com escolhas de numero de jogos e quantidade de numeros escolhidos---- SIM
 */

namespace __NEXUS__
{
    internal class Program
    {
        //Menu
        static public int DisplayMenu()
        {
            StreamReader details = new StreamReader("Details.txt"); //manter o .txt na pasta do código sempre
            String line = details.ReadToEnd(); //le o txt
            Console.WriteLine(line);
            Console.WriteLine();
            Console.WriteLine("1....................START");
            Console.WriteLine("2....................INFO");
            Console.WriteLine("3....................QUIT");
            Console.WriteLine(" ");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        //Classe de operação e da seleção e escolha dos numeros
        public static void Calc(int numberInt, int totalInt)
        {
            int numero = numberInt; //declaro que a minha variavel inserida no main é a mesma que a que eu uso aqui dentro para o apontador IMPORTANTE!!!!!!!
            int total = totalInt; //modificador do numero total de itens na lista

            IEnumerable<int> lotoF = Enumerable.Range(1, total); //nova lista que posso alterar mais facil, a antiga continua aqui em baixo caso precise
            //List<int> lotoF = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }; //numeros 1 a 25
            IEnumerable<int> randomNumbers = lotoF.OrderBy(x => Guid.NewGuid()).Take(numero); // escolhe os numeros aleatorios da lista lotoF
            IEnumerable<int> randomNumbersOrdened = randomNumbers.OrderBy(n => n); // coloca em ordem os numeros da lista randomNumbers

            foreach (int n in randomNumbersOrdened) //foreach para pegar os 15 numeros dentro da lista aleatoria ordenada
            {
                Console.WriteLine(n);
            }

        }

        //Seção About do menu
        public static void About()
        {
            StreamReader sobre = new StreamReader("sobre.txt"); //manter o .txt na pasta do código sempre
            String line = sobre.ReadToEnd(); //le o txt
            Console.WriteLine(line);
        }

        //Programa
        private static void Main()
        {
            //muda a cor do console GIMMICK TOTAL
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(120, 48);
            Console.Clear();

            //INICIO
            string rounds; //variavel da quantidade de jogos na inserção
            string numbers; //variavel de quantidade de numeros dos jogos na inserção
            string total;
            int totalInt;
            int roundsInt; //conversão da variavel rounds para int
            int numbersInt; //conversão da variavel numbers para int
            int userInput = 0; //variavel para escolhas do menu

            //loop do menu
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    //Case 1 é o loop principal, o programa mais importante
                    case 1:
                        if (userInput == 1)
                            Console.WriteLine(" ");
                        Console.WriteLine("How many numbers in total:");
                        total = Console.ReadLine();
                        Int32.TryParse(total, out totalInt);
                        Console.WriteLine();
                        Console.WriteLine("Number of rounds: ");
                        //pego a quantidade de jogos desejada e armazeno em uma variavel chamada rounds
                        rounds = System.Console.ReadLine();
                        //porem rounds é do tipo string, entao converto o numero em int para usar no loop
                        Int32.TryParse(rounds, out roundsInt); //outra forma de converter para int o valor é usar Convert.ToInt32(variavel);

                        Console.WriteLine($"How many selected numbers - from 1 to {totalInt}: "); //basicamente o mesmo hack ali de cima só que para operar outra variavel
                        numbers = Console.ReadLine();
                        Int32.TryParse(numbers, out numbersInt);
                        Console.WriteLine(" "); //espaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaço

                        Console.WriteLine($"Generating {roundsInt} games with {numbersInt} numbers each one...");
                        for (int i = 1; i <= roundsInt; i++) // for loop 1 OTIMIZADO
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine($"Game {i}");
                            Calc(numbersInt, totalInt); //caralho que delicia só chamar a classe e não precisar enfiar tudo aquela bagunça aqui dentro kkkkkkk
                            Console.WriteLine(" ");
                        }
                        Console.WriteLine("For new game hit ENTER");
                        //implementar função para salvar os resultados em um txt, mas isto fica para o futuro
                        Console.ReadKey();
                        break;

                    //Seção about do menu
                    case 2:
                        if (userInput == 2)
                            About();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Seção Exit
                    default:
                        Console.WriteLine("BYE!");
                        break;
                }
            } while (userInput != 3);
        }
    }
}