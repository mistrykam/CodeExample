using System;
using System.Threading;

namespace CodeLibrary
{
    // Custom EventArgs 
    public class PublisherEventArgs : EventArgs
    {
        public CreditApplication MyCreditApplications { get; set; }
    }

    public class Publisher
    {
        // NOTE: You can avoid defining the delegate by using the 'EventHandler' or 'EventHandler<T>'
        //       EventHanlder will create a delegate at compile time

        // [1] Publisher of the event
        // - this class will added subscribers 
        // - this class will raise the events and the subscriber will be called-back 
        //
        // [2] Subscriber of the event
        // - define the method that should be called back (Publisher defines that method using a delegate)
        // - registered the call-back method with the publisher

        // In the Publisher:
        // - define the delegate signature (call-back method) - which is called when the event is raised
        // - definition of the event where the subscriber can register
        // - raising the event so the subscriber is notified

        // what the call-back function should look like
        // public delegate void SubscriberEventHandler(object source, EventArgs args);
        public delegate void SubscriberEventHandler(object source, PublisherEventArgs args);

        // where the call-back will be registerd
        public event SubscriberEventHandler SubcriberHandler;

        // See note above - this means the delegate definition can be deleted
        public EventHandler SubcriberHandling1;
        public EventHandler<PublisherEventArgs> SubcriberHandling2;

    
        // notify the subscribers that the event has been raised (which will call-back to the subscriber)
        protected virtual void OnEventCompleted(CreditApplication creditApplication)
        {
            if (SubcriberHandler != null)
            {
                Console.WriteLine("Publisher::OnEventCompleted()");

                SubcriberHandler(this, new PublisherEventArgs() { MyCreditApplications = creditApplication });
            }
        }

        public void Process(CreditApplication creditApplication)
        {
            Console.WriteLine("Publisher:: Process()...");
            Thread.Sleep(5000);

            Console.WriteLine("Publisher:: Process() done.");

            OnEventCompleted(creditApplication);
        }
    }
}
