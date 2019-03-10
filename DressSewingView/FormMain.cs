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
using DressSewingServiceDAL.ViewModels;
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
            try
            {
                List<RequestViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormDesigners>();
			form.ShowDialog();
		}

		private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormMaterials>();
			form.ShowDialog();
		}

		private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormDresses>();
			form.ShowDialog();
		}

		private void buttonCreateOrder_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormCreateRequest>();
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
					service.TakeRequestInWork(new RequestBindingModel { Id = id });
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
					service.FinishRequest(new RequestBindingModel { Id = id });
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
					service.PayRequest(new RequestBindingModel { Id = id });
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

		private void складыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormStores>();
			form.ShowDialog();
		}

		private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormPutInStore>();
			form.ShowDialog();
		}
	}
}
