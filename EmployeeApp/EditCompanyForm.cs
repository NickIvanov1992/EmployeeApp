﻿using System;
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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeApp
{
	public partial class EditCompanyForm : Form
	{
		EF.AppContext appContext;
		List<Employee> employees = new List<Employee>();
		DataTable table = new();
		private readonly int companyId;
		public EditCompanyForm(int id)
		{
			InitializeComponent();
			appContext = new EF.AppContext();
			SqlParameter sqlParameter = new SqlParameter("@id", id);
			employees = appContext.Employees.FromSqlRaw($"SELECT * FROM Employees " +
				"JOIN dbo.EmployeesCompanies ON " +
				"Employees.ID=dbo.EmployeesCompanies.EmployeeId WHERE CompanyId= @id", sqlParameter).ToList();

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

			companyId = id;
			string companyName = appContext.Companies.Find(id).Name;
			CompanyNameLabel.Text = companyName;
		}

		private void ReturnButton_Click(object sender, EventArgs e)
		{
			SelectCompanyForm selectCompanyForm = new();
			selectCompanyForm.Show();
			Hide();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			AddEmployeeForm employeeForm = new AddEmployeeForm(companyId);
			employeeForm.Show();
			Hide();

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void EditCompanyForm_Load(object sender, EventArgs e)
		{
			foreach (var item in employees)
			{
				table.Rows.Add(item.Id, item.Surname, item.Name, item.Middlename,
					item.DateOfBirth, item.PassportSeries, item.PassportNumber);
			}
			EmployeeDataGreed.DataSource = table;
		}

		private async void DeleteButton_Click(object sender, EventArgs e)
		{
			if (EmployeeDataGreed.SelectedRows.Count < 1)
				return;

			int index = EmployeeDataGreed.SelectedRows[0].Index;
			int id = 0;
			bool converted = Int32.TryParse(EmployeeDataGreed[0, index].Value.ToString(), out id);
			if (converted == false)
				return;

			using (SqlConnection connection = new SqlConnection(Program.connectionString))
			{
				connection.OpenAsync();
				SqlTransaction transaction = connection.BeginTransaction();
				SqlCommand sqlCommand = connection.CreateCommand();
				sqlCommand.Transaction = transaction;

				try
				{
					sqlCommand.CommandText = String.Format("DELETE FROM dbo.EmployeesCompanies " +
						"WHERE EmployeeId = '{0}'", id);
					await sqlCommand.ExecuteNonQueryAsync();
					///////
					await transaction.CommitAsync();
					MessageBox.Show("Сотрудник удален");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					await transaction.RollbackAsync();
				}
			}

			Refresh();
		}
	}
}
