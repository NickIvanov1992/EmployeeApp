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
	public partial class EditCompanyForm : Form
	{
		public EditCompanyForm()
		{
			InitializeComponent();
		}

		private void ReturnButton_Click(object sender, EventArgs e)
		{
			SelectCompanyForm selectCompanyForm = new();
			selectCompanyForm.Show();
			Hide();
		}
	}
}
