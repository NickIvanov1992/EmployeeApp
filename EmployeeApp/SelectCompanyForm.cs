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
		public SelectCompanyForm()
		{
			InitializeComponent();
		}
		private void CancelButton_Click(object sender, EventArgs e)
		{
			StartForm startForm = new();
			startForm.Show();
			Hide();
		}
	}
}
