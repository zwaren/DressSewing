using System;
using System.Collections.Generic;
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
    public partial class FormDress : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { id = value; } }

		private readonly IDressService service;

		private int? id;

		private List<DressMaterialViewModel> DressMaterials;

		public FormDress(IDressService service)
        {
            InitializeComponent();
			this.service = service;
		}

		private void FormDress_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
					DressViewModel view = service.GetElement(id.Value);
					if (view != null)
					{
						textBoxName.Text = view.DressName;
						textBoxPrice.Text = view.Price.ToString();
						DressMaterials = view.DressMaterials;
						LoadData();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
			else
			{
				DressMaterials = new List<DressMaterialViewModel>();
			}
		}

		private void LoadData()
		{
			try
			{
				if (DressMaterials != null)
				{
					dataGridView.DataSource = null;
					dataGridView.DataSource = DressMaterials;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[1].Visible = false;
					dataGridView.Columns[2].Visible = false;
					dataGridView.Columns[3].AutoSizeMode =
					DataGridViewAutoSizeColumnMode.Fill;
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
			var form = Container.Resolve<FormDressMaterial>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (form.Model != null)
				{
					if (id.HasValue)
					{
						form.Model.DressId = id.Value;
					}
					DressMaterials.Add(form.Model);
				}
				LoadData();
			}
		}

		private void buttonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = Container.Resolve<FormDressMaterial>();
				form.Model =
				DressMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex];
				if (form.ShowDialog() == DialogResult.OK)
				{
					DressMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
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
					try
					{
						DressMaterials.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
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

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBoxPrice.Text))
			{
				MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			if (DressMaterials == null || DressMaterials.Count == 0)
			{
				MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			try
			{
				List<DressMaterialBindingModel> DressMaterialBM = new
				List<DressMaterialBindingModel>();
				for (int i = 0; i < DressMaterials.Count; ++i)
				{
					DressMaterialBM.Add(new DressMaterialBindingModel
					{
						Id = DressMaterials[i].Id,
						DressId = DressMaterials[i].DressId,
						MaterialId = DressMaterials[i].MaterialId,
						Count = DressMaterials[i].Count
					});
				}
				if (id.HasValue)
				{
					service.UpdElement(new DressBindingModel
					{
						Id = id.Value,
						DressName = textBoxName.Text,
						Price = Convert.ToInt32(textBoxPrice.Text),
						DressMaterials = DressMaterialBM
					});
				}
				else
				{
					service.AddElement(new DressBindingModel
					{
						DressName = textBoxName.Text,
						Price = Convert.ToInt32(textBoxPrice.Text),
						DressMaterials = DressMaterialBM
					});
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
