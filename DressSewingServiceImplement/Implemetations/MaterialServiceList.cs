using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplement.Implemetations
{
    public class MaterialServiceList : IMaterialService
    {
        private DataListSingleton source;

        public MaterialServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(MaterialBindingModel model)
        {
			Material element = source.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName);
			if (element != null)
			{
				throw new Exception("Уже есть материал с таким именем");
			}
			int maxId = source.Materials.Count > 0 ? source.Materials.Max(rec => rec.Id) : 0;
			source.Materials.Add(new Material
			{
				Id = maxId + 1,
				MaterialName = model.MaterialName
			});
        }

        public void DelElement(int id)
        {
			Material element = source.Materials.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				source.Materials.Remove(element);
			}
			else throw new Exception("Элемент не найден");
        }

        public MaterialViewModel GetElement(int id)
        {
			Material element = source.Materials.FirstOrDefault(rec => rec.Id == id);
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
			List<MaterialViewModel> result = source.Materials.Select(rec => new MaterialViewModel
			{
				Id = rec.Id,
				MaterialName = rec.MaterialName
			})
			.ToList();
			return result;
        }

        public void UpdElement(MaterialBindingModel model)
        {
			Material element = source.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть материал с таким именем");
			}
			element = source.Materials.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.MaterialName = model.MaterialName;
        }
    }
}
