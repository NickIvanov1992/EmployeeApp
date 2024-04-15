namespace EmployeeApp
{
	public partial class StartForm : Form
	{
		public StartForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void CreateCompanyButton_Click(object sender, EventArgs e)
		{
			CreateCompany createCompany = new();
			createCompany.Show();
			Hide();
		}

		private void AddEmployeesButton_Click(object sender, EventArgs e)
		{
			SelectCompanyForm selectCompanyForm = new();
			selectCompanyForm.Show();
			Hide();
		}
	}
}