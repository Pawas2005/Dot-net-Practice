using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConArchDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentDAL dal = new StudentDAL();
            List<Student> tempList = dal.ShowAllStudents();

            foreach (var item in tempList)
            {
                Console.WriteLine($"{item.RollNo}, {item.Name}");
            }
        }
    }
}
