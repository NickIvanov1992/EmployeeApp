﻿using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeApp
{
	public partial class EditEmployeeForm : Form
	{
		private readonly EF.AppContext appContext;
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
			if (string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
			   string.IsNullOrWhiteSpace(NameTextBox.Text) ||
			   string.IsNullOrWhiteSpace(MiddlenameTextBox.Text) ||
			   string.IsNullOrWhiteSpace(dateTimePicker1.Value.ToString()) ||
			   string.IsNullOrWhiteSpace(PassportSeriesTextBox.Text) ||
			   string.IsNullOrWhiteSpace(PassportNumberTextBox.Text))
			{
				MessageBox.Show("Не все поля заполнены");
				return;
			}

			if (PassportSeriesTextBox.TextLength != 4 && PassportNumberTextBox.TextLength != 6)
			{
				WarningPassportNumberCheck.Text = "Не полностью заполнены поля \n Серия или номер паспорта";
				return;
			}

			employee.Surname = SurnameTextBox.Text;
			employee.Name = NameTextBox.Text;
			employee.Middlename = MiddlenameTextBox.Text;
			employee.DateOfBirth = dateTimePicker1.Value;
			employee.PassportSeries = Convert.ToInt32(PassportSeriesTextBox.Text);
			employee.PassportNumber = Convert.ToInt32(PassportNumberTextBox.Text);

			appContext.Entry(employee).State = EntityState.Modified;
			appContext.SaveChangesAsync();
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
