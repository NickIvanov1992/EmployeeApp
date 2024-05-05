using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeApp.EF;
using EmployeeApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace EmployeeApp
{
	public partial class EditCompanyForm : Form
	{
		private readonly EF.AppContext appContext;
		private  List<Employee> employees = new List<Employee>();
		private readonly DataTable table = new();
		private readonly int companyId;
		private string companyName;
		private readonly string sql = "SELECT * FROM Employees " +
				"JOIN dbo.EmployeesCompanies ON " +
				"Employees.ID=dbo.EmployeesCompanies.EmployeeId WHERE CompanyId= @id";
		private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		public EditCompanyForm(int id)
		{
			InitializeComponent();
			appContext = new EF.AppContext();

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
			EmployeeDataGreed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			companyId = id;
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

		private async void EditCompanyForm_Load(object sender, EventArgs e)
		{
			SqlParameter sqlParameter = new SqlParameter("@id", companyId);
			employees = await appContext.Employees.FromSqlRaw(sql, sqlParameter).ToListAsync();

			Company? company = await appContext.Companies.FindAsync(companyId);
			companyName = company.Name;

			CompanyNameLabel.Text = companyName;

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

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand countEmployees = new SqlCommand($"SELECT COUNT(*) FROM dbo.EmployeesCompanies WHERE EmployeeId = '{id}'", connection);
				await connection.OpenAsync();

				int numRows =  (int)await countEmployees.ExecuteScalarAsync();

				SqlTransaction transaction = connection.BeginTransaction();
				SqlCommand sqlCommand = connection.CreateCommand();
				sqlCommand.Transaction = transaction;

				try
				{
					sqlCommand.CommandText = String.Format("DELETE FROM dbo.EmployeesCompanies " +
					"WHERE EmployeeId = '{0}' AND CompanyId = '{1}'", id,companyId);
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

		private async void EditButton_Click(object sender, EventArgs e)
		{
			if (EmployeeDataGreed.SelectedRows.Count < 1)
				return;
			int index = EmployeeDataGreed.SelectedRows[0].Index;
			int id = 0;
			bool converted = Int32.TryParse(EmployeeDataGreed[0, index].Value.ToString(), out id);

			if (!converted)
				return;

			Employee? employee = await appContext.Employees.FindAsync(id);
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

			if (searchResult.Length > 0)
			{
				for (int i = searchResult.Length - 1; i >= 0; i--)
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

			SaveFileDialog saveFileDialog = new();
			saveFileDialog.Filter = "csv files (*.csv) |*.csv";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
				SaveEmployeesToCSVfile(saveFileDialog.FileName, EmployeeDataGreed);

		}
		private static bool SaveEmployeesToCSVfile(string fileName, DataGridView table)
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
				MessageBox.Show("Данные сохранены");
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
					DataRow dr = table.NewRow();

					for (int i = 0; i < table.Columns.Count; i++)
					{
						dr[i] = rows[i];
					}
					table.Rows.Add(dr);

					UpdateTransaction(dr);
				}
			}
			return table;
		}
		private async void UpdateTransaction(DataRow dataRow)
		{
			using (SqlConnection newconnection = new SqlConnection(connectionString))
			{
				await newconnection.OpenAsync();
				SqlTransaction updateTransaction = newconnection.BeginTransaction();
				SqlCommand sqlCommand = newconnection.CreateCommand();
				sqlCommand.Transaction = updateTransaction;

				try
				{
					sqlCommand.CommandText = String.Format("SET IDENTITY_INSERT Employees ON");
					 await sqlCommand.ExecuteNonQueryAsync();

					if (!appContext.Employees.Any(a => a.Id == Convert.ToInt32(dataRow[0])))
					{
						sqlCommand.CommandText = String.Format("INSERT INTO Employees " +
						"(Id, Surname, Name, Middlename, DateOfBirth, PassportSeries, PassportNumber)" +
						"VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", dataRow[0], dataRow[1], dataRow[2], dataRow[3], dataRow[4], dataRow[5], dataRow[6]);
						await sqlCommand.ExecuteNonQueryAsync();
					}
					
					sqlCommand.CommandText = String.Format("SET IDENTITY_INSERT Employees OFF");
					await sqlCommand.ExecuteNonQueryAsync();

					sqlCommand.CommandText = String.Format("INSERT INTO EmployeesCompanies " +
						"VALUES('{0}', '{1}')", companyId, dataRow[0]);
					await sqlCommand.ExecuteNonQueryAsync();

					await updateTransaction.CommitAsync();
					MessageBox.Show("Данные загружены");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Данные сотрудники уже существуют в одной из компаний. \n " +
						"Вы можете добавить их на подработку в свою компанию");
					await updateTransaction.RollbackAsync();
				}
			}
		}

		private void UploadCsvButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new();
			openFileDialog.Filter = "csv files (*.csv) |*.csv";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;

			if(openFileDialog.ShowDialog() == DialogResult.OK)
				EmployeeDataGreed.DataSource = ReadFromCSVfile(openFileDialog.FileName);
		}
	}
}
