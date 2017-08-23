using System;

namespace ConsoleApplication2
{
    class ClassBaseNewThisOperators
    {
        /*
            This section introduces the following access keywords:

            base - Accesses the members of the base class or call the contrustor

            new - modifier Hides an inherited member. 

            A base class access is permitted only in a constructor, an instance method, or an instance property accessor.
            It is an error to use the base keyword from within a static method. The base class that is accessed is the base class 
            specified in the class declaration. For example, if you specify class ClassB : ClassA , the members of ClassA are accessed 
            from ClassB, regardless of the base class of ClassA.         

            this - Refers to the current instance of the class.         

         */

        /* base
         
            - Specify which base-class constructor should be called when creating instances of the derived class.

            - Call a method on the base class that has been overridden by another method.
         */

        class Person
        {
            protected string FirstName;
            protected string LastName;
            protected string SSN;

            internal Person(string firstName, string lastName, string ssn)
            {
                Console.WriteLine("Creating person(fn,ln,ssn)...");

                FirstName = firstName;
                LastName = lastName;
                SSN = ssn;
            }

            protected void DisplayPersonInfo()
            {
                Console.WriteLine("First Name: {0}", FirstName);
                Console.WriteLine("Last Name: {0}", LastName);
                Console.WriteLine("SSN: {0}", SSN);
            }
        }

        class Employee : Person
        {
            string EmployeeNumber;

            internal Employee() : base("John", "Smith", "1234")
            {
                Console.WriteLine("Creating employee()...");

                EmployeeNumber = "110111001";
            }

            internal Employee(string firstName, string lastName, string ssn, string employeeNumber) : base(firstName,lastName, ssn)
            {
                Console.WriteLine("Creating employee(fn,ln,ss,en)...");

                EmployeeNumber = employeeNumber;
            }

            internal void DisplayEmployeeInfo()
            {
                base.DisplayPersonInfo();
                Console.WriteLine("Employee Number: {0}", EmployeeNumber);
            }
        }

        public static void CannotEmptyConstructor()
        {
            // Person person = new Person();  <-- NOT Possible!

            /*
             Since Person class has a defined Constructor, it must be called.

             Error	CS7036	There is no argument given that corresponds to the required formal parameter 'firstName' of 
             'ClassAccessKeywords.Person.Person(string, string, string)'	
            */
        }

        public static void BaseExample()
        {
            Employee employee1 = new Employee();

            employee1.DisplayEmployeeInfo();

            Console.WriteLine();

            Employee employee2 = new Employee("Julie", "Hinton", "901923", "110100101");

            employee2.DisplayEmployeeInfo();
        }

        /*
           new
            When used as a declaration modifier, the new keyword explicitly hides a member that is inherited from a base
            class. When you hide an inherited member, the derived version of the member replaces the base class version.
         */

        internal class BaseObject
        {
            internal int variable = 1;

            internal void Speak()
            {
                Console.WriteLine("This is the base class, variable = {0}", variable);
            }
        }

        internal class DervivedObject : BaseObject
        {
            new internal int variable = 1000;

            new internal void Speak()
            {
                Console.WriteLine("This is the dervived class, variable = {0}", variable);
            }
        }

        public static void NewHidingExample()
        {
            BaseObject baseObject = new BaseObject();

            baseObject.Speak();

            DervivedObject dervivideObject = new DervivedObject();

            dervivideObject.Speak();
        }

        /* this
           The this keyword refers to the current instance of the class and is also used as a modifier of the 
           first parameter of an extension method.           
         */

        internal class House
        {
            string address;
            string city;
            string country;
            int taxes;

            internal House(string address, string city, string country)
            {
                this.address = address;
                this.city = city;
                this.country = country;

                CalculateTaxes calTaxes = new CalculateTaxes();
                this.taxes = calTaxes.GetTaxes(this);
            }

            internal void DisplayDetails()
            {
                Console.WriteLine("Address: {0}", address);
                Console.WriteLine("City: {0}", city);
                Console.WriteLine("Country: {0}", country);
                Console.WriteLine("Taxes: {0}", taxes);
            }

            // indexer example of _this_

            int[] array = new int[100];

            public int this[int param]
            {
                get { return array[param]; }
                set { array[param] = value; }
            }
        }

        internal class CalculateTaxes
        {
            internal int GetTaxes(House house)
            {
                return (new Random()).Next(1000, 100000);
            }
        }

        public static void ThisExample()
        {
            House house = new House("20 Majestic Drive", "Markham", "Canada");

            house.DisplayDetails();
        }

        /* Indexer */

        public static void IndexerExample()
        {
            House house = new House("20 Majestic Drive", "Markham", "Canada");
            
            // indexer
            house[0] = 1000;
            house[1] = 2000;
            house[2] = 3000;

            Console.WriteLine("house[0]: {0}", house[0]);
            Console.WriteLine("house[1]: {0}", house[1]);
            Console.WriteLine("house[2]: {0}", house[2]);
        }
    }
}
