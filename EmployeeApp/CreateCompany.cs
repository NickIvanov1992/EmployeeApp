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
using EmployeeApp.EF;
using EmployeeApp.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp
{
	public partial class CreateCompany : Form
	{
		EF.AppContext appContext;
		public CreateCompany()
		{
			InitializeComponent();
			appContext = new EF.AppContext();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			ShowStartForm();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(NameCompanyTextBox.Text) ||
			   string.IsNullOrWhiteSpace(INNTextBox.Text) ||
			   string.IsNullOrWhiteSpace(UAdressTextBox.Text) ||
			   string.IsNullOrWhiteSpace(FactAdressTextBox.Text))
			{
				MessageBox.Show("Не все поля заполнены");
				return;
			}

			if (INNTextBox.TextLength < 10)
			{
				WarningInnLabel.Text = "Не менее 10 символов";
				return;
			}
				
			Company company = new Company();
			company.Name = NameCompanyTextBox.Text;
			company.INN = INNTextBox.Text;
			company.UAdress = UAdressTextBox.Text;
			company.FactAdress = FactAdressTextBox.Text;

			var compareInn = appContext.Companies.FirstOrDefault(c => c.INN == company.INN);
			if (compareInn is null)
			{
				appContext.Companies.Add(company);
				appContext.SaveChanges();
				MessageBox.Show("Компания создана");

				ShowStartForm();
			}
			else
				MessageBox.Show("Такая компания уже существует");		
		}
		private void ShowStartForm()
		{
			StartForm startForm = new();
			startForm.Show();
			Hide();
		}

		private void CreateCompany_FormClosing(object sender, FormClosingEventArgs e)
		{
			ShowStartForm();
		}

		private void INNTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && e.KeyChar != (char)8)
				e.Handled = true;
		}
	}
}
