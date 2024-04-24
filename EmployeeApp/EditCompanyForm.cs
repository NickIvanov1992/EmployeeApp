using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeApp
{
	public partial class EditCompanyForm : Form
	{
		EF.AppContext appContext;
		List<Employee> employees = new List<Employee>();
		DataTable table = new();
		private readonly int companyId;
		private readonly string companyName;
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
			//	EmployeeDataGreed.Rows[1].ReadOnly = true;

			companyId = id;
			this.companyName = appContext.Companies.Find(id).Name;
			CompanyNameLabel.Text = companyName;
		}

		private void ReturnButton_Click(object sender, EventArgs e)
		{
			ShowSelectCompanyForm();
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
				SqlCommand countEmployees = new SqlCommand($"SELECT COUNT(*) FROM dbo.EmployeesCompanies WHERE EmployeeId = '{id}'", connection);
				await connection.OpenAsync();

				int numRows = (int)countEmployees.ExecuteScalar();

				SqlTransaction transaction = connection.BeginTransaction();
				SqlCommand sqlCommand = connection.CreateCommand();
				sqlCommand.Transaction = transaction;

				try
				{
					sqlCommand.CommandText = String.Format("DELETE FROM dbo.EmployeesCompanies " +
					"WHERE EmployeeId = '{0}'", id);
					await sqlCommand.ExecuteNonQueryAsync();

					if (numRows <= 1)
					{
						sqlCommand.CommandText = String.Format("DELETE FROM dbo.Employees " +
						"WHERE Id = {0}", id);
						await sqlCommand.ExecuteNonQueryAsync();
					}

					await transaction.CommitAsync();
					MessageBox.Show("Сотрудник удален");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					await transaction.RollbackAsync();
				}
			}
			RestartForm();
		}
		private void RestartForm()
		{
			Hide();
			EditCompanyForm form = new(companyId);
			form.Show();
		}
		private void ShowSelectCompanyForm()
		{
			SelectCompanyForm selectCompanyForm = new();
			selectCompanyForm.Show();
			Hide();
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			if (EmployeeDataGreed.SelectedRows.Count < 1)
				return;
			int index = EmployeeDataGreed.SelectedRows[0].Index;
			int id = 0;
			bool converted = Int32.TryParse(EmployeeDataGreed[0, index].Value.ToString(), out id);

			if (!converted)
				return;

			Employee employee = appContext.Employees.Find(id);

			EditEmployeeForm editEmployeeForm = new EditEmployeeForm(employee, companyId);
			editEmployeeForm.Show();
			Hide();
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			string searchEmployee = SearchFieldTextBox.Text;

			Employee[] searchResult = employees.Where(c => c.PassportNumber.ToString() == searchEmployee
								|| c.Surname.Contains(searchEmployee.ToLower())).ToArray();

			table.Clear();

			if (searchResult.Count() > 0)
			{
				for (int i = searchResult.Count() - 1; i >= 0; i--)
				{
					var employee = searchResult[i];
					table.Rows.Add(employee.Id, employee.Surname, employee.Name, employee.Middlename,
					employee.DateOfBirth, employee.PassportSeries, employee.PassportNumber);
				}
			}
			else
				MessageBox.Show($"В компании {companyName} Никого не найдено");

			EmployeeDataGreed.DataSource = table;
		}

		private void EditCompanyForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ShowSelectCompanyForm();
		}

		private void SaveToCsvButton_Click(object sender, EventArgs e)
		{
			SaveEmployeesToCSVfile("SaveEmployees.csv", EmployeeDataGreed);
		}
		private bool SaveEmployeesToCSVfile(string fileName, DataGridView table)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
				{
					List<int> col_n = new List<int>();
					foreach (DataGridViewColumn col in table.Columns)
						if (col.Visible)
						{
							sw.Write(col.HeaderText + ";");
							col_n.Add(col.Index);
						}
					sw.WriteLine();
					int x = table.RowCount;
					if (table.AllowUserToAddRows) 
						x--;

					for (int i = 0; i < x; i++)
					{
						for (int y = 0; y < col_n.Count; y++)
							sw.Write(table[col_n[y], i].Value + ";");
						sw.Write(" \r\n");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			return true;
		}
		private DataTable ReadFromCSVfile(string fileName)
		{
			DataTable dt = new DataTable();
			using (StreamReader sr = new StreamReader(fileName, Encoding.Unicode))
			{
				string[] headers = sr.ReadLine().Split(';');
				foreach (string header in headers)
				{
					dt.Columns.Add(header);
				}
				while (!sr.EndOfStream)
				{
					string[] rows = sr.ReadLine().Split(';');
					DataRow dr = dt.NewRow();
					for (int i = 0; i < headers.Length; i++)
					{
						dr[i] = rows[i];
					}
					dt.Rows.Add(dr);
				}

			}
			return dt;
		}

		private void UploadCsvButton_Click(object sender, EventArgs e)
		{
			EmployeeDataGreed.DataSource = ReadFromCSVfile("SaveEmployees.csv");
			appContext.SaveChanges();
			MessageBox.Show("Данные загружены");
		}
	}
}
