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
        private int distance = 50;
        public string HorseName { get; set; }
        public int horseId;
        private int posTop;
        private string space = "";
        private string face = "";
        Random rand = new Random();
        private static int photoFinish = 0;
        public static int IdWinner { get; set; }

        public /*object*/ void Correr()
        {
            string aux = "";
            while (!goal)
            {
                lock (l)//1 -5 2- nada 3- solo 1
                {

                    if (!goal)
                {
                    
                    distance = distance - rand.Next(1,3);
                    aux += space.Substring(0, space.Length - distance);
                    space = space.Substring(0, distance);
                    
                        Console.SetCursorPosition(1, posTop);
                        if (distance == 1)
                        {
                            Console.WriteLine("{2}{0}{3}{1}", " ", "|", aux, space);
                            Console.SetCursorPosition(51, posTop);
                            Console.WriteLine("{0}{1}", " |", face);
                            Console.SetCursorPosition(1, 27);
                            goal = true;
                            photoFinish++;
                            
                            if(photoFinish <= 1)
                            {
                                IdWinner = horseId;
                            }
                            if(photoFinish > 1)
                            {
                                Console.WriteLine("HUBO FOTOFINISH! \nLos jueces estan decidiendo...");
                            }
                            Console.WriteLine("Enter key to continue...");
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
                }
                    Thread.Sleep(100 * rand.Next(2, 6));

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
            photoFinish = 0;
        }


    }
}
