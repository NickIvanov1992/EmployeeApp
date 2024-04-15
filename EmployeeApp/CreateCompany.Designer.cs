namespace EmployeeApp
{
	partial class CreateCompany
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
			NameCompanyTextBox = new TextBox();
			label2 = new Label();
			textBox1 = new TextBox();
			label3 = new Label();
			label4 = new Label();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			CreateButton = new Button();
			CancelButton = new Button();
			label5 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 53);
			label1.Name = "label1";
			label1.Size = new Size(139, 15);
			label1.TabIndex = 0;
			label1.Text = "Название организации :";
			// 
			// NameCompanyTextBox
			// 
			NameCompanyTextBox.Location = new Point(168, 50);
			NameCompanyTextBox.Name = "NameCompanyTextBox";
			NameCompanyTextBox.Size = new Size(256, 23);
			NameCompanyTextBox.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(113, 93);
			label2.Name = "label2";
			label2.Size = new Size(40, 15);
			label2.TabIndex = 2;
			label2.Text = "ИНН :";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(168, 90);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(133, 23);
			textBox1.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(28, 129);
			label3.Name = "label3";
			label3.Size = new Size(125, 15);
			label3.TabIndex = 4;
			label3.Text = "Юридический адрес :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(34, 171);
			label4.Name = "label4";
			label4.Size = new Size(119, 15);
			label4.TabIndex = 5;
			label4.Text = "Фактический адрес :";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(168, 129);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(256, 23);
			textBox2.TabIndex = 6;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(168, 168);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(256, 23);
			textBox3.TabIndex = 7;
			// 
			// CreateButton
			// 
			CreateButton.Location = new Point(168, 215);
			CreateButton.Name = "CreateButton";
			CreateButton.Size = new Size(100, 30);
			CreateButton.TabIndex = 8;
			CreateButton.Text = "Создать";
			CreateButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			CancelButton.Location = new Point(324, 215);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(100, 30);
			CancelButton.TabIndex = 9;
			CancelButton.Text = "Отмена";
			CancelButton.UseVisualStyleBackColor = true;
			CancelButton.Click += CancelButton_Click;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
			label5.Location = new Point(153, 4);
			label5.Name = "label5";
			label5.Size = new Size(257, 30);
			label5.TabIndex = 10;
			label5.Text = "Информация о компании";
			// 
			// CreateCompany
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(551, 265);
			Controls.Add(label5);
			Controls.Add(CancelButton);
			Controls.Add(CreateButton);
			Controls.Add(textBox3);
			Controls.Add(textBox2);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(textBox1);
			Controls.Add(label2);
			Controls.Add(NameCompanyTextBox);
			Controls.Add(label1);
			Name = "CreateCompany";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "CreateCompany";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox NameCompanyTextBox;
		private Label label2;
		private TextBox textBox1;
		private Label label3;
		private Label label4;
		private TextBox textBox2;
		private TextBox textBox3;
		private Button CreateButton;
		private Button CancelButton;
		private Label label5;
	}
}