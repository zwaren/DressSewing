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
    public partial class FormClient : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { id = value; } }

		private readonly IClientService service;

		private int? id;

		public FormClient(IClientService service)
        {
            InitializeComponent();
			this.service = service;
        }

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxFIO.Text))
			{
				MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}
			try
			{
				if (id.HasValue)
				{
					service.UpdElement(new ClientBindingModel
					{
						Id = id.Value,
						ClientFIO = textBoxFIO.Text
					});
				}
				else
				{
					service.AddElement(new ClientBindingModel
					{
						ClientFIO = textBoxFIO.Text
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

		private void FormClient_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
					ClientViewModel view = service.GetElement(id.Value);
					if (view != null)
					{
						textBoxFIO.Text = view.ClientFIO;
					}
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
