using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        EventDelegate myEvent = null;

        public event EventDelegate MyEvent
        {
            add { MyEvent += value; }
            remove { MyEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }

    }

    class Program
    {
        static private void Handler1()
        {
            Console.WriteLine("Handler 1");
        }

        static private void Handler2()
        {
            Console.WriteLine("Handler 2");
        }

        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            instance.MyEvent += Handler1;
            instance.MyEvent += Handler2;

            instance.InvokeEvent();

            Console.WriteLine(new string('-',25);

            instance.MyEvent -= Handler2;

            instance.InvokeEvent();
            
            Console.ReadKey();
        }
    }
}
