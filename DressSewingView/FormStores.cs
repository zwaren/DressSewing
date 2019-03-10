using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using Unity;

namespace DressSewingView
{
    public partial class FormStores : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }

		private readonly IStoreService service;

		public FormStores(IStoreService service)
        {
            InitializeComponent();
			this.service = service;
		}

		private void FormStores_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				List<StoreViewModel> list = service.GetList();
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[1].AutoSizeMode =
					DataGridViewAutoSizeColumnMode.Fill;
					dataGridView.Columns[2].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormStore>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void buttonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = Container.Resolve<FormStore>();
				form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void buttonDel_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id =
					Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
					try
					{
						service.DelElement(id);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					}
					LoadData();
				}
			}
		}

		private void buttonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
