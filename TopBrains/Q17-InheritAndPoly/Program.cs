using System;
using System.Globalization;

namespace InheritAndPoly
{
    public class Program
    {
        // ---------- BASE CLASS ----------
        public abstract class Employee
        {
            public abstract decimal GetPay();
        }

        // ---------- HOURLY ----------
        public class HourlyEmployee : Employee
        {
            private decimal rate;
            private decimal hours;

            public HourlyEmployee(decimal rate, decimal Hour)
            {
                this.rate = rate;
                this.hours = Hour;
            }

            public override decimal GetPay()
            {
                return rate * hours;
            }
        }

        // ---------- SALARIED ----------
        public class SalariedEmployee : Employee
        {
            private decimal monthlySalary;

            public SalariedEmployee(decimal monthlySalary)
            {
                this.monthlySalary = monthlySalary;
            }

            public override decimal GetPay()
            {
                return monthlySalary;
            }
        }

        // ---------- COMMISSION ----------
        public class CommissionEmployee : Employee
        {
            private decimal baseSalary;
            private decimal commission;

            public CommissionEmployee(decimal baseSalary, decimal commission)
            {
                this.baseSalary = baseSalary;
                this.commission = commission;
            }

            public override decimal GetPay()
            {
                return baseSalary + commission;
            }
        }

        // ---------- REQUIRED METHOD ----------
        public static decimal ComputeTotalPayroll(string[] employees)
        {
            decimal total = 0;

            foreach(string emp in employees)
            {
                string[] parts = emp.Split(' ');

                Employee employee = null;

                if(parts[0] == "H")
                {
                    decimal rate = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
                    decimal hours = decimal.Parse(parts[2], CultureInfo.InvariantCulture);
                    employee = new HourlyEmployee(rate, hours);
                }
                else if(parts[0] == "S")
                {
                    decimal salary  = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
                    employee = new SalariedEmployee(salary);
                }
                else if(parts[0] == "C")
                {
                    decimal commission = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
                    decimal baseSalary = decimal.Parse(parts[2], CultureInfo.InvariantCulture);
                    employee = new CommissionEmployee(baseSalary, commission);
                }
                if(employee != null)
                {
                    total += employee.GetPay();    //Polymorphism
                }
            }

            return Math.Round(total, 2, MidpointRounding.AwayFromZero);
        }

        public static void Main()
        {
            string[] employees =
            {
                "H 100 5",
                "S 20000",
                "C 3000 15000"
            };

            decimal totalPay = ComputeTotalPayroll(employees);
            Console.WriteLine(totalPay);
        }
    }
}