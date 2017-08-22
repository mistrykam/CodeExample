using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public class Dog
    {
        private static int counter = 0;

        int DogId;

        public Dog()
        {            
            DogId = ++counter;
        }

        public void Speak()
        {
            Console.WriteLine("Dog number {0} is barking at Kevel...woof", DogId);
        }
    }

    public class PetStore
    {
        public static void TestDoggy()
        {
            Dog dog1 = new Dog();
            dog1.Speak();

            Dog dog2 = new Dog();
            dog2.Speak();

            Dog dog3 = new Dog();
            dog3.Speak();

            Dog dog4 = new Dog();
            dog4.Speak();

            Dog dog5 = new Dog();
            dog5.Speak();

            Dog dog6 = new Dog();
            dog6.Speak();
        }
    }

}
