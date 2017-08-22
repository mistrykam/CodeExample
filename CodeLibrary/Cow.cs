using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public enum CowState
    {
        Sleeping = 0,
        Walking = 1,
        Eating = 2,
        Tipped = 3,
    }

    public class CowTippedEventArgs : EventArgs
    {
        public CowState State { get; private set; }

        public CowTippedEventArgs(CowState state)
        {
            State = state;
        }
    }

    public class Cow
    {
        public event EventHandler<CowTippedEventArgs> Moo;

        private enum subscribeTypes
        {
            StartWalking,
            Walking,
            EndWalking,
            StartingMooing,
            Mooing,
            EndMooing
        }

        private Dictionary<subscribeTypes, EventHandler> subscribers = new Dictionary<subscribeTypes, EventHandler>();

        public event EventHandler StartWalking
        {
            add { AddEvent(subscribeTypes.StartWalking, value); }
            remove { RemoveEvent(subscribeTypes.StartWalking, value);}
        }

        public event EventHandler Walking
        {
            add { AddEvent(subscribeTypes.Walking, value);}
            remove {RemoveEvent(subscribeTypes.Walking, value); }
        }

        public event EventHandler EndWalking
        {
            add { AddEvent(subscribeTypes.Walking, value); }
            remove { RemoveEvent(subscribeTypes.Walking, value); }
        }

        public event EventHandler StartingMooing
        {
            add { AddEvent(subscribeTypes.StartingMooing, value); }
            remove { RemoveEvent(subscribeTypes.StartingMooing, value); }
        }

        public event EventHandler Mooing
        {
            add { AddEvent(subscribeTypes.Mooing, value); }
            remove { RemoveEvent(subscribeTypes.Mooing, value); }
        }

        public event EventHandler EndMooing
        {
            add { AddEvent(subscribeTypes.EndMooing, value);}
            remove {RemoveEvent(subscribeTypes.EndMooing, value); }
        }

        /// <summary>
        /// Add the event
        /// </summary>
        /// <param name="subscribetype"></param>
        /// <param name="value"></param>
        private void AddEvent(subscribeTypes subscribetype, EventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException("When AddEvent() was called EventHandler was null");

            if (subscribers.ContainsKey(subscribetype))
                subscribers[subscribetype] += value;
            else
                subscribers.Add(subscribetype, value);
        }

        /// <summary>
        /// Remove the event
        /// </summary>
        /// <param name="subscribetype"></param>
        /// <param name="value"></param>
        private void RemoveEvent(subscribeTypes subscribetype, EventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException("When RemoveEvent() was called EventHandler was null");


            if (!subscribers.ContainsKey(subscribetype))
                return;
            else
            {
                subscribers[subscribetype] -= value;

                if (!subscribers.ContainsKey(subscribetype))
                    subscribers.Remove(subscribetype);
            }
        }

        public string Name { get; set; }

        public CowState State { get; set; }

        public Cow()
        {
            int index = new Random().Next(0, 3);

            this.State = (CowState)index;
        }

        public void TippedOver()
        {
            if (Moo != null)
                Moo(this, new CowTippedEventArgs(CowState.Tipped));
        }
    }

    public static class RunCowSim
    {
        public static void Giggle(object sender, CowTippedEventArgs args)
        {
            Cow cow = sender as Cow;

            Console.WriteLine("The cow was {0}", cow.State);
            Console.WriteLine("And now the cow was {0}", args.State);
            cow.State = args.State;

            Console.WriteLine("Giggle...{0} has been tipped", cow.Name);
        }

        public static void CreateCows()
        {
            Cow cow1 = new Cow() { Name = "Martha" };
            cow1.Moo += Giggle;

            Cow cow2 = new Cow() { Name = "George" };
            cow2.Moo += Giggle;

            Cow victim = new Random().Next() % 2 == 0 ? cow1 : cow2;

            victim.TippedOver();
        }
    }
}
