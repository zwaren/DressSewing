namespace DressSewingView
{
    partial class FormStore
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
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.storeMaterialViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.storeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.materialIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.materialNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.storeMaterialViewModelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(78, 13);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Название:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridView);
			this.groupBox1.Location = new System.Drawing.Point(12, 39);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(389, 316);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Материалы";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(326, 362);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(245, 362);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AutoGenerateColumns = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.storeIdDataGridViewTextBoxColumn,
            this.materialIdDataGridViewTextBoxColumn,
            this.materialNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn});
			this.dataGridView.DataSource = this.storeMaterialViewModelBindingSource;
			this.dataGridView.Location = new System.Drawing.Point(7, 20);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(376, 290);
			this.dataGridView.TabIndex = 0;
			// 
			// storeMaterialViewModelBindingSource
			// 
			this.storeMaterialViewModelBindingSource.DataSource = typeof(DressSewingServiceDAL.ViewModels.StoreMaterialViewModel);
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			// 
			// storeIdDataGridViewTextBoxColumn
			// 
			this.storeIdDataGridViewTextBoxColumn.DataPropertyName = "StoreId";
			this.storeIdDataGridViewTextBoxColumn.HeaderText = "StoreId";
			this.storeIdDataGridViewTextBoxColumn.Name = "storeIdDataGridViewTextBoxColumn";
			// 
			// materialIdDataGridViewTextBoxColumn
			// 
			this.materialIdDataGridViewTextBoxColumn.DataPropertyName = "MaterialId";
			this.materialIdDataGridViewTextBoxColumn.HeaderText = "MaterialId";
			this.materialIdDataGridViewTextBoxColumn.Name = "materialIdDataGridViewTextBoxColumn";
			// 
			// materialNameDataGridViewTextBoxColumn
			// 
			this.materialNameDataGridViewTextBoxColumn.DataPropertyName = "MaterialName";
			this.materialNameDataGridViewTextBoxColumn.HeaderText = "Название компонента";
			this.materialNameDataGridViewTextBoxColumn.Name = "materialNameDataGridViewTextBoxColumn";
			// 
			// countDataGridViewTextBoxColumn
			// 
			this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
			this.countDataGridViewTextBoxColumn.HeaderText = "Количество";
			this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
			// 
			// FormStore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 397);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxName);
			this.Name = "FormStore";
			this.Text = "FormStore";
			this.Load += new System.EventHandler(this.FormStore_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.storeMaterialViewModelBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn storeIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn materialIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn materialNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource storeMaterialViewModelBindingSource;
	}
}