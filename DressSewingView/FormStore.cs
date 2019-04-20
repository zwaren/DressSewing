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

namespace DressSewingView
{
    public partial class FormStore : Form
    {
		public int Id { set { id = value; } }
        
		private int? id;

		public FormStore()
        {
            InitializeComponent();
		}

		private void FormStore_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
                    StoreViewModel client = APIClient.GetRequest<StoreViewModel>("api/Store/Get/" + id.Value);
                    if (client != null)
					{
						textBoxName.Text = client.StoreName;
						dataGridView.DataSource = client.StoreMaterials;
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
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			try
			{
				if (id.HasValue)
				{
                    APIClient.PostRequest<StoreBindingModel, bool>("api/Store/UpdElement", new StoreBindingModel
                    {
                        Id = id.Value,
                        StoreName = textBoxName.Text
                    });
				}
				else
				{
                    APIClient.PostRequest<StoreBindingModel, bool>("api/Store/AddElement", new StoreBindingModel
                    {
                        StoreName = textBoxName.Text
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
