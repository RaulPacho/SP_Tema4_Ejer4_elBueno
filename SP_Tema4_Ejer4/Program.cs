using System;
using System.Collections.Generic;
using System.Threading;

namespace SP_Tema4_Ejer4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fuckedUp = true;
            string repeat = "1";
            int bet = -1;

            

            while (repeat == "1")
            {
                List<Thread> threads = new List<Thread>();
                List<Horse> horses = new List<Horse>();

                horses.Add(new Horse(0, "HorseMaria", 1, "1"));
                horses.Add(new Horse(1, "HorseLuis", 3, "2"));
                horses.Add(new Horse(2, "MariaHorse", 5, "3"));
                horses.Add(new Horse(3, "Ramon", 7, "4"));
                horses.Add(new Horse(4, "HorseCarlos", 9, "5"));
                fuckedUp = true;
                
                while (fuckedUp)
                {
                    fuckedUp = false;
                    Console.WriteLine("Introduce your bet modafaca");
                    Console.WriteLine("1. HorseMaria");
                    Console.WriteLine("2. HorseLuis");
                    Console.WriteLine("3. MariaHorse");
                    Console.WriteLine("4. Ramon");
                    Console.WriteLine("5. HorseCarlos");
                   
                    if (!int.TryParse(Console.ReadLine(), out bet))
                    {

                        Console.WriteLine("Thats not a number, you moron");
                        fuckedUp = true;
                    }
                    else
                    {
                        bet--;
                        if (bet >= horses.Count || bet < 0)
                        {
                            Console.WriteLine("Thats not a horse, you moron");
                            fuckedUp = true;
                        }
                    }
                }
                
                Console.Clear();
                    for (int i = 0; i < horses.Count; i++)
                    {
                        threads.Add(new Thread(horses[i].Correr));
                        threads[i].Start();
                     }
                    threads[0].Join();
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("And the winner is: " + horses[Horse.IdWinner].HorseName);
                    string str = bet == Horse.IdWinner ? "And yout win, feeling right?" : "Hah! you lost";
                    Console.WriteLine(str);


                    Console.WriteLine("Introduce 1 to repeat Enter to exit");
                    repeat = Console.ReadLine();
                

            }
        }
    }
}
