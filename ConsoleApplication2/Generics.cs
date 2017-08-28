using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class Generics
    {
        /* Generics
         
           Generics allow you to define type-safe data structures, without committing to actual data types.

           To do that, use the < and > brackets, enclosing a generic type parameter.            

           Constraints on Type Parameters:

            class MyGenericType<T> : where T:

            where T: struct	 - The type argument must be a value type. Any value type except Nullable can be specified. See Using Nullable Types for more information.
            where T : class	 - The type argument must be a reference type; this applies also to any class, interface, delegate, or array type.
            where T : new()	 - The type argument must have a public parameterless constructor. When used together with other constraints, the new() constraint must be specified last.
            where T : <base class name>	 - The type argument must be or derive from the specified base class.
            where T : <interface name>	 - The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.
            where T : U	     - The type argument supplied for T must be or derive from the argument supplied for U.

            Example: 
                class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
                {
                    // ...
                }

            Generic Classes:
                class EmployeeList<T> {}

            Generic Interfaces:
                interface IPerson<T> {}

            Generic Methods:
                int computer<T>(T param1, T param2)
                T calculate<T>(T param1, T param2, T param3)

            Generic Delegates:
                public delegate void Del<T>(T item);

            default Keyword:
                In generic classes and methods, one issue that arises is how to assign a default value to a parameterized type T 
                when you do not know the following in advance:

                    - Whether T will be a reference type or a value type.
                    - If T is a value type, whether it will be a numeric value or a struct.

                Given a variable t of a parameterized type T, the statement t = null is only valid if T is a reference type and t = 0 
                will only work for numeric value types but not for structs. The solution is to use the default keyword, 
                which will return null for reference types and zero for numeric value types. For structs, it will return each member 
                of the struct initialized to zero or null depending on whether they are value or reference types. For nullable value 
                types, default returns a System.Nullable<T>, which is initialized like any struct.                

                // The following method returns the data value stored in the last node in
                // the list. If the list is empty, the default value for type T is
                // returned.

                public T GetLast()
                {
                    // The value of temp is returned as the value of the method. 
                    // The following declaration initializes temp to the appropriate 
                    // default value for type T. The default value is returned if the 
                    // list is empty.
                    T temp = default(T);

                    Node current = head;
                    while (current != null)
                    {
                        temp = current.Data;
                        current = current.Next;
                    }
                    return temp;
                }
        */
    }
}
