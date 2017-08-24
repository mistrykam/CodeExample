using System;

namespace ConsoleApplication2
{
    class ClassEvent
    {
        /* Events
           The event keyword is used to declare an event in a publisher class.
           
           Events are a special kind of multicast delegate that can only be invoked from within the class or struct where they
           are declared (the publisher class). If other classes or structs subscribe to the event, their event handler methods
           will be called when the publisher class raises the event. For more information and code examples, see Events and
           Delegates.

           Events can be marked as public, private, protected, internal, or protected internal             
         */

        class Publisher
        {
            public delegate void MyEventHandler(object sender, EventArgs e);    // function pointer defintion

            public event MyEventHandler SampleEventHandled;  // or we could use the built-in type "EventHandler"
                  /*---- type -----*/        

            public void InvokeEvent()
            {
                if (SampleEventHandled != null)
                    SampleEventHandled(this, new EventArgs());
            }
        }

        class Subscriber
        {
            readonly string myName;

            public Subscriber(string name)
            {
                myName = name;
            }

            public void Handler(object send, EventArgs e)
            {
                Console.WriteLine("The {0} Subscriber.Handler was called", myName);
            }
        }

        public static void EventExample()
        {
            Publisher publisher = new Publisher();

            Subscriber[] listOfSubscribers = new Subscriber[5];

            for (int i = 0; i < listOfSubscribers.Length; i++)
            {
                listOfSubscribers[0] = new Subscriber(string.Format("Subscriber-{0}", i));
                publisher.SampleEventHandled += listOfSubscribers[0].Handler;
            }

            publisher.InvokeEvent();
        }
    }
}
