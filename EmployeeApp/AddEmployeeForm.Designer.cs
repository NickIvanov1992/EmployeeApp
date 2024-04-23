namespace EmployeeApp
{
	partial class AddEmployeeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			textBox5 = new TextBox();
			textBox6 = new TextBox();
			button1 = new Button();
			button2 = new Button();
			dateTimePicker1 = new DateTimePicker();
			CompanyNameLabel = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
			label1.Location = new Point(29, 19);
			label1.Name = "label1";
			label1.Size = new Size(253, 20);
			label1.TabIndex = 0;
			label1.Text = "Добавить сотрудника в компанию:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(64, 62);
			label2.Name = "label2";
			label2.Size = new Size(64, 15);
			label2.TabIndex = 1;
			label2.Text = "Фамилия :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(91, 90);
			label3.Name = "label3";
			label3.Size = new Size(37, 15);
			label3.TabIndex = 2;
			label3.Text = "Имя :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(64, 120);
			label4.Name = "label4";
			label4.Size = new Size(64, 15);
			label4.TabIndex = 3;
			label4.Text = "Отчество :";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(32, 149);
			label5.Name = "label5";
			label5.Size = new Size(96, 15);
			label5.TabIndex = 4;
			label5.Text = "Дата рождения :";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(33, 178);
			label6.Name = "label6";
			label6.Size = new Size(95, 15);
			label6.TabIndex = 5;
			label6.Text = "Паспорт серия :";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(29, 207);
			label7.Name = "label7";
			label7.Size = new Size(99, 15);
			label7.TabIndex = 6;
			label7.Text = "Паспорт номер :";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(145, 59);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(217, 23);
			textBox1.TabIndex = 7;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(145, 88);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(217, 23);
			textBox2.TabIndex = 8;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(145, 117);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(217, 23);
			textBox3.TabIndex = 9;
			// 
			// textBox5
			// 
			textBox5.Location = new Point(145, 175);
			textBox5.Name = "textBox5";
			textBox5.Size = new Size(100, 23);
			textBox5.TabIndex = 11;
			// 
			// textBox6
			// 
			textBox6.Location = new Point(145, 204);
			textBox6.Name = "textBox6";
			textBox6.Size = new Size(100, 23);
			textBox6.TabIndex = 12;
			// 
			// button1
			// 
			button1.Location = new Point(146, 252);
			button1.Name = "button1";
			button1.Size = new Size(99, 23);
			button1.TabIndex = 13;
			button1.Text = "Добавить";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(260, 252);
			button2.Name = "button2";
			button2.Size = new Size(102, 23);
			button2.TabIndex = 14;
			button2.Text = "Отменить";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(145, 146);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(200, 23);
			dateTimePicker1.TabIndex = 15;
			// 
			// CompanyNameLabel
			// 
			CompanyNameLabel.AutoSize = true;
			CompanyNameLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			CompanyNameLabel.Location = new Point(290, 18);
			CompanyNameLabel.Name = "CompanyNameLabel";
			CompanyNameLabel.Size = new Size(55, 21);
			CompanyNameLabel.TabIndex = 16;
			CompanyNameLabel.Text = "label8";
			// 
			// AddEmployeeForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(516, 287);
			Controls.Add(CompanyNameLabel);
			Controls.Add(dateTimePicker1);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox6);
			Controls.Add(textBox5);
			Controls.Add(textBox3);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "AddEmployeeForm";
			Text = "AddEmployeeForm";
			FormClosing += AddEmployeeForm_FormClosing;
			Load += AddEmployeeForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Button button1;
		private Button button2;
		public TextBox textBox1;
		public TextBox textBox2;
		public TextBox textBox3;
		public TextBox textBox5;
		public TextBox textBox6;
		public DateTimePicker dateTimePicker1;
		private Label CompanyNameLabel;
	}
}