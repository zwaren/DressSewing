using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;

namespace DressSewingServiceImplementDataBase.Implementations
{
	class MaterialServiceDB : IMaterialService
	{
		private AbstractDbContext context;

		public MaterialServiceDB(AbstractDbContext context)
		{
			this.context = context;
		}

		public void AddElement(MaterialBindingModel model)
		{
			Material element = context.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName);
			if (element != null)
			{
				throw new Exception("Уже есть клиент с таким ФИО");
			}
			context.Materials.Add(new Material
			{
				MaterialName = model.MaterialName
			});
			context.SaveChanges();
		}

		public void DelElement(int id)
		{
			Material element = context.Materials.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				context.Materials.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		public MaterialViewModel GetElement(int id)
		{
			Material element = context.Materials.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				return new MaterialViewModel
				{
					Id = element.Id,
					MaterialName = element.MaterialName
				};
			}
			throw new Exception("Элемент не найден");
		}

		public List<MaterialViewModel> GetList()
		{
			List<MaterialViewModel> result = context.Materials.Select(rec => new MaterialViewModel
			{
				Id = rec.Id,
				MaterialName = rec.MaterialName
			})
			.ToList();
			return result;
		}

		public void UpdElement(MaterialBindingModel model)
		{
			Material element = context.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть клиент с таким ФИО");
			}
			element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.MaterialName = model.MaterialName;
			context.SaveChanges();
		}
	}
}
