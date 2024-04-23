using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public string Middlename { get; set; }
		public DateTime DateOfBirth { get; set; }
		public int PassportSeries { get; set; }
		public int PassportNumber { get; set; }
		public ICollection<Company> Companies { get; set; }
        public Employee()
        {
			Companies = new List<Company>();
        }
    }
}
