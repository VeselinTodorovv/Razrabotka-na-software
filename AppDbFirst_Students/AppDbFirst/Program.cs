using AppDbFirst.Models;
using System;
using System.Linq;
using System.Text;

namespace AppDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(GetEmployeesFromNoClosedProjects(context));
        }

        public static string GetEmployeesAfter2001(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.HireDate.Year > 2001 &&
                x.JobTitle == "Production Technician")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.HireDate,
                    x.Salary,
                    x.JobTitle
                })
                .OrderByDescending(x => x.HireDate)
                .Take(7)
                .ToList();

            StringBuilder sb = new();
            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.HireDate} - {item.Salary} - {item.JobTitle}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromClosedProjects(SoftUniContext context)
        {
            var employees = context.Projects
                .Where(x => x.EndDate != null)
                .Join(context.EmployeesProjects,
                proj => proj.ProjectId,
                ep => ep.ProjectId,
                (proj, ep) => new { proj, ep })
                .Join(context.Employees,
                ep => ep.ep.EmployeeId,
                e => e.EmployeeId,
                (ep, e) => new { ep, e })
                .Select(x => new
                {
                    x.e.FirstName,
                    x.e.LastName,
                    x.ep.proj.Name,
                    x.ep.proj.StartDate,
                    x.ep.proj.EndDate,
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.Name} : {item.StartDate} – {item.EndDate} : total days: {item.EndDate - item.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromNoClosedProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .Where(x => x.StartDate.Year > 2003 &&
                x.EndDate == null)
                .Take(1)
                .Select(x => new
                {
                    ProjectName = x.Name,
                    Employees = context.Employees
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        Town = x.Address.Town.Name,
                        x.Salary
                    })
                    .OrderBy(e => e.Town)
                    .ToList()

                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var proj in projects)
            {
                sb.AppendLine($"Project: {proj.ProjectName}");
                foreach (var e in proj.Employees)
                {
                    sb.AppendLine($" - {e.FirstName} {e.LastName} from {e.Town}- {e.Salary:f2}");
                }
                sb.AppendLine($"Project Max Salary: {proj.Employees.Max(x => x.Salary)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static void AddTown(SoftUniContext context)
        {
            var town = new Town()
            {
                Name = "Stara Zagora",
            };

            context.Towns.Add(town);
            context.SaveChanges();
        }

        public static void UpdateTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(x => x.Name == "Zagora");
            town.Name = "Stara Zagora";

            context.SaveChanges();
        }

        public static void DeleteTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(x => x.Name == "Stara Zagora");
            context.Towns.Remove(town);
            context.SaveChanges();
        }
    }
}
