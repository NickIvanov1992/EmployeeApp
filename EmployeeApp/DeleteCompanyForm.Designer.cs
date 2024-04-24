namespace EmployeeApp
{
	partial class DeleteCompanyForm
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
			DeleteTextBox = new TextBox();
			DeleteButton = new Button();
			CancelButton = new Button();
			SearchCompanyDataGrid = new DataGridView();
			SearchButton = new Button();
			((System.ComponentModel.ISupportInitialize)SearchCompanyDataGrid).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
			label1.Location = new Point(21, 9);
			label1.Name = "label1";
			label1.Size = new Size(184, 25);
			label1.TabIndex = 0;
			label1.Text = "Удаление компании";
			// 
			// DeleteTextBox
			// 
			DeleteTextBox.Location = new Point(177, 57);
			DeleteTextBox.MaxLength = 12;
			DeleteTextBox.Name = "DeleteTextBox";
			DeleteTextBox.PlaceholderText = "ИНН или название";
			DeleteTextBox.Size = new Size(178, 23);
			DeleteTextBox.TabIndex = 2;
			DeleteTextBox.TextChanged += DeleteTextBox_TextChanged;
			// 
			// DeleteButton
			// 
			DeleteButton.Location = new Point(82, 145);
			DeleteButton.Name = "DeleteButton";
			DeleteButton.Size = new Size(101, 23);
			DeleteButton.TabIndex = 3;
			DeleteButton.Text = "Удалить";
			DeleteButton.UseVisualStyleBackColor = true;
			DeleteButton.Click += DeleteButton_Click;
			// 
			// CancelButton
			// 
			CancelButton.Location = new Point(237, 145);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(91, 23);
			CancelButton.TabIndex = 4;
			CancelButton.Text = "Отменить";
			CancelButton.UseVisualStyleBackColor = true;
			CancelButton.Click += CancelButton_Click;
			// 
			// SearchCompanyDataGrid
			// 
			SearchCompanyDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			SearchCompanyDataGrid.Location = new Point(24, 88);
			SearchCompanyDataGrid.Name = "SearchCompanyDataGrid";
			SearchCompanyDataGrid.RowTemplate.Height = 25;
			SearchCompanyDataGrid.Size = new Size(335, 51);
			SearchCompanyDataGrid.TabIndex = 5;
			// 
			// SearchButton
			// 
			SearchButton.Location = new Point(27, 56);
			SearchButton.Name = "SearchButton";
			SearchButton.Size = new Size(123, 23);
			SearchButton.TabIndex = 6;
			SearchButton.Text = "Найти";
			SearchButton.UseVisualStyleBackColor = true;
			SearchButton.Click += SearchButton_Click;
			// 
			// DeleteCompanyForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(430, 180);
			Controls.Add(SearchButton);
			Controls.Add(SearchCompanyDataGrid);
			Controls.Add(CancelButton);
			Controls.Add(DeleteButton);
			Controls.Add(DeleteTextBox);
			Controls.Add(label1);
			Name = "DeleteCompanyForm";
			Text = "DeleteCompanyForm";
			FormClosing += DeleteCompanyForm_FormClosing;
			((System.ComponentModel.ISupportInitialize)SearchCompanyDataGrid).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox DeleteTextBox;
		private Button DeleteButton;
		private Button CancelButton;
		private DataGridView SearchCompanyDataGrid;
		private Button SearchButton;
	}
}