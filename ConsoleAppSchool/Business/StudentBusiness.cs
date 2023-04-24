using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;

namespace Business
{
    public class StudentBusiness
    {
        private StudentContext _studentContext;

        public List<Students> GetAllStudents() {
            using (_studentContext = new StudentContext()) {
                return _studentContext.Students.ToList();
            }
        }

        public Students GetStudentId(int id) {
            using (_studentContext = new StudentContext()) {
                return _studentContext.Students.Find(id);
            }
        }

        public void AddStudent(Students product) {
            using (_studentContext = new StudentContext()) {
                _studentContext.Students.Add(product);
                _studentContext.SaveChanges();
            }
        }

        public void UpdateStudent(Students product) {
            using (_studentContext = new StudentContext()) {
                _studentContext.Students.Update(product);
                _studentContext.SaveChanges();
            }
        }

        public void DeleteStudent(int id) {
            using (_studentContext = new StudentContext()) {
                var product = _studentContext.Students.Find(id);
                if (product == null) return;
                
                _studentContext.Students.Remove(product);
                _studentContext.SaveChanges();
            }
        }
    }
}