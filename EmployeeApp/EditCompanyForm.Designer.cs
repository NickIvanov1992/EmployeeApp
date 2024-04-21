namespace EmployeeApp
{
	partial class EditCompanyForm
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
			SearchButton = new Button();
			SearchFieldTextBox = new TextBox();
			AddButton = new Button();
			EditButton = new Button();
			DeleteButton = new Button();
			UploadCsvButton = new Button();
			SaveToCsvButton = new Button();
			ReturnButton = new Button();
			EmployeeDataGreed = new DataGridView();
			CompanyNameLabel = new Label();
			((System.ComponentModel.ISupportInitialize)EmployeeDataGreed).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(90, 21);
			label1.TabIndex = 0;
			label1.Text = "Компания:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(21, 56);
			label2.Name = "label2";
			label2.Size = new Size(132, 17);
			label2.TabIndex = 1;
			label2.Text = "Список сотрудников:";
			// 
			// SearchButton
			// 
			SearchButton.Location = new Point(28, 88);
			SearchButton.Name = "SearchButton";
			SearchButton.Size = new Size(125, 25);
			SearchButton.TabIndex = 2;
			SearchButton.Text = "Найти";
			SearchButton.UseVisualStyleBackColor = true;
			// 
			// SearchFieldTextBox
			// 
			SearchFieldTextBox.Location = new Point(167, 88);
			SearchFieldTextBox.Name = "SearchFieldTextBox";
			SearchFieldTextBox.Size = new Size(407, 23);
			SearchFieldTextBox.TabIndex = 3;
			// 
			// AddButton
			// 
			AddButton.Location = new Point(28, 274);
			AddButton.Name = "AddButton";
			AddButton.Size = new Size(115, 30);
			AddButton.TabIndex = 4;
			AddButton.Text = "Добавить";
			AddButton.UseVisualStyleBackColor = true;
			AddButton.Click += AddButton_Click;
			// 
			// EditButton
			// 
			EditButton.Location = new Point(158, 274);
			EditButton.Name = "EditButton";
			EditButton.Size = new Size(115, 30);
			EditButton.TabIndex = 5;
			EditButton.Text = "Редактировать";
			EditButton.UseVisualStyleBackColor = true;
			// 
			// DeleteButton
			// 
			DeleteButton.Location = new Point(304, 274);
			DeleteButton.Name = "DeleteButton";
			DeleteButton.Size = new Size(115, 30);
			DeleteButton.TabIndex = 6;
			DeleteButton.Text = "Удалить";
			DeleteButton.UseVisualStyleBackColor = true;
			DeleteButton.Click += DeleteButton_Click;
			// 
			// UploadCsvButton
			// 
			UploadCsvButton.Location = new Point(28, 345);
			UploadCsvButton.Name = "UploadCsvButton";
			UploadCsvButton.Size = new Size(141, 31);
			UploadCsvButton.TabIndex = 7;
			UploadCsvButton.Text = "Загрузить CSV файл";
			UploadCsvButton.UseVisualStyleBackColor = true;
			// 
			// SaveToCsvButton
			// 
			SaveToCsvButton.Location = new Point(191, 345);
			SaveToCsvButton.Name = "SaveToCsvButton";
			SaveToCsvButton.Size = new Size(141, 31);
			SaveToCsvButton.TabIndex = 8;
			SaveToCsvButton.Text = "Сохранить в CSV";
			SaveToCsvButton.UseVisualStyleBackColor = true;
			// 
			// ReturnButton
			// 
			ReturnButton.Location = new Point(519, 345);
			ReturnButton.Name = "ReturnButton";
			ReturnButton.Size = new Size(79, 30);
			ReturnButton.TabIndex = 9;
			ReturnButton.Text = "Назад";
			ReturnButton.UseVisualStyleBackColor = true;
			ReturnButton.Click += ReturnButton_Click;
			// 
			// EmployeeDataGreed
			// 
			EmployeeDataGreed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			EmployeeDataGreed.Location = new Point(29, 122);
			EmployeeDataGreed.Name = "EmployeeDataGreed";
			EmployeeDataGreed.RowTemplate.Height = 25;
			EmployeeDataGreed.Size = new Size(545, 150);
			EmployeeDataGreed.TabIndex = 10;
			// 
			// CompanyNameLabel
			// 
			CompanyNameLabel.AutoSize = true;
			CompanyNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			CompanyNameLabel.Location = new Point(135, 6);
			CompanyNameLabel.Name = "CompanyNameLabel";
			CompanyNameLabel.Size = new Size(65, 25);
			CompanyNameLabel.TabIndex = 11;
			CompanyNameLabel.Text = "label3";
			CompanyNameLabel.Click += label3_Click;
			// 
			// EditCompanyForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(610, 388);
			Controls.Add(CompanyNameLabel);
			Controls.Add(EmployeeDataGreed);
			Controls.Add(ReturnButton);
			Controls.Add(SaveToCsvButton);
			Controls.Add(UploadCsvButton);
			Controls.Add(DeleteButton);
			Controls.Add(EditButton);
			Controls.Add(AddButton);
			Controls.Add(SearchFieldTextBox);
			Controls.Add(SearchButton);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "EditCompanyForm";
			Text = "EditCompanyForm";
			Load += EditCompanyForm_Load;
			((System.ComponentModel.ISupportInitialize)EmployeeDataGreed).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Button SearchButton;
		private TextBox SearchFieldTextBox;
		private Button AddButton;
		private Button EditButton;
		private Button DeleteButton;
		private Button UploadCsvButton;
		private Button SaveToCsvButton;
		private Button ReturnButton;
		private DataGridView EmployeeDataGreed;
		private Label CompanyNameLabel;
	}
}