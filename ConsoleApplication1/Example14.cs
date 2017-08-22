using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct CountingItem
{
    static int counter = 0;
    int id;
    char letter;

    public CountingItem(int? item)
    {
        letter = (char)((int)'a' + counter);
        counter++;
        id = counter;
    }
}

public class Rodent
{
    static int id;

    static Rodent()
    {
        id = new Random().Next(1, 100);
        Console.WriteLine("Rodent:static constructor called: initialize id {0}", id);
        throw new ApplicationException("Busted code!");
    }

    public Rodent()
    {
        id++;
        Console.WriteLine("Rodent:instance constructor called: id {0}", id);
    }
}

public class Example14
{
    public static void ExampleCode1()
    {
        CountingItem c1 = new CountingItem(null);
        CountingItem c2 = new CountingItem(null);
        CountingItem c3 = new CountingItem(null);
        CountingItem c4 = new CountingItem(null);

        new Rodent();
        new Rodent();
        new Rodent();
        new Rodent();
        new Rodent();
    }
}
