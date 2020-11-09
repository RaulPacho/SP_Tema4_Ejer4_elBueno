using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SP_Tema4_Ejer4
{
    class Horse
    {
        private static object l = new object();
        public static bool goal = false;
        private int distance = 10;
        public string HorseName { get; set; }
        public int horseId;
        private int posTop;
        private string space = "";
        private string face = "";
        Random rand = new Random();
        public static int IdWinner { get; set; }

        public /*object*/ void Correr()
        {
            string aux = "";
            while (!goal)
            {
                if (!goal)
                {
                    distance--;
                    aux += space.Substring(0, space.Length - distance);
                    space = space.Substring(0, distance);
                    lock (l)
                    {

                        Console.SetCursorPosition(1, posTop);
                        if (distance == 1)
                        {
                            Console.WriteLine("{2}{0}{3}{1}", " ", "|", aux, space);
                            Console.SetCursorPosition(51, posTop);
                            Console.WriteLine("{0}{1}", " |", face);
                            Console.SetCursorPosition(1, 27);
                            Console.WriteLine("Enter key to continue...");
                            goal = true;
                            IdWinner = horseId;
                        }
                        else
                        {
                            Console.WriteLine("{2}{0}{3}{1}", face, "|", aux, space);
                        }
                    }
                    /*if(distance == 1)
                    {
                        Console.SetCursorPosition(51, posTop);
                        Console.WriteLine("{0}{1}", " |", "h");
                        goal = true;
                    }*/
                    Thread.Sleep(100 * rand.Next(2, 6));
                }

            }
            //return null;
        }

        public Horse(int id, string name, int posTop, string face)
        {
            horseId = id;
            HorseName = name;
            this.posTop = posTop;
            this.face = face;
            goal = false;
            for (int i = 0; i < distance; i++)
            {
                space += " ";
            }
        }


    }
}
