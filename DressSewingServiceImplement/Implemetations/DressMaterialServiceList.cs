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
    public class DressMaterialServiceList : IDressMaterialService
    {
        private DataListSingleton source;

        public DressMaterialServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(DressMaterialBindingModel model)
        {
			DressMaterial element = source.DressMaterials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName);
			if (element != null)
			{
				throw new Exception("Уже есть материал с таким именем");
			}
			int maxId = source.DressMaterials.Count > 0 ? source.DressMaterials.Max(rec => rec.Id) : 0;
			source.DressMaterials.Add(new DressMaterial
			{
				Id = maxId + 1,
				DressId = model.DressId,
				MaterialId = model.MaterialId,
				Count = model.Count,
				MaterialName = model.MaterialName
			});
        }

        public void DelElement(int id)
        {
			DressMaterial element = source.DressMaterials.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				source.DressMaterials.Remove(element);
			}
			else throw new Exception("Элемент не найден");
		}

        public DressMaterialViewModel GetElement(int id)
        {
			DressMaterial element = source.DressMaterials.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				return new DressMaterialViewModel
				{
					Id = element.Id,
					DressId = element.DressId,
					MaterialId = element.MaterialId,
					Count = element.Count,
					MaterialName = element.MaterialName
				};
			}
			throw new Exception("Элемент не найден");
        }

        public List<DressMaterialViewModel> GetList()
        {
			List<DressMaterialViewModel> result = source.DressMaterials.Select(rec => new DressMaterialViewModel
			{
				Id = rec.Id,
				DressId = rec.DressId,
				MaterialId = rec.MaterialId,
				Count = rec.Count,
				MaterialName = rec.MaterialName
			})
			.ToList();
			return result;
        }

        public void UpdElement(DressMaterialBindingModel model)
        {
			DressMaterial element = source.DressMaterials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть материал с таким именем");
			}
			element = source.DressMaterials.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.MaterialName = model.MaterialName;
        }
    }
}
