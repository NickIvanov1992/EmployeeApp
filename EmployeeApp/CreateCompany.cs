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
			StartForm startForm = new();
			startForm.Show();
			Hide();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			Company company = new Company();
			company.Name = NameCompanyTextBox.Text;
			company.INN = INNTextBox.Text;
			company.UAdress = UAdressTextBox.Text;
			company.FactAdress = FactAdressTextBox.Text;

			appContext.Companies.Add(company);
			appContext.SaveChanges();
			MessageBox.Show("Компания создана");
		}
	}
}
