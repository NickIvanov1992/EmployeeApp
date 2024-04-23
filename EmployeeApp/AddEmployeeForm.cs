using EmployeeApp.EF;
using EmployeeApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
					appContext.Employees.Add(employee);
					appContext.SaveChanges();

					sqlCommand.CommandText = String.Format("INSERT INTO dbo.EmployeesCompanies(CompanyId, EmployeeId)" +
						"VALUES ('{0}', '{1}')", companyId, employee.Id);

					await sqlCommand.ExecuteNonQueryAsync();

					await transaction.CommitAsync();

					MessageBox.Show("Сотрудник добавлен");

					ShowEditCompanyForm();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					await transaction.RollbackAsync();
				}
			}

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
	}
}
