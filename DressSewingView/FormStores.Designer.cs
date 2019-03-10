namespace DressSewingView
{
    partial class FormStores
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
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.storeViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.storeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.storeViewModelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(447, 33);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 0;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(447, 87);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(75, 23);
			this.buttonUpd.TabIndex = 1;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(447, 138);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(75, 23);
			this.buttonDel.TabIndex = 2;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(447, 196);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(75, 23);
			this.buttonRef.TabIndex = 3;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AutoGenerateColumns = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.storeNameDataGridViewTextBoxColumn});
			this.dataGridView.DataSource = this.storeViewModelBindingSource;
			this.dataGridView.Location = new System.Drawing.Point(13, 13);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(428, 394);
			this.dataGridView.TabIndex = 4;
			// 
			// storeViewModelBindingSource
			// 
			this.storeViewModelBindingSource.DataSource = typeof(DressSewingServiceDAL.ViewModels.StoreViewModel);
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			// 
			// storeNameDataGridViewTextBoxColumn
			// 
			this.storeNameDataGridViewTextBoxColumn.DataPropertyName = "StoreName";
			this.storeNameDataGridViewTextBoxColumn.HeaderText = "Название склада";
			this.storeNameDataGridViewTextBoxColumn.Name = "storeNameDataGridViewTextBoxColumn";
			// 
			// FormStores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 419);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonAdd);
			this.Name = "FormStores";
			this.Text = "FormStores";
			this.Load += new System.EventHandler(this.FormStores_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.storeViewModelBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonUpd;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn storeNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource storeViewModelBindingSource;
	}
}