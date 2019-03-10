namespace DressSewingView
{
    partial class FormMain
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dressIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dressNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateImplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonCreateOrder = new System.Windows.Forms.Button();
			this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
			this.buttonOrderReady = new System.Windows.Forms.Button();
			this.buttonPayOrder = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.orderViewModelBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
			this.orderViewModelBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.orderViewModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.orderViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(739, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// справочникиToolStripMenuItem
			// 
			this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// клиентыToolStripMenuItem
			// 
			this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
			this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.клиентыToolStripMenuItem.Text = "Клиенты";
			this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
			// 
			// компонентыToolStripMenuItem
			// 
			this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
			this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.компонентыToolStripMenuItem.Text = "Материалы";
			this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
			// 
			// изделияToolStripMenuItem
			// 
			this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
			this.изделияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.изделияToolStripMenuItem.Text = "Платья";
			this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dressIdDataGridViewTextBoxColumn,
            this.dressNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateCreateDataGridViewTextBoxColumn,
            this.dateImplementDataGridViewTextBoxColumn});
			this.dataGridView.Location = new System.Drawing.Point(12, 28);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(566, 256);
			this.dataGridView.TabIndex = 1;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			// 
			// dressIdDataGridViewTextBoxColumn
			// 
			this.dressIdDataGridViewTextBoxColumn.DataPropertyName = "DressId";
			this.dressIdDataGridViewTextBoxColumn.HeaderText = "DressId";
			this.dressIdDataGridViewTextBoxColumn.Name = "dressIdDataGridViewTextBoxColumn";
			// 
			// dressNameDataGridViewTextBoxColumn
			// 
			this.dressNameDataGridViewTextBoxColumn.DataPropertyName = "DressName";
			this.dressNameDataGridViewTextBoxColumn.HeaderText = "DressName";
			this.dressNameDataGridViewTextBoxColumn.Name = "dressNameDataGridViewTextBoxColumn";
			// 
			// countDataGridViewTextBoxColumn
			// 
			this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
			this.countDataGridViewTextBoxColumn.HeaderText = "Count";
			this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
			// 
			// sumDataGridViewTextBoxColumn
			// 
			this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
			this.sumDataGridViewTextBoxColumn.HeaderText = "Sum";
			this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
			// 
			// statusDataGridViewTextBoxColumn
			// 
			this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
			this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
			this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			// 
			// dateCreateDataGridViewTextBoxColumn
			// 
			this.dateCreateDataGridViewTextBoxColumn.DataPropertyName = "DateCreate";
			this.dateCreateDataGridViewTextBoxColumn.HeaderText = "DateCreate";
			this.dateCreateDataGridViewTextBoxColumn.Name = "dateCreateDataGridViewTextBoxColumn";
			// 
			// dateImplementDataGridViewTextBoxColumn
			// 
			this.dateImplementDataGridViewTextBoxColumn.DataPropertyName = "DateImplement";
			this.dateImplementDataGridViewTextBoxColumn.HeaderText = "DateImplement";
			this.dateImplementDataGridViewTextBoxColumn.Name = "dateImplementDataGridViewTextBoxColumn";
			// 
			// buttonCreateOrder
			// 
			this.buttonCreateOrder.Location = new System.Drawing.Point(585, 46);
			this.buttonCreateOrder.Name = "buttonCreateOrder";
			this.buttonCreateOrder.Size = new System.Drawing.Size(142, 23);
			this.buttonCreateOrder.TabIndex = 2;
			this.buttonCreateOrder.Text = "Сделать заказ";
			this.buttonCreateOrder.UseVisualStyleBackColor = true;
			this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
			// 
			// buttonTakeOrderInWork
			// 
			this.buttonTakeOrderInWork.Location = new System.Drawing.Point(585, 93);
			this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
			this.buttonTakeOrderInWork.Size = new System.Drawing.Size(142, 23);
			this.buttonTakeOrderInWork.TabIndex = 3;
			this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
			this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
			this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
			// 
			// buttonOrderReady
			// 
			this.buttonOrderReady.Location = new System.Drawing.Point(585, 142);
			this.buttonOrderReady.Name = "buttonOrderReady";
			this.buttonOrderReady.Size = new System.Drawing.Size(142, 23);
			this.buttonOrderReady.TabIndex = 4;
			this.buttonOrderReady.Text = "Заказ готов";
			this.buttonOrderReady.UseVisualStyleBackColor = true;
			this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
			// 
			// buttonPayOrder
			// 
			this.buttonPayOrder.Location = new System.Drawing.Point(585, 194);
			this.buttonPayOrder.Name = "buttonPayOrder";
			this.buttonPayOrder.Size = new System.Drawing.Size(142, 23);
			this.buttonPayOrder.TabIndex = 5;
			this.buttonPayOrder.Text = "Заказ оплачен";
			this.buttonPayOrder.UseVisualStyleBackColor = true;
			this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(585, 246);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(142, 23);
			this.buttonRef.TabIndex = 6;
			this.buttonRef.Text = "Обновить список";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
			// 
			// orderViewModelBindingSource3
			// 
			this.orderViewModelBindingSource3.DataSource = typeof(DressSewingServiceDAL.ViewModels.RequestViewModel);
			// 
			// orderViewModelBindingSource2
			// 
			this.orderViewModelBindingSource2.DataSource = typeof(DressSewingServiceDAL.ViewModels.RequestViewModel);
			// 
			// orderViewModelBindingSource1
			// 
			this.orderViewModelBindingSource1.DataSource = typeof(DressSewingServiceDAL.ViewModels.RequestViewModel);
			// 
			// orderViewModelBindingSource
			// 
			this.orderViewModelBindingSource.DataSource = typeof(DressSewingServiceDAL.ViewModels.RequestViewModel);
			// 
			// складыToolStripMenuItem
			// 
			this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
			this.складыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.складыToolStripMenuItem.Text = "Склады";
			this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
			// 
			// пополнитьСкладToolStripMenuItem
			// 
			this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
			this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
			this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
			this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 296);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonPayOrder);
			this.Controls.Add(this.buttonOrderReady);
			this.Controls.Add(this.buttonTakeOrderInWork);
			this.Controls.Add(this.buttonCreateOrder);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMain";
			this.Text = "Пошив платьев";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.orderViewModelBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonCreateOrder;
		private System.Windows.Forms.Button buttonTakeOrderInWork;
		private System.Windows.Forms.Button buttonOrderReady;
		private System.Windows.Forms.Button buttonPayOrder;
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientFIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dressIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dressNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateImplementDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderViewModelBindingSource3;
        private System.Windows.Forms.BindingSource orderViewModelBindingSource2;
        private System.Windows.Forms.BindingSource orderViewModelBindingSource1;
        private System.Windows.Forms.BindingSource orderViewModelBindingSource;
		private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
	}
}