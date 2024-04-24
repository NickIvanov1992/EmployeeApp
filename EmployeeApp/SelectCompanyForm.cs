using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
	public partial class SelectCompanyForm : Form
	{
		EF.AppContext appContext;
		List<Company> companies = new List<Company>();
		DataTable table = new();
		public SelectCompanyForm()
		{
			InitializeComponent();
			appContext = new EF.AppContext();
			companies = appContext.Companies.ToList();
			table.Columns.Add("Id", typeof(int));
			table.Columns.Add("Название", typeof(string));
			table.Columns.Add("ИНН", typeof(string));
			CompaniesDataGridView.AllowUserToAddRows = false;
			CompaniesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			CompaniesDataGridView.MultiSelect = false;
			CompaniesDataGridView.RowHeadersVisible = false;
		}

		private void CancelButton_Click_1(object sender, EventArgs e)
		{
			ShowStartForm();
		}
		private void ShowStartForm()
		{
			StartForm startForm = new();
			startForm.Show();
			Hide();
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			string searchCompany = SearchCompanyTextBox.Text;
			Company[] companies = appContext.Companies.Where(c => c.Name.ToLower().Contains(searchCompany.ToLower())
								|| c.INN.Contains(searchCompany)).ToArray();

			table.Clear();

			if (companies.Count() > 0)
			{
				foreach (var company in companies)
					table.Rows.Add(company.Id, company.Name, company.INN);
			}
			else
				MessageBox.Show("Ничего не найдено");

			CompaniesDataGridView.DataSource = table;
		}

		private void CompaniesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void SelectCompanyForm_Load(object sender, EventArgs e)
		{
			List<Company> companies = appContext.Companies.ToList();
			for (int i = 0; i < companies.Count(); i++)
			{
				table.Rows.Add(companies[i].Id, companies[i].Name, companies[i].INN);
			}
			CompaniesDataGridView.DataSource = table;
		}

		private void SelectButton_Click(object sender, EventArgs e)
		{
			if (CompaniesDataGridView.SelectedRows.Count < 1)
				return;

			int index = CompaniesDataGridView.SelectedRows[0].Index;
			int id = 0;
			bool converted = Int32.TryParse(CompaniesDataGridView[0, index].Value.ToString(), out id);

			if (!converted)
				return;

			EditCompanyForm editcompanyform = new EditCompanyForm(id);
			editcompanyform.Show();
			Hide();
		}

		private void SelectCompanyForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ShowStartForm();
		}
	}
}
