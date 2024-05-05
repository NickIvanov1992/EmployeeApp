using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace EmployeeApp
{
	public partial class DeleteCompanyForm : Form
	{
		private readonly EF.AppContext appContext;
		private readonly DataTable table = new();
		public DeleteCompanyForm()
		{
			InitializeComponent();
			appContext = new EF.AppContext();
			table.Columns.Add("Id", typeof(int));
			table.Columns.Add("Название", typeof(string));
			table.Columns.Add("ИНН", typeof(string));
			SearchCompanyDataGrid.AllowUserToAddRows = false;
			SearchCompanyDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			SearchCompanyDataGrid.MultiSelect = false;
			SearchCompanyDataGrid.RowHeadersVisible = false;
		}

		private async void DeleteButton_Click(object sender, EventArgs e)
		{
			if (SearchCompanyDataGrid.SelectedRows.Count < 1)
				return;

			int index = SearchCompanyDataGrid.SelectedRows[0].Index;
			int id = 0;
			bool converted = Int32.TryParse(SearchCompanyDataGrid[0, index].Value.ToString(), out id);

			if (!converted)
				return;

			Company? company = await appContext.Companies.FindAsync(id);
			if (company != null)
			{
				 appContext.Remove(company);
				await appContext.SaveChangesAsync();
				MessageBox.Show("Компания удалена");
			}
			else
				MessageBox.Show("Ничего не найдено");
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

		private void DeleteTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private async void SearchButton_Click(object sender, EventArgs e)
		{
			var field = DeleteTextBox.Text;
			try
			{
				Company? company = await appContext.Companies.SingleOrDefaultAsync(c => c.INN == field
				|| c.Name.ToLower().Contains(field.ToLower()));
				table.Rows.Add(company.Id, company.Name, company.INN);
				SearchCompanyDataGrid.DataSource = table;
			}
			catch
			{
				MessageBox.Show("Ничего не выбрано");
			}		
		}
		private void DeleteTextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}

}
