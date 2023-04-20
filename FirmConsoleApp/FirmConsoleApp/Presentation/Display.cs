using System;
using Business;
using Data.Models;

namespace FirmConsoleApp.Presentation
{
    public class Display
    {
        public Display() {
            Input();
        }

        private readonly int _closeOperationId = 6;
        private readonly FirmBusiness _firmBusiness = new();

        private void ShowMenu() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input() {
            int operation;

            do {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation) {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                }
                
            } while (operation != _closeOperationId);
        }

        private void Add() {
            Employee employee = new();
            Console.WriteLine("Enter first name: ");
            employee.FirstName = Console.ReadLine();
            
            Console.WriteLine("Enter last name: ");
            employee.LastName = Console.ReadLine();
            
            Console.WriteLine("Enter town: ");
            employee.Town = Console.ReadLine();

            Console.WriteLine("Enter salary: ");
            employee.Salary = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter department name: ");
            employee.DepartmentName = Console.ReadLine();

            _firmBusiness.AddEmployee(employee);
        }

        private void ListAll() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 16) + "EMPLOYEES" + new string('-', 16));
            Console.WriteLine(new string('-', 40));

            var products = _firmBusiness.GetAllEmployees();
            foreach (Employee item in products) {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Town} {item.Salary} {item.DepartmentName}");
            }
        }

        private void Update() {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = _firmBusiness.GetEmployeeById(id);

            if (employee != null) {
                Console.WriteLine("Enter first name: ");
                employee.FirstName = Console.ReadLine();
            
                Console.WriteLine("Enter last name: ");
                employee.LastName = Console.ReadLine();
            
                Console.WriteLine("Enter town: ");
                employee.Town = Console.ReadLine();

                Console.WriteLine("Enter salary: ");
                employee.Salary = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter department name: ");
                employee.DepartmentName = Console.ReadLine();
                
                _firmBusiness.UpdateEmployee(employee);
            }
            else {
                Console.WriteLine("Product not found");
            }
        }

        private void Fetch() {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());

            Employee product = _firmBusiness.GetEmployeeById(id);

            if (product != null) {
                Console.WriteLine(new string('-', 40));
                
                Console.WriteLine("ID: " + product.Id);
                Console.WriteLine("First Name" + product.FirstName);
                Console.WriteLine("Last Name" + product.LastName);
                Console.WriteLine("Town" + product.Town);
                Console.WriteLine("Salary" + product.Salary);
                Console.WriteLine("Department Name" + product.DepartmentName);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            _firmBusiness.DeleteEmployee(id);

            Console.WriteLine("Done.");
        }
    }
}