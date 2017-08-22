using System;

namespace CodeLibrary
{
    public class TrainSignal
    {
        // using a delegate (define the type and then a variable to hold it)
        public delegate void CallBackSignature();         // type
        public CallBackSignature OnTrainSignal1 = null;   // instance of the type
  
        // using an action type (short-cut to create a delegate and variable to hold it)
        public Action OnTrainSignal2;  // Action is built type, instance of this type

        // using the event signature
        public event CallBackSignature OnTrainSignal3;  // creating an event, however you need to define the 'delegate type'
                                                        // could also be written as public event Action OnTrainSignal3; 

        public event EventHandler OnTrainSignal4; // no type required

        public void TrainIsComing()
        {
            Console.WriteLine("The train is coming, signal the subscribed cars::");

            Console.WriteLine("OnTrainSignal1()");
            if (OnTrainSignal1 !=null)
                OnTrainSignal1();  // this is a function pointer, it can be null 
                                   // OnTrainSignal2.Invoke();

            Console.WriteLine("OnTrainSignal2()");
            if (OnTrainSignal2 != null)
                OnTrainSignal2();  // this is a function pointer, it can be null
                                   // OnTrainSignal2.Invoke();

            Console.WriteLine("OnTrainSignal3()");
            if (OnTrainSignal3 != null)
                OnTrainSignal3(); // this is a function pointer, it can be null 
                                  // OnTrainSignal3.Invoke();

            Console.WriteLine("OnTrainSignal4()");
            if (OnTrainSignal4 != null)
                OnTrainSignal4(this, null); // this is a function pointer, it can be null 
        }
    }

    public class Car
    {
        private void StopTheCar()
        {
            Console.WriteLine("Car is stopping!!! CarId={0}", this.GetHashCode());
        }

        private void StopTheCarArgs(object x, EventArgs args)
        {
            StopTheCar();
        }

        public Car(TrainSignal trainsignal)
        {
            trainsignal.OnTrainSignal1 += StopTheCar;
            trainsignal.OnTrainSignal2 += StopTheCar;
            trainsignal.OnTrainSignal3 += StopTheCar;
            trainsignal.OnTrainSignal4 += StopTheCarArgs;
        }
    }

    public static class RunTheTrains
    {
        public static void StartIt()
        {
            TrainSignal ts = new TrainSignal();

            Car car1 = new Car(ts);            
            Car car2 = new Car(ts);            
            Car car3 = new Car(ts);            
            Car car4 = new Car(ts);

            ts.TrainIsComing();

            Console.WriteLine("Set the delegate to NULL.");

            ts.OnTrainSignal1 = null;
            ts.OnTrainSignal2 = null;
            // ts.OnTrainSignal3 = null; // this is not possible on an event
            // ts.OnTrainSignal4 = null;  // this bad
            
            ts.TrainIsComing();
            
        //    ts.OnTrainSignal1();  -- Crash
        //    ts.OnTrainSignal2();  -- Crash
            // ts.OnTrainSignal3(); // can't call the event handler directly
            // ts.OnTrainSignal4(); // can't call the event handler directly                        
        }
    }

}
