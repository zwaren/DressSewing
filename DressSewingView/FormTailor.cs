using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DressSewingView
{
    public partial class FormTailor : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormTailor()
        {
            InitializeComponent();
        }

        private void FormTailor_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TailorViewModel client = APIClient.GetRequest<TailorViewModel>("api/Tailor/Get/" + id.Value);
                    textBoxFIO.Text = client.TailorFIO;
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
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<TailorBindingModel, bool>("api/Tailor/UpdElement", new TailorBindingModel
                    {
                        Id = id.Value,
                        TailorFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<TailorBindingModel, bool>("api/Tailor/AddElement", new TailorBindingModel
                    {
                        TailorFIO = textBoxFIO.Text
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
    }
}
