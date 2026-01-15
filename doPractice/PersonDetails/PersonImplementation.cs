using System;
using System.Collections;
namespace PersonDetails
{
    public class PersonImplementation
    {
        public void GetName(IList<Person> person)
        {
            foreach(var p in person)
            {
                Console.Write(p.Name + " " + p.Address + " ");
            }
            Console.WriteLine();
        }

        public double Average(IList<Person> person)
        {
            double sum = 0;
            foreach(var p in person)
            {
                sum += p.age;
            }
            return sum / person.Count;
        }

        public int Max(IList<Person> person)
        {
            int max = person[0].age;

            foreach(var p in person)
            {
                if(p.age > max)
                {
                    max = p.age;
                }
            }
            return max;
        }
    }
}