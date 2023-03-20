using System;
using System.Linq;
using System.Text;
using DbFirstDemo.Data.Models;

namespace DbFirstDemo
{
    static class Program
    {
        static void Main() {
            var context = new SoftUniContext();
            Console.WriteLine(GetEmployeesFromSalesAndMarketing(context));
        }

        private static object AllEmployees(SoftUniContext context) {
            var employees = context.Employees.Select(x => new {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId).ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees) {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetEmployeesWithSalaryOver50000(SoftUniContext context) {
            var employees = context.Employees
                .Select(x => new {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .Where(x => x.Salary > 5000).ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees) {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) {
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

            var sb = new StringBuilder();
            foreach (var e in employees) {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        private static int EmployeesCount(SoftUniContext context) {
            return context.Employees.ToArray().Length;
        }

        private static string GetEmployeesWithFirstNameStartWithN(SoftUniContext context) {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith('N'))
                .Select(x => new {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderByDescending(x => x.Salary)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees) {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.Salary}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetFirstTenEmployeesWithDepartment(SoftUniContext context) {
            var employees = context.Employees
                .Select(x => new {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    DepartmentName = x.Department.Name
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees) {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.DepartmentName}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetEmployeesFromSalesAndMarketing(SoftUniContext context) {
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

            var sb = new StringBuilder();
            foreach (var e in employees) {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetEmployeesWorkingOnClassicVest(SoftUniContext context) {
            var employees = context.Projects
                .Where(x => x.ProjectId == 1)
                .Select(x=> new {
                })
        }
    }
}