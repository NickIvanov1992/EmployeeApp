using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string INN { get; set; }
		public string UAdress { get; set; }
		public string FactAdress { get; set; }
		public ICollection<Employee> Employees { get; set;}
        public Company()
        {
			Employees = new List<Employee>();
        }
    }
}
