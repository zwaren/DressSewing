namespace DressSewingView
{
	partial class FormPutInStore
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxStore = new System.Windows.Forms.ComboBox();
			this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Склад:";
			// 
			// comboBoxStore
			// 
			this.comboBoxStore.FormattingEnabled = true;
			this.comboBoxStore.Location = new System.Drawing.Point(87, 12);
			this.comboBoxStore.Name = "comboBoxStore";
			this.comboBoxStore.Size = new System.Drawing.Size(198, 21);
			this.comboBoxStore.TabIndex = 1;
			// 
			// comboBoxMaterial
			// 
			this.comboBoxMaterial.FormattingEnabled = true;
			this.comboBoxMaterial.Location = new System.Drawing.Point(87, 39);
			this.comboBoxMaterial.Name = "comboBoxMaterial";
			this.comboBoxMaterial.Size = new System.Drawing.Size(198, 21);
			this.comboBoxMaterial.TabIndex = 2;
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(87, 66);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(198, 20);
			this.textBoxCount.TabIndex = 3;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(210, 93);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(129, 93);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Материал:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Количество:";
			// 
			// FormPutInStore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(297, 126);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.comboBoxMaterial);
			this.Controls.Add(this.comboBoxStore);
			this.Controls.Add(this.label1);
			this.Name = "FormPutInStore";
			this.Text = "FormPutInStore";
			this.Load += new System.EventHandler(this.FormPutInStore_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxStore;
		private System.Windows.Forms.ComboBox comboBoxMaterial;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}