namespace DressSewingView
{
    partial class FormCreateOrder
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
			this.comboBoxClient = new System.Windows.Forms.ComboBox();
			this.comboBoxProduct = new System.Windows.Forms.ComboBox();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.textBoxSum = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBoxClient
			// 
			this.comboBoxClient.FormattingEnabled = true;
			this.comboBoxClient.Location = new System.Drawing.Point(87, 12);
			this.comboBoxClient.Name = "comboBoxClient";
			this.comboBoxClient.Size = new System.Drawing.Size(212, 21);
			this.comboBoxClient.TabIndex = 0;
			// 
			// comboBoxProduct
			// 
			this.comboBoxProduct.FormattingEnabled = true;
			this.comboBoxProduct.Location = new System.Drawing.Point(87, 40);
			this.comboBoxProduct.Name = "comboBoxProduct";
			this.comboBoxProduct.Size = new System.Drawing.Size(212, 21);
			this.comboBoxProduct.TabIndex = 1;
			this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(87, 68);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(212, 20);
			this.textBoxCount.TabIndex = 2;
			this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
			// 
			// textBoxSum
			// 
			this.textBoxSum.Location = new System.Drawing.Point(87, 95);
			this.textBoxSum.Name = "textBoxSum";
			this.textBoxSum.ReadOnly = true;
			this.textBoxSum.Size = new System.Drawing.Size(212, 20);
			this.textBoxSum.TabIndex = 3;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(224, 121);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(143, 121);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Клиент:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Изделие:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Количество:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Сумма:";
			// 
			// FormCreateOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(311, 158);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxSum);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.comboBoxProduct);
			this.Controls.Add(this.comboBoxClient);
			this.Name = "FormCreateOrder";
			this.Text = "FormCreateOrder";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.ComboBox comboBoxClient;
		private System.Windows.Forms.ComboBox comboBoxProduct;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.TextBox textBoxSum;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}