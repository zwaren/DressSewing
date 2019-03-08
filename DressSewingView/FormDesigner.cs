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
    public partial class FormDesigner : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { id = value; } }

		private readonly IDesignerService service;

		private int? id;

		public FormDesigner(IDesignerService service)
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
					service.UpdElement(new DesignerBindingModel
					{
						Id = id.Value,
						DesignerFIO = textBoxFIO.Text
					});
				}
				else
				{
					service.AddElement(new DesignerBindingModel
					{
						DesignerFIO = textBoxFIO.Text
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

		private void FormDesigner_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
					DesignerViewModel view = service.GetElement(id.Value);
					if (view != null)
					{
						textBoxFIO.Text = view.DesignerFIO;
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
