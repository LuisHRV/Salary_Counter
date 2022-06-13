using Salary.Calculate.Entities.Enums;
using System.Collections.Generic;

namespace Salary.Calculate.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<Contract> HourContract { get; set; } = new List<Contract>();

        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(Contract hourContract)
        {
            HourContract.Add(hourContract);
        }

        public void RemoveContract ( Contract hourContract)
        {
            HourContract.Remove(hourContract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach(Contract hourContract in HourContract)
            {
                if (hourContract.Date.Year ==  year && hourContract.Date.Month == month)
                {
                    sum += hourContract.TotalValue();
                }
            }
            return sum;
        }
    }
}
