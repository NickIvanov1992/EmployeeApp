using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeApp.EF;
using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeApp
{
	public partial class EditCompanyForm : Form
	{
		EF.AppContext appContext;
		List<Employee> employees = new List<Employee>();
		DataTable table = new();
		public EditCompanyForm(int id)
		{
			InitializeComponent();
			appContext = new EF.AppContext();
			employees = appContext.Employees.FromSqlRaw("SELECT * FROM Employees " +
				"JOIN dbo.EmployeesCompanies ON " +
				"Employees.ID=dbo.EmployeesCompanies.EmployeeId").ToList();

			table.Columns.Add("Id", typeof(int));
			table.Columns.Add("Фамилия", typeof(string));
			table.Columns.Add("Имя", typeof(string));
			table.Columns.Add("Отчество", typeof(string));
			table.Columns.Add("Дата рождения", typeof(DateTime));
			table.Columns.Add("Паспорт серия", typeof(int));
			table.Columns.Add("Паспорт номер", typeof(int));
			
			EmployeeDataGreed.AllowUserToAddRows = false;
			EmployeeDataGreed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			EmployeeDataGreed.MultiSelect = false;
			EmployeeDataGreed.RowHeadersVisible = false;
			//employees = appContext.Employees.FromSqlRaw("SELECT * FROM Employees JOIN dbo.EmployeesCompanies ON Employees.ID=dbo.EmployeesCompanies.EmployeeId").ToList();
			//dataGridView1.DataSource = appContext.Employees.Local.ToBindingList();
			//CompanyNameLabel.Text = appContext.Companies.Where(c =>c.Id == id).Select(c => c.Name).ToString();
		}

		private void ReturnButton_Click(object sender, EventArgs e)
		{
			SelectCompanyForm selectCompanyForm = new();
			selectCompanyForm.Show();
			Hide();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			AddEmployeeForm employeeForm = new AddEmployeeForm();
			employeeForm.Show();
			Hide();
			
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void EditCompanyForm_Load(object sender, EventArgs e)
		{
			foreach(var item in employees)
			{
				table.Rows.Add(item.Id, item.Surname, item.Name, item.Middlename,
					item.DateOfBirth, item.PassportSeries, item.PassportNumber);
			}
			EmployeeDataGreed.DataSource = table;
		}
	}
}
