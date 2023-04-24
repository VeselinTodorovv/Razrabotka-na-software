using System;

namespace Data.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Town { get; set; }
        public DateTime BirthDate { get; set; }
        public int Class { get; set; }
        public double Uspeh { get; set; }
    }
}