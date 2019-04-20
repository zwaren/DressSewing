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
    public partial class FormDesigner : Form
    {
		public int Id { set { id = value; } }

		private int? id;

		public FormDesigner()
        {
            InitializeComponent();
        }

		private void buttonSave_Click(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<DesignerBindingModel, bool>("api/Designer/UpdElement", new DesignerBindingModel
                    {
                        Id = id.Value,
                        DesignerFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<DesignerBindingModel, bool>("api/Designer/AddElement", new DesignerBindingModel
                    {
                        DesignerFIO = textBoxFIO.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void FormDesigner_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
                    DesignerViewModel client = APIClient.GetRequest<DesignerViewModel>("api/Designer/Get/" + id.Value);
                    textBoxFIO.Text = client.DesignerFIO;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
		}
	}
}
