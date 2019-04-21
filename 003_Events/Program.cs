using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Events
{
    public delegate void PressKeyEventHandler();

    public class Keyboard
    {
        public event PressKeyEventHandler PressKeyA = null;
        public event PressKeyEventHandler PressKeyB = null;

        public void PressKeyAEvent()
        {
            if(PressKeyA != null)
            {
                PressKeyA.Invoke();
            }
        }

        public void PressKeyBEvent()
        {
            if (PressKeyB != null)
            {
                PressKeyB.Invoke();
            }
        }

        public void Start()
        {
            while (true)
            {
                string s = Console.ReadLine();

                switch (s)
                {
                    case "a":
                    case "A":
                        PressKeyAEvent();
                        break;

                    case "b":
                    case "B":
                        PressKeyBEvent();
                        break;
                    case "exit":
                        goto Exit;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
            Exit:
            Console.WriteLine("Exit");
        }

    }
    class Program
    {
        static private void PressKeyA_Handler()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("  A   ");
        }

        static private void PressKeyB_Handler()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("  B   ");
        }


        static void Main(string[] args)
        {
            Keyboard keyboard = new Keyboard();

            keyboard.PressKeyA += PressKeyA_Handler;
            keyboard.PressKeyB += PressKeyB_Handler;

            keyboard.Start();

        }
    }
}
