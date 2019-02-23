namespace DressSewingView
{
    partial class FormDressMaterial
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.dressMaterialViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.materialViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dressMaterialViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.DataSource = this.materialViewModelBindingSource;
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(84, 12);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(213, 21);
            this.comboBoxMaterial.TabIndex = 0;
            // 
            // dressMaterialViewModelBindingSource
            // 
            this.dressMaterialViewModelBindingSource.DataSource = typeof(DressSewingServiceDAL.ViewModels.DressMaterialViewModel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Материал:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(84, 40);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(212, 20);
            this.textBoxCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(220, 67);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(139, 67);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // materialViewModelBindingSource
            // 
            this.materialViewModelBindingSource.DataSource = typeof(DressSewingServiceDAL.ViewModels.MaterialViewModel);
            // 
            // FormDressMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 102);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMaterial);
            this.Name = "FormDressMaterial";
            this.Text = "Материалы платья";
            this.Load += new System.EventHandler(this.FormDressMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dressMaterialViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.ComboBox comboBoxMaterial;
		private System.Windows.Forms.BindingSource dressMaterialViewModelBindingSource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource materialViewModelBindingSource;
    }
}