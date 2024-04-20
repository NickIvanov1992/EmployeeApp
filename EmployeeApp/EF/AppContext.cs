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
		public AppContext() => Database.EnsureCreated();
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-VOPPTIR;Initial Catalog=TestCompanies;User ID=userNick;Password=sa;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Company> Companies { get; set; }
	}
}
