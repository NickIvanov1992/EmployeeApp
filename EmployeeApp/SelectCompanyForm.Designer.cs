namespace EmployeeApp
{
	partial class SelectCompanyForm
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
			SearchCompanyTextBox = new TextBox();
			SearchButton = new Button();
			label2 = new Label();
			SelectButton = new Button();
			CancelButton = new Button();
			CompaniesDataGridView = new DataGridView();
			((System.ComponentModel.ISupportInitialize)CompaniesDataGridView).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
			label1.Location = new Point(24, 18);
			label1.Name = "label1";
			label1.Size = new Size(167, 21);
			label1.TabIndex = 0;
			label1.Text = "Выберите компанию";
			// 
			// SearchCompanyTextBox
			// 
			SearchCompanyTextBox.Location = new Point(28, 66);
			SearchCompanyTextBox.Name = "SearchCompanyTextBox";
			SearchCompanyTextBox.PlaceholderText = "ИНН или название";
			SearchCompanyTextBox.Size = new Size(194, 23);
			SearchCompanyTextBox.TabIndex = 1;
			// 
			// SearchButton
			// 
			SearchButton.Location = new Point(246, 65);
			SearchButton.Name = "SearchButton";
			SearchButton.Size = new Size(129, 23);
			SearchButton.TabIndex = 2;
			SearchButton.Text = "Найти";
			SearchButton.UseVisualStyleBackColor = true;
			SearchButton.Click += SearchButton_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(28, 115);
			label2.Name = "label2";
			label2.Size = new Size(102, 15);
			label2.TabIndex = 3;
			label2.Text = "Результат поиска";
			// 
			// SelectButton
			// 
			SelectButton.DialogResult = DialogResult.OK;
			SelectButton.Location = new Point(93, 243);
			SelectButton.Name = "SelectButton";
			SelectButton.Size = new Size(129, 23);
			SelectButton.TabIndex = 4;
			SelectButton.Text = "Выбрать";
			SelectButton.UseVisualStyleBackColor = true;
			SelectButton.Click += SelectButton_Click;
			// 
			// CancelButton
			// 
			CancelButton.DialogResult = DialogResult.Cancel;
			CancelButton.Location = new Point(246, 243);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(129, 23);
			CancelButton.TabIndex = 5;
			CancelButton.Text = "Отменить";
			CancelButton.UseVisualStyleBackColor = true;
			CancelButton.Click += CancelButton_Click_1;
			// 
			// CompaniesDataGridView
			// 
			CompaniesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			CompaniesDataGridView.Location = new Point(28, 133);
			CompaniesDataGridView.Name = "CompaniesDataGridView";
			CompaniesDataGridView.RowTemplate.Height = 25;
			CompaniesDataGridView.Size = new Size(347, 97);
			CompaniesDataGridView.TabIndex = 6;
			CompaniesDataGridView.CellContentClick += CompaniesDataGridView_CellContentClick;
			// 
			// SelectCompanyForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(474, 292);
			Controls.Add(CompaniesDataGridView);
			Controls.Add(CancelButton);
			Controls.Add(SelectButton);
			Controls.Add(label2);
			Controls.Add(SearchButton);
			Controls.Add(SearchCompanyTextBox);
			Controls.Add(label1);
			Name = "SelectCompanyForm";
			Text = "SelectCompanyForm";
			FormClosing += SelectCompanyForm_FormClosing;
			Load += SelectCompanyForm_Load;
			((System.ComponentModel.ISupportInitialize)CompaniesDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox SearchCompanyTextBox;
		private Button SearchButton;
		private Label label2;
		private Button SelectButton;
		private Button CancelButton;
		private DataGridView CompaniesDataGridView;
	}
}