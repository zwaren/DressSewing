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
	public partial class FormPutInStore : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		private readonly IStoreService serviceS;

		private readonly IMaterialService serviceC;

		private readonly IMainService serviceM;

		public FormPutInStore(IStoreService serviceS, IMaterialService serviceC, IMainService serviceM)
		{
			InitializeComponent();
			this.serviceS = serviceS;
			this.serviceC = serviceC;
			this.serviceM = serviceM;
		}

		private void FormPutInStore_Load(object sender, EventArgs e)
		{
			try
			{
				List<MaterialViewModel> listC = serviceC.GetList();
				if (listC != null)
				{
					comboBoxMaterial.DisplayMember = "MaterialName";
					comboBoxMaterial.ValueMember = "Id";
					comboBoxMaterial.DataSource = listC;
					comboBoxMaterial.SelectedItem = null;
				}
				List<StoreViewModel> listS = serviceS.GetList();
				if (listS != null)
				{
					comboBoxStore.DisplayMember = "StoreName";
					comboBoxStore.ValueMember = "Id";
					comboBoxStore.DataSource = listS;
					comboBoxStore.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxMaterial.SelectedValue == null)
			{
				MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			if (comboBoxStore.SelectedValue == null)
			{
				MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			try
			{
				serviceM.PutMaterialInStore(new StoreMaterialBindingModel
				{
					MaterialId = Convert.ToInt32(comboBoxMaterial.SelectedValue),
					StoreId = Convert.ToInt32(comboBoxStore.SelectedValue),
					Count = Convert.ToInt32(textBoxCount.Text)
				});
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
