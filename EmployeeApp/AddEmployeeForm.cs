using EmployeeApp.EF;
using EmployeeApp.Models;
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
	public partial class AddEmployeeForm : Form
	{
		EF.AppContext appContext;
		public AddEmployeeForm()
		{
			InitializeComponent();
			appContext = new EF.AppContext();
		}

		public void AddEmployeeForm_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Employee employee = new Employee();

			employee.Surname = textBox1.Text;
			employee.Name = textBox2.Text;
			employee.Middlename = textBox3.Text;
			employee.DateOfBirth = dateTimePicker1.Value;
			employee.PassportSeries = Convert.ToInt32(textBox5.Text);
			employee.PassportNumber = Convert.ToInt32(textBox6.Text);

			appContext.Employees.Add(employee);
			appContext.SaveChanges();

			MessageBox.Show("Сотрудник добавлен");
		}
	}
}
