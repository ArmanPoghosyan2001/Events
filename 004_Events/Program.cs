using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_Events
{
    public delegate void EventDelegate();

    interface IInterface
    {
        event EventDelegate MyEvent;
    }

    public class BaseClass: IInterface
    {
        EventDelegate myEvent = null;
        public virtual event EventDelegate MyEvent
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    public class DerivedClass : BaseClass
    {
        public override event EventDelegate MyEvent
        {
            add
            {
                base.MyEvent += value;
                Console.WriteLine(value.Method.Name);
            }

            remove
            {
                base.MyEvent -= value;
                Console.WriteLine(value.Method.Name);
            }

        }
    }

    class Program
    {
        static private void Handler1()
        {
            Console.WriteLine("Handler1");
        }

        static private void Handler2()
        {
            Console.WriteLine("Handler2");
        }

        static void Main(string[] args)
        {
            DerivedClass instance = new DerivedClass();

            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);

            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            instance.MyEvent -= new EventDelegate(Handler2);
            instance.InvokeEvent();

            Console.ReadKey();

        }
    }
}
