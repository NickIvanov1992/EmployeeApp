using EmployeeApp.EF;
using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApp
{
	public partial class EditEmployeeForm : Form
	{
		EF.AppContext appContext;
		private readonly Employee employee;
		private readonly int companyId;
		public EditEmployeeForm(Employee employee, int companyId)
		{
			InitializeComponent();

			appContext = new EF.AppContext();
			this.employee = employee;
			this.companyId = companyId;

			SurnameTextBox.Text = employee.Surname;
			NameTextBox.Text = employee.Name;
			MiddlenameTextBox.Text = employee.Middlename;
			dateTimePicker1.Value = employee.DateOfBirth;
			PassportSeriesTextBox.Text = employee.PassportSeries.ToString();
			PassportNumberTextBox.Text = employee.PassportNumber.ToString();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			employee.Surname = SurnameTextBox.Text;
			employee.Name = NameTextBox.Text;
			employee.Middlename = MiddlenameTextBox.Text;
			employee.DateOfBirth = dateTimePicker1.Value;
			employee.PassportSeries = Convert.ToInt32(PassportSeriesTextBox.Text);
			employee.PassportNumber = Convert.ToInt32(PassportNumberTextBox.Text);

			appContext.Entry(employee).State = EntityState.Modified;
			appContext.SaveChanges();
			MessageBox.Show("Данные работника обновлены");

			ShowEditCompanyForm();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			ShowEditCompanyForm();
		}
		private void ShowEditCompanyForm()
		{
			EditCompanyForm editCompanyForm = new(companyId);
			editCompanyForm.Show();
			Hide();
		}

		private void EditEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ShowEditCompanyForm();
		}
	}
}
