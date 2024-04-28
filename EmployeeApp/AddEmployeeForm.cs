using EmployeeApp.EF;
using EmployeeApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeApp
{
	public partial class AddEmployeeForm : Form
	{
		EF.AppContext appContext;
		private readonly int companyId;

		public AddEmployeeForm(int id)
		{
			InitializeComponent();
			appContext = new EF.AppContext();
			companyId = id;
			CompanyNameLabel.Text = appContext.Companies.Find(id).Name;
		}

		public void AddEmployeeForm_Load(object sender, EventArgs e)
		{

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
			using (SqlConnection connection = new SqlConnection(Program.connectionString))
			{
				connection.Open();
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
							int employeeId = appContext.Employees.Single(
							e => e.PassportSeries == employee.PassportSeries && e.PassportNumber == employee.PassportNumber).Id;
							if (CheckPerson(employee))
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
						appContext.Employees.Add(employee);
						appContext.SaveChanges();

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
			//string passportNumber = emp.PassportSeries.ToString() + emp.PassportNumber.ToString();
			var searchPersonByPassport = appContext.Employees.Any(
				e => e.PassportSeries == emp.PassportSeries && e.PassportNumber == emp.PassportNumber);
			
			if (searchPersonByPassport)
			{

				return false;
			}
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
