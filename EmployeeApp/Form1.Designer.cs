﻿namespace EmployeeApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			pictureBox1 = new PictureBox();
			CreateCompanyButton = new Button();
			AddEmployeesButton = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(174, 26);
			label1.Name = "label1";
			label1.Size = new Size(164, 90);
			label1.TabIndex = 0;
			label1.Text = "Система \r\nуправления \r\nпредприятием\r\n";
			label1.Click += label1_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(26, 35);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(123, 81);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// CreateCompanyButton
			// 
			CreateCompanyButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			CreateCompanyButton.Location = new Point(48, 156);
			CreateCompanyButton.Name = "CreateCompanyButton";
			CreateCompanyButton.Size = new Size(304, 39);
			CreateCompanyButton.TabIndex = 2;
			CreateCompanyButton.Text = "Создать организацию";
			CreateCompanyButton.UseVisualStyleBackColor = true;
			// 
			// AddEmployeesButton
			// 
			AddEmployeesButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			AddEmployeesButton.Location = new Point(48, 213);
			AddEmployeesButton.Name = "AddEmployeesButton";
			AddEmployeesButton.Size = new Size(304, 39);
			AddEmployeesButton.TabIndex = 3;
			AddEmployeesButton.Text = "Добавить сотрудников";
			AddEmployeesButton.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(404, 294);
			Controls.Add(AddEmployeesButton);
			Controls.Add(CreateCompanyButton);
			Controls.Add(pictureBox1);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private PictureBox pictureBox1;
		private Button CreateCompanyButton;
		private Button AddEmployeesButton;
	}
}