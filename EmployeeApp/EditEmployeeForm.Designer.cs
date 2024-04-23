namespace EmployeeApp
{
	partial class EditEmployeeForm
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
			PassportNumberTextBox = new TextBox();
			PassportSeriesTextBox = new TextBox();
			MiddlenameTextBox = new TextBox();
			NameTextBox = new TextBox();
			SurnameTextBox = new TextBox();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			CancelButton = new Button();
			SaveButton = new Button();
			dateTimePicker1 = new DateTimePicker();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
			label1.Location = new Point(34, 23);
			label1.Name = "label1";
			label1.Size = new Size(211, 20);
			label1.TabIndex = 1;
			label1.Text = "Редактировать сотрудника:";
			// 
			// PassportNumberTextBox
			// 
			PassportNumberTextBox.Location = new Point(118, 214);
			PassportNumberTextBox.Name = "PassportNumberTextBox";
			PassportNumberTextBox.Size = new Size(100, 23);
			PassportNumberTextBox.TabIndex = 18;
			// 
			// PassportSeriesTextBox
			// 
			PassportSeriesTextBox.Location = new Point(118, 185);
			PassportSeriesTextBox.Name = "PassportSeriesTextBox";
			PassportSeriesTextBox.Size = new Size(100, 23);
			PassportSeriesTextBox.TabIndex = 17;
			// 
			// MiddlenameTextBox
			// 
			MiddlenameTextBox.Location = new Point(118, 127);
			MiddlenameTextBox.Name = "MiddlenameTextBox";
			MiddlenameTextBox.Size = new Size(217, 23);
			MiddlenameTextBox.TabIndex = 15;
			// 
			// NameTextBox
			// 
			NameTextBox.Location = new Point(118, 98);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.Size = new Size(217, 23);
			NameTextBox.TabIndex = 14;
			// 
			// SurnameTextBox
			// 
			SurnameTextBox.Location = new Point(118, 69);
			SurnameTextBox.Name = "SurnameTextBox";
			SurnameTextBox.Size = new Size(217, 23);
			SurnameTextBox.TabIndex = 13;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(13, 217);
			label7.Name = "label7";
			label7.Size = new Size(99, 15);
			label7.TabIndex = 24;
			label7.Text = "Паспорт номер :";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(17, 188);
			label6.Name = "label6";
			label6.Size = new Size(95, 15);
			label6.TabIndex = 23;
			label6.Text = "Паспорт серия :";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(16, 159);
			label5.Name = "label5";
			label5.Size = new Size(96, 15);
			label5.TabIndex = 22;
			label5.Text = "Дата рождения :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(48, 130);
			label4.Name = "label4";
			label4.Size = new Size(64, 15);
			label4.TabIndex = 21;
			label4.Text = "Отчество :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(75, 100);
			label3.Name = "label3";
			label3.Size = new Size(37, 15);
			label3.TabIndex = 20;
			label3.Text = "Имя :";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(48, 72);
			label2.Name = "label2";
			label2.Size = new Size(64, 15);
			label2.TabIndex = 19;
			label2.Text = "Фамилия :";
			// 
			// CancelButton
			// 
			CancelButton.Location = new Point(233, 257);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(102, 23);
			CancelButton.TabIndex = 26;
			CancelButton.Text = "Отменить";
			CancelButton.UseVisualStyleBackColor = true;
			CancelButton.Click += CancelButton_Click;
			// 
			// SaveButton
			// 
			SaveButton.Location = new Point(119, 257);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(99, 23);
			SaveButton.TabIndex = 25;
			SaveButton.Text = "Сохранить";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(118, 159);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(200, 23);
			dateTimePicker1.TabIndex = 27;
			// 
			// EditEmployeeForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(485, 311);
			Controls.Add(dateTimePicker1);
			Controls.Add(CancelButton);
			Controls.Add(SaveButton);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(PassportNumberTextBox);
			Controls.Add(PassportSeriesTextBox);
			Controls.Add(MiddlenameTextBox);
			Controls.Add(NameTextBox);
			Controls.Add(SurnameTextBox);
			Controls.Add(label1);
			Name = "EditEmployeeForm";
			Text = "EditEmployeeForm";
			FormClosing += EditEmployeeForm_FormClosing;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Button CancelButton;
		private Button SaveButton;
		public TextBox PassportNumberTextBox;
		public TextBox PassportSeriesTextBox;
		public TextBox MiddlenameTextBox;
		public TextBox NameTextBox;
		public TextBox SurnameTextBox;
		public DateTimePicker dateTimePicker1;
	}
}