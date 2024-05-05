using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeApp
{
	public partial class SelectCompanyForm : Form
	{
		private readonly EF.AppContext appContext;
		private readonly List<Company> companies = new List<Company>();
		private readonly DataTable table = new();
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

		private async void SearchButton_Click(object sender, EventArgs e)
		{
			string searchCompany = SearchCompanyTextBox.Text;
			Company[] companies = await appContext.Companies.Where(c => c.Name.ToLower().Contains(searchCompany.ToLower())
								|| c.INN.Contains(searchCompany)).ToArrayAsync();

			table.Clear();

			if (companies.Length > 0)
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

		private async void SelectCompanyForm_LoadAsync(object sender, EventArgs e)
		{
			List<Company> companies = await appContext.Companies.ToListAsync();
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
