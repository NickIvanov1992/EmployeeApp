using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.EF
{
	public class AppContext : DbContext
	{
		string connection = Program.connectionString;
		public AppContext() => Database.EnsureCreated();
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connection);
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Company> Companies { get; set; }
	}
}
