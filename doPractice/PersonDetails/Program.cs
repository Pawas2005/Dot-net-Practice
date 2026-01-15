using System;

namespace PersonDetails
{
    public class Program
    {
        public static void Main()
        {
            IList<Person> p = new List<Person>();

            p.Add(new Person {Name = "Aarya", Address = "A2101", age = 69});
            p.Add(new Person {Name = "Daniel", Address = "D104", age = 40});
            p.Add(new Person {Name = "Ira", Address = "H801", age = 25});
            p.Add(new Person {Name = "Jennifer", Address = "I1704", age = 33});

            PersonImplementation personImplementation = new PersonImplementation();

            //1. 
            personImplementation.GetName(p);

            //2.
            Console.WriteLine(personImplementation.Average(p));

            //3.
            Console.WriteLine(personImplementation.Max(p));
        }
    }
}