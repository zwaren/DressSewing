using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using Unity;

namespace DressSewingView
{
    public partial class FormMain : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }

		private readonly IMainService service;

		public FormMain(IMainService service)
		{
			InitializeComponent();
			this.service = service;
		}
		private void LoadData()
		{
			
		}

		private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormClients>();
			form.ShowDialog();
		}

		private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormDressMaterial>();
			form.ShowDialog();
		}

		private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormDress>();
			form.ShowDialog();
		}

		private void buttonCreateOrder_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormCreateOrder>();
			form.ShowDialog();
			LoadData();
		}

		private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					service.TakeOrderInWork(new OrderBindingModel { Id = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
		}

		private void buttonOrderReady_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					service.FinishOrder(new OrderBindingModel { Id = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
		}

		private void buttonPayOrder_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					service.PayOrder(new OrderBindingModel { Id = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
		}

		private void buttonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
