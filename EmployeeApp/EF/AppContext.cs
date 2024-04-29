using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>().HasData(
				new Employee
				{
					Id = 1,
					Surname = "Иванов",
					Name = "Иван",
					Middlename = "Иванович",
					DateOfBirth = DateTime.MinValue,
					PassportSeries = 1234,
					PassportNumber = 567890
				},
				new Employee
				{
					Id = 2,
					Surname = "Иванова",
					Name = "Наталья",
					Middlename = "Сергеевна",
					DateOfBirth = DateTime.Now,
					PassportSeries = 4321,
					PassportNumber = 098765
				},
				new Employee
				{
					Id = 3,
					Surname = "Олегов",
					Name = "Олег",
					Middlename = "Олегович",
					DateOfBirth = DateTime.Now,
					PassportSeries = 4656,
					PassportNumber = 946516
				}
				);
			modelBuilder.Entity<Company>().HasData(
				new Company
				{
					Id = 1,
					Name = "Мегафон",
					INN = "123456789",
					UAdress = "г.Москва пер.Оружейный 41",
					FactAdress = "г.Самара ул.Гагарина 35А",
				},
				new Company
				{
					Id = 2,
					Name = "Билайн",
					INN = "987654321",
					UAdress = "г.Москва ул.8 марта 9",
					FactAdress = "г.Самара ул. Гагарина 92А",
				}
				);
		}
	}
}
