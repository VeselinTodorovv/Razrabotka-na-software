using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;

namespace Business
{
    public class FirmBusiness
    {
        private FirmContext _context;

        public List<Employee> GetAllEmployees() {
            using (_context = new FirmContext()) {
                return _context.Employees.ToList();
            }
        }

        public Employee GetEmployeeById(int id) {
            using (_context = new FirmContext()) {
                return _context.Employees.Find(id);
            }
        }
        
        public void AddEmployee(Employee employee) {
            using (_context = new FirmContext()) {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee employee) {
            using (_context = new FirmContext()) {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id) {
            using (_context = new FirmContext()) {
                Employee employee = _context.Employees.Find(id);
                if (employee != null) {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                }

            }
        }
    }
}