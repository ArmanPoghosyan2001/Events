﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        public event EventDelegate myEvent = null;

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }



    class Program
    {
        static private void Handler1()
        {
            Console.WriteLine("Event 1 handler");
        }

        static private void Handler2()
        {
            Console.WriteLine("Event 2 handler");
        }


        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            instance.myEvent += new EventDelegate(Handler1);
            instance.myEvent += Handler2;

            instance.InvokeEvent();

            Console.WriteLine(new string('-',25));

            instance.myEvent -= new EventDelegate(Handler2);
            instance.InvokeEvent();

            Console.ReadKey();

        }
    }
}
