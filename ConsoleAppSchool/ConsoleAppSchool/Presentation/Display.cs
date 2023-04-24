using System;
using Business;
using Data.Models;

namespace ConsoleAppSchool.Presentation
{
    public class Display
    {
        public Display() {
            Input();
        }

        private readonly int _closeOperationId = 6;
        private readonly StudentBusiness _productBusiness = new();

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
            Students student = new();
            
            Console.WriteLine("Enter first name: ");
            student.FirstName = Console.ReadLine();
            
            Console.WriteLine("Enter price: ");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Enter town: ");
            student.Town = Console.ReadLine();
            
            Console.WriteLine("Enter birthdate: ");
            student.BirthDate = Convert.ToDateTime(Console.ReadLine());
            
            Console.WriteLine("Enter class: ");
            student.Class = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter uspeh: ");
            student.Uspeh = double.Parse(Console.ReadLine());

            _productBusiness.AddStudent(student);
        }

        private void ListAll() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 16) + "STUDENTS" + new string('-', 16));
            Console.WriteLine(new string('-', 40));

            var products = _productBusiness.GetAllStudents();
            foreach (Students item in products) {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Town} {item.BirthDate} {item.Class} {item.Uspeh}");
            }
        }

        private void Update() {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Students student = _productBusiness.GetStudentId(id);

            if (student != null) {
                Console.WriteLine("Enter first name: ");
                student.FirstName = Console.ReadLine();
            
                Console.WriteLine("Enter price: ");
                student.LastName = Console.ReadLine();

                Console.WriteLine("Enter town: ");
                student.Town = Console.ReadLine();
            
                Console.WriteLine("Enter birthdate: ");
                student.BirthDate = Convert.ToDateTime(Console.ReadLine());
            
                Console.WriteLine("Enter class: ");
                student.Class = int.Parse(Console.ReadLine());
            
                Console.WriteLine("Enter uspeh: ");
                student.Uspeh = double.Parse(Console.ReadLine());
                
                _productBusiness.UpdateStudent(student);
            }
            else {
                Console.WriteLine("Product not found");
            }
        }

        private void Fetch() {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());

            Students product = _productBusiness.GetStudentId(id);
            if (product == null) return;
            
            Console.WriteLine(new string('-', 40));
                
            Console.WriteLine("ID: " + product.Id);
            Console.WriteLine("First Name: " + product.FirstName);
            Console.WriteLine("Last Name: " + product.LastName);
            Console.WriteLine("Town: " + product.Town);
            Console.WriteLine("BirthDate: " + product.BirthDate);
            Console.WriteLine("Class: " + product.Class);
            Console.WriteLine("Uspeh: " + product.Uspeh);
            Console.WriteLine(new string('-', 40));
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            _productBusiness.DeleteStudent(id);

            Console.WriteLine("Done.");
        }
    }
}