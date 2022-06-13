using Salary.Calculate.Entities;
using Salary.Calculate.Entities.Enums;
using System;
using System.Globalization;

namespace Salary.Calculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName= Console.ReadLine();
            Console.WriteLine("Enter Worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var a = 1 + i;
                Console.Write($"Enter #{a} contract data: ");
                Console.Write("Date (DD/MM/YYYY)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per houor: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration (Hours): ");
                int h = int.Parse(Console.ReadLine());
                Contract hourContract = new Contract(date, value, h);
                worker.AddContract(hourContract);
            }
            Console.WriteLine();
            Console.Write("Enter the month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0,2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine();
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Departament.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month)}");
        }
    }
}
