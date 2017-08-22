using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public class Client
    {
        public static void Process()
        {
            Publisher publisher = new Publisher();

            SubscriberAAA subscriberAAA = new SubscriberAAA();
            SubscriberBBB subscriberBBB = new SubscriberBBB();
            SubscriberCCC subscriberCCC = new SubscriberCCC();
            SubscriberDDD subscriberDDD = new SubscriberDDD();

            publisher.SubcriberHandler += subscriberAAA.OnSubcriberHandler;
            publisher.SubcriberHandler += subscriberBBB.OnSubcriberHandler;
            publisher.SubcriberHandler += subscriberCCC.OnSubcriberHandler;
            publisher.SubcriberHandler += subscriberDDD.OnSubcriberHandler;

            Console.WriteLine("Client:: Call Publisher.Process()...");

            CreditApplication myCreditApplication = new CreditApplication() { CreditId = 1, FirstName = "John", LastName = "Rimes", CreditScore = 1002 };

            publisher.Process(myCreditApplication);

            Console.WriteLine("Client:: Call Publisher.Process() done.");
        }
    }
}
