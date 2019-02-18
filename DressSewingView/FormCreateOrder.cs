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
    public partial class FormCreateOrder : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }

		private readonly IClientService serviceC;

		private readonly IDressService serviceP;

		private readonly IMainService serviceM;

		public FormCreateOrder(IClientService serviceC, IDressService serviceP, IMainService serviceM)
		{
			InitializeComponent();
			this.serviceC = serviceC;
			this.serviceP = serviceP;
			this.serviceM = serviceM;
		}

		private void FormCreateOrder_Load(object sender, EventArgs e)
		{
			try
			{
				List<ClientViewModel> listC = serviceC.GetList();
				if (listC != null)
				{
					comboBoxClient.DisplayMember = "ClientFIO";
					comboBoxClient.ValueMember = "Id";
					comboBoxClient.DataSource = listC;
					comboBoxClient.SelectedItem = null;
				}
				List<DressViewModel> listP = serviceP.GetList();
				if (listP != null)
				{
					comboBoxDress.DisplayMember = "DressName";
					comboBoxDress.ValueMember = "Id";
					comboBoxDress.DataSource = listP;
					comboBoxDress.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}

		private void CalcSum()
		{
			if (comboBoxDress.SelectedValue != null &&
			!string.IsNullOrEmpty(textBoxCount.Text))
			{
				try
				{
					int id = Convert.ToInt32(comboBoxDress.SelectedValue);
					DressViewModel Dress = serviceP.GetElement(id);
					int count = Convert.ToInt32(textBoxCount.Text);
					textBoxSum.Text = (count * Dress.Price).ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
		}

		private void textBoxCount_TextChanged(object sender, EventArgs e)
		{
			CalcSum();
		}

		private void comboBoxDress_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalcSum();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxClient.SelectedValue == null)
			{
				MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			if (comboBoxDress.SelectedValue == null)
			{
				MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			try
			{
				serviceM.CreateOrder(new OrderBindingModel
				{
					ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
					DressId = Convert.ToInt32(comboBoxDress.SelectedValue),
					Count = Convert.ToInt32(textBoxCount.Text),
					Sum = Convert.ToInt32(textBoxSum.Text)
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
