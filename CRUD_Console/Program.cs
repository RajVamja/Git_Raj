using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
namespace CRUD_Console
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }

    public class empDetails
    {
        public int Id { get; set; }
        public float Salary { get; set; }
        public string HomeTown { get; set; }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        // For LINQ task
        static List<empDetails> employeesdets = new List<empDetails>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    "\n Press 1 to Add Employee" +
                    "\n Press 2 to View Employee" +
                    "\n Press 3 to Update Employee" +
                    "\n Press 4 to Delete Employee" +
                    "\n Press 5 to Add Employee Details" +
                    "\n Press 6 to View Employee's all Details");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateEmployee();
                        break;
                    case 2:
                        ReadEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        CreateEmployeeDet();
                        break;
                    case 6:
                        ReadEmployeeDet();
                        break;
                    default:
                        Console.WriteLine("\nPlease select correct choise!");
                        break;
                }
            }
        }


        // Create Employee Details
        static void CreateEmployeeDet()
        {

            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee empdet = employees.FirstOrDefault(e => e.Id == id);

            if (empdet != null)
            {

                Console.WriteLine("Enter Employee Salary:");
                int salary = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Employee Hometown:");
                string hometown = Console.ReadLine();


                empDetails empdetObj = new empDetails();
                empdetObj.Id = id;
                empdetObj.Salary = salary;
                empdetObj.HomeTown = hometown;
                employeesdets.Add(empdetObj);

                //employeesdets.Add(new empDetails { Id = id, Salary = salary, HomeTown = hometown });

                Console.WriteLine("\nEmployee Details Added Successfully!");
            }

            else
            {
                Console.WriteLine("\nFirst You should register Employee Id " + id + " then and then you can able to add their details!");
            }
        }


       // For execution of Join
        static void ReadEmployeeDet()
        {
            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            var result = employees.Join(employeesdets, e => e.Id, ed => ed.Id, (e, ed) => new { e.Id, e.Name, e.Department, ed.Salary, e.Age, ed.HomeTown })
                     .Where(e => e.Id == id)
                     .ToList();

            if (result.Any())
            {
                Console.WriteLine("\nEmployee and their details are: ");
                foreach (var val in result)
                {
                    //Console.WriteLine("\nID: " + val.Id + "\nName: " + val.Name + "\nDepartment:" + val.Department + "\nSalary: " + val.Salary + "\nAge: " + val.Age + "\nHometown: " + val.HomeTown);
                    ConsoleTable.From(result).Write();
                }
            }
            else
            {
                Console.WriteLine("\nEmployee Id " + id + " not found!");
            }
        }

        // Create Employee
        static void CreateEmployee()
        {
            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Employee Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Department:");
            string dept = Console.ReadLine();
            Employee emp1 = new Employee();
            emp1.Id = id;
            emp1.Name = name;
            emp1.Age = age;
            emp1.Department = dept;
            employees.Add(emp1);
            //employees.Add(new Employee { Id = id, Name = name, Age = age, Department = dept });

            Console.WriteLine("\nEmployee Added Successfully!");
        }


        // Display Employee
        static void ReadEmployee()
        {
            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                //Console.WriteLine("\nID: " + emp.Id + "\nName: " + emp.Name + "\nAge: " + emp.Age + "\nDepartment: " + emp.Department);
                Console.WriteLine();
                ConsoleTable.From<Employee>(employees).Write();
            }
            else
            {
                Console.WriteLine("\nEmployee Id " + id + " not found!");
            }
        }


        // Update Empoyee
        static void UpdateEmployee()
        {
            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine("Which property do you want to update? (name/age/department/press 'A' if you want all data)");
                string property = Console.ReadLine();

                switch (property)
                {
                    case "name":
                        Console.WriteLine("Enter Employee Name:");
                        emp.Name = Console.ReadLine();
                        break;

                    case "age":
                        Console.WriteLine("Enter Employee Age:");
                        emp.Age = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "department":
                        Console.WriteLine("Enter Employee Department:");
                        emp.Department = Console.ReadLine();
                        break;

                    case "A":
                        Console.WriteLine("Enter Employee Name:");
                        emp.Name = Console.ReadLine();

                        Console.WriteLine("Enter Employee Age:");
                        emp.Age = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Employee Department:");
                        emp.Department = Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Invalid property name!");
                        return;
                }

                Console.WriteLine("\nEmployee Updated Successfully!");
                //Console.WriteLine("\nID: " + emp.Id + "\nName: " + emp.Name + "\nAge: " + emp.Age + "\nDepartment: " + emp.Department);
                Console.WriteLine();
                ConsoleTable.From<Employee>(employees).Write();
            }
            else
            {
                Console.WriteLine("\nEmployee Id " + id + " not found!");
            }
        }



        // Delete Employee
        static void DeleteEmployee()
        {
            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("\nEmployee Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee Id " + id + " not found!");
            }
        }

    }

}