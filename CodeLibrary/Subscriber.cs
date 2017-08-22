using System;
using System.Threading;

namespace CodeLibrary
{
    public class SubscriberAAA
    {
        public void OnSubcriberHandler(object source, PublisherEventArgs args)
        {
            Console.WriteLine("Subscriber AAA:: OnSubcriberHandler()... {0} {1}", args.MyCreditApplications.FirstName, args.MyCreditApplications.LastName);
            Thread.Sleep(2000);
            Console.WriteLine("Subscriber AAA:: OnSubcriberHandler Done.");
        }
    }

    public class SubscriberBBB
    {
        public void OnSubcriberHandler(object source, PublisherEventArgs args)
        {
            Console.WriteLine("Subscriber BBB:: OnSubcriberHandler()... {0} {1}", args.MyCreditApplications.FirstName, args.MyCreditApplications.LastName);

            Thread.Sleep(2000);
            Console.WriteLine("Subscriber BBB:: OnSubcriberHandler Done.");
        }
    }

    public class SubscriberCCC
    {
        public void OnSubcriberHandler(object source, PublisherEventArgs args)
        {
            Console.WriteLine("Subscriber CCC:: OnSubcriberHandler()... {0} {1}", args.MyCreditApplications.FirstName, args.MyCreditApplications.LastName);        
            Thread.Sleep(2000);
            Console.WriteLine("Subscriber CCC:: OnSubcriberHandler Done.");
        }
    }

    public class SubscriberDDD
    {
        public void OnSubcriberHandler(object source, PublisherEventArgs args)
        {
            Console.WriteLine("Subscriber DDD:: OnSubcriberHandler()... {0} {1}", args.MyCreditApplications.FirstName, args.MyCreditApplications.LastName);
            Thread.Sleep(2000);
            Console.WriteLine("Subscriber DDD:: OnSubcriberHandler Done.");
        }
    }

}
