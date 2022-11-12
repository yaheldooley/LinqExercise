using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            int sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers is {sum}\n");

            //TODO: Print the Average of numbers
            double average = numbers.Average();
			Console.WriteLine($"The average of numbers is {average}\n");

			//TODO: Order numbers in ascending order and print to the console
			Console.WriteLine("Numbers in ascending order: ");
			var ascendingNums = numbers.OrderBy(num => num);
            foreach(int num in ascendingNums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

			//TODO: Order numbers in decsending order and print to the console
			Console.WriteLine("Numbers in descending order: ");
			var descendingNums = numbers.OrderBy(num => num).OrderByDescending(num => num);
			foreach (int num in descendingNums)
			{
				
				Console.Write(num + " ");
			}
			Console.WriteLine("\n");

			//TODO: Print to the console only the numbers greater than 6
			Console.WriteLine("Numbers greater than 6: ");
			var numsGreaterThan6 = numbers.Where(num => num > 6);
            foreach (int num in numsGreaterThan6) Console.Write(num + " ");
			Console.WriteLine("\n");

			//TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
			Console.WriteLine("First four of numbers only:\n");
			var anyOrderNums = numbers.OrderBy(num => num);
            int index = 0;
            foreach(int num in anyOrderNums)
            {
                Console.Write($"{num} ");
                index++;
                if (index == 4) break;
            }
			Console.WriteLine("\n");

			//TODO: Change the value at index 4 to your age, then print the numbers in decsending order
			Console.WriteLine("New numbers with my age replacing index of 4 in descending order:\n");
			numbers[4] = 38;
            var newDescending = numbers.OrderBy(x => x).OrderByDescending(x => x);
			foreach (int num in newDescending) Console.Write(num + " ");
			Console.WriteLine("\n");

			// List of employees ****Do not remove this****
			var employees = CreateEmployees();

			//TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
			Console.WriteLine("Employees with names starting with C or S in ascending order:\n");
			var cAndSEmployees = employees.Where(e => e.FirstName.ToLower().StartsWith('c') || e.FirstName.ToLower().StartsWith('s'));
            cAndSEmployees.OrderBy(first => first);
			Console.WriteLine("\n");
			foreach (Employee e in cAndSEmployees) Console.WriteLine(e.FullName);

			//TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
			Console.WriteLine("Employees older than 26:\n");
            var over26 = employees.Where(e => e.Age > 26);
            var orderedOver26 = over26.OrderBy(e => e.Age).ThenBy(e => e.FirstName);
			foreach (Employee e in orderedOver26) Console.WriteLine($"{e.Age} : {e.FullName}");
			Console.WriteLine("\n");

			//TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
			Console.WriteLine("Sum of employees experience if their YOE is less than or equal to 10 AND Age is greater than 35:\n");
			int sumOfExperience = orderedOver26.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).Sum(e => e.YearsOfExperience);
			Console.WriteLine(sumOfExperience);
			Console.WriteLine("\n");

			Console.WriteLine("Average of employees experience if their YOE is less than or equal to 10 AND Age is greater than 35:\n");
			double averageExp = orderedOver26.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).Average(e => e.YearsOfExperience);
			Console.WriteLine(average);
			Console.WriteLine("\n");

			//TODO: Add an employee to the end of the list without using employees.Add()
			employees.Capacity = employees.Capacity + 1;
            employees[employees.Count - 1] = new Employee();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
