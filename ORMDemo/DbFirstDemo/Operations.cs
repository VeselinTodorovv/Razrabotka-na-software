using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbFirstDemo.Data.Models;

namespace DbFirstDemo {
    internal static class Operations {
        private static string GetFormattedItems<T>(Func<T, string> formatFunc, IEnumerable<T> items) {
            var sb = new StringBuilder();
            foreach (T employee in items) {
                sb.AppendLine(formatFunc(employee));
            }

            return sb.ToString().TrimEnd();
        }
        
        public static object AllEmployees(SoftUniContext context) {
            var employees = context.Employees.Select(x => new {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();
            
            return GetFormattedItems(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}",
                employees);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) {
            var employees = context.Employees
                .Select(x => new {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 5000)
                .OrderBy(x => x.FirstName)
                .ToList();

            return GetFormattedItems(e => $"{e.FirstName} - {e.Salary:f2}",
                employees);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    DepartmentName = x.Department.Name
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            return GetFormattedItems(e => $"{e.FirstName} {e.LastName} {e.DepartmentName} - ${e.Salary:f2}",
                employees);
        }

        public static int EmployeesCount(SoftUniContext context) {
            return context.Employees.Count();
        }

        public static string GetEmployeesWithFirstNameStartWithN(SoftUniContext context) {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("N"))
                .Select(x => new {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderByDescending(x => x.Salary)
                .ToList();

            return GetFormattedItems(e => $"{e.FirstName} {e.LastName} {e.Salary}",
                employees);
        }

        public static string GetFirstTenEmployeesWithDepartment(SoftUniContext context) {
            var employees = context.Employees
                .Select(x => new {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    DepartmentName = x.Department.Name
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Take(10) //first 10 rows
                .ToList();

            return GetFormattedItems(e => $"{e.FirstName} {e.LastName} {e.DepartmentName}",
                employees);
        }

        public static string GetEmployeesFromSalesAndMarketing(SoftUniContext context) {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Sales" || x.Department.Name == "Marketing")
                .Select(x => new {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    DepartmentName = x.Department.Name
                })
                .OrderBy(x => x.DepartmentName)
                .ThenByDescending(x => x.Salary)
                .ToList();

            return GetFormattedItems(e => $"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary}",
                employees);
        }

        public static string GetEmployeesWorkingOnClassicVest(SoftUniContext context) {
            var employees = context.EmployeesProjects
                .Where(x => x.ProjectId == 1)
                .Select(x => new {
                    x.Employee.FirstName,
                    x.Employee.LastName,
                    x.Project.Name
                })
                .OrderBy(x => x.FirstName)
                .ToList();
            
            return GetFormattedItems(e => $"{e.FirstName} {e.LastName} {e.Name}",
                employees);
        }

        public static void AddNewProject(SoftUniContext context) {
            Project project = new() {
                Name = "Judge System",
                StartDate = DateTime.Now
            };

            context.Projects.Add(project);
            context.SaveChanges();
        }

        public static void AddTown(SoftUniContext context) {
            Town town = new() {
                Name = "New York"
            };
            context.Towns.Add(town);
            context.SaveChanges();
        }

        public static void AddEmployeeWithProject(SoftUniContext context) {
            Employee employee = new() {
                FirstName = "Ani",
                LastName = "Ivanova",
                JobTitle = "Designer",
                HireDate = DateTime.Now,
                Salary = 2000,
                DepartmentId = 2
            };
            context.Employees.Add(employee);
            
            employee.EmployeesProjects.Add(new EmployeesProject {
                Project = new Project {
                    Name = "TTT",
                    StartDate = DateTime.UtcNow
                }
            });
            
            context.SaveChanges();
        }

        public static void UpdateEmployee(SoftUniContext context) {
            var employee = context.Employees.FirstOrDefault();
            employee.FirstName = "Alex";
            
            context.SaveChanges();
        }

        public static void UpdateProject(SoftUniContext context) {
            var project = context.Projects.FirstOrDefault(x => x.Name == "TTT");
            project.Name = "Shkolo system";
            project.StartDate = new DateTime(2021, 12, 22);

            context.SaveChanges();
        }

        public static void DeleteEmployeeProject(SoftUniContext context) {
            var employeeProject =
                context.EmployeesProjects.OrderByDescending(x => x.EmployeeId == 14).First();

            context.EmployeesProjects.Remove(employeeProject);
            context.SaveChanges();
        }
        
        public static void DeleteJudgeSystemProject(SoftUniContext context) {
            var projectToRemove = context.Projects.First(x => x.Name == "Judge System");
            
            context.Projects.Remove(projectToRemove);
            context.SaveChanges();
        }
    }
}