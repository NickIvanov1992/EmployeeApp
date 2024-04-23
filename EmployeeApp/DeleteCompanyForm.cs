using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApp
{
	public partial class DeleteCompanyForm : Form
	{
		EF.AppContext appContext;
		public DeleteCompanyForm()
		{
			appContext = new EF.AppContext();
			InitializeComponent();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			string convertedInn = DeleteTextBox.Text;
			Company company = appContext.Companies.FirstOrDefault(c => c.INN == convertedInn);
			appContext.Remove(company);
			appContext.SaveChanges();
			MessageBox.Show("Компания удалена");
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			ShowStartForm();
		}
		private void ShowStartForm()
		{
			StartForm startForm = new();
			startForm.Show();
			Hide();
		}

		private void DeleteCompanyForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ShowStartForm();
		}
	}
}
