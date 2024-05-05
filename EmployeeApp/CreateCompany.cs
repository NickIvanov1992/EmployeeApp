using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp
{
	public partial class CreateCompany : Form
	{
		private readonly EF.AppContext appContext;
		public CreateCompany()
		{
			InitializeComponent();
			appContext = new EF.AppContext();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			ShowStartForm();
		}

		private async void CreateButton_Click(object sender, EventArgs e)
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

			var compareInn = await appContext.Companies.FirstOrDefaultAsync(c => c.INN == company.INN);
			if (compareInn is null)
			{
				await appContext.Companies.AddAsync(company);
				await appContext.SaveChangesAsync();
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
