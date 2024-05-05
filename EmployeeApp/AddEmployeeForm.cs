using EmployeeApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EmployeeApp
{
	public partial class AddEmployeeForm : Form
	{
		private readonly EF.AppContext appContext;
		private readonly int companyId;
		private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		public AddEmployeeForm(int id)
		{
			InitializeComponent();
			appContext = new EF.AppContext();
			companyId = id;

		}

		public void AddEmployeeForm_Load(object sender, EventArgs e)
		{
			CompanyNameLabel.Text = appContext.Companies.Find(companyId).Name;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) ||
			   string.IsNullOrWhiteSpace(textBox2.Text) ||
			   string.IsNullOrWhiteSpace(textBox3.Text) ||
			   string.IsNullOrWhiteSpace(dateTimePicker1.Value.ToString()))
			{
				MessageBox.Show("Не все поля заполнены");
				return;
			}

			if (textBox5.TextLength != 4 && textBox6.TextLength != 6)
			{
				WarningLabel.Text = "Не полностью заполнены поля \n Серия или номер паспорта";
				return;
			}
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				await connection.OpenAsync();
				SqlTransaction transaction = connection.BeginTransaction();
				SqlCommand sqlCommand = connection.CreateCommand();
				sqlCommand.Transaction = transaction;

				try
				{
					Employee employee = new Employee();

					employee.Surname = textBox1.Text;
					employee.Name = textBox2.Text;
					employee.Middlename = textBox3.Text;
					employee.DateOfBirth = dateTimePicker1.Value;
					employee.PassportSeries = Convert.ToInt32(textBox5.Text);
					employee.PassportNumber = Convert.ToInt32(textBox6.Text);

					if(!CheckPerson(employee))
					{
						DialogResult result = MessageBox.Show("Такой сотрудник уже существует в другой компании. \n" +
								"Добавить его в список ваших работников?", "Ошибка", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							int employeeId = appContext.Employees.SingleAsync(
							e => e.PassportSeries == employee.PassportSeries && e.PassportNumber == employee.PassportNumber).Id;
							Company com = await appContext.Companies.SingleAsync(c => c.Id == companyId);
							if (!com.Employees.Any(e => e.Id == employeeId))
							{
								sqlCommand.CommandText = String.Format($"INSERT INTO dbo.EmployeesCompanies VALUES('{companyId}', '{employeeId}')");
								await sqlCommand.ExecuteNonQueryAsync();
							}
							else
								MessageBox.Show("Сотрудник уже существует в данно компании");			
						}
						else
							throw new ArgumentException("Такой сотрудник уже существует");
					}
					else
					{
						await appContext.Employees.AddAsync(employee);
						await appContext.SaveChangesAsync();

						sqlCommand.CommandText = String.Format("INSERT INTO dbo.EmployeesCompanies(CompanyId, EmployeeId)" +
							"VALUES ('{0}', '{1}')", companyId, employee.Id);
						await sqlCommand.ExecuteNonQueryAsync();

						MessageBox.Show("Сотрудник добавлен");
					}
					await transaction.CommitAsync();

					ShowEditCompanyForm();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					await transaction.RollbackAsync();
				}
			}
		}
		private bool CheckPerson(Employee emp)
		{
			var searchPersonByPassport = appContext.Employees.Any(
				e => e.PassportSeries == emp.PassportSeries && e.PassportNumber == emp.PassportNumber);
			
			if (searchPersonByPassport)
				return false;
	
			return true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ShowEditCompanyForm();
		}
		private void ShowEditCompanyForm()
		{
			EditCompanyForm editCompanyForm = new(companyId);
			editCompanyForm.Show();
			Hide();
		}

		private void AddEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			appContext.SaveChangesAsync();
			ShowEditCompanyForm();
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && e.KeyChar != (char)8)
				e.Handled = true;
		}
	}
}
