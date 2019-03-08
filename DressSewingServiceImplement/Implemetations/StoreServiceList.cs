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
    class StoreServiceList : IStoreService
    {
        private DataListSingleton source;
        public StoreServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StoreViewModel> GetList()
        {
            List<StoreViewModel> result = source.Stores
            .Select(rec => new StoreViewModel
            {
                Id = rec.Id,
                StoreName = rec.StoreName,
                StoreMaterials = source.StoreMaterials
					.Where(recPC => recPC.StoreId == rec.Id)
					.Select(recPC => new StoreMaterialViewModel
					{
						Id = recPC.Id,
						StoreId = recPC.StoreId,
						MaterialId = recPC.MaterialId,
						MaterialName = source.Materials
							.FirstOrDefault(recC => recC.Id == recPC.MaterialId)?.MaterialName,
						Count = recPC.Count
					})
					.ToList()
            })
            .ToList();
            return result;
        }

        public StoreViewModel GetElement(int id)
        {
            Store element = source.Stores.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StoreViewModel
                {
                    Id = element.Id,
                    StoreName = element.StoreName,
                    StoreMaterials = source.StoreMaterials
						.Where(recPC => recPC.StoreId == element.Id)
						.Select(recPC => new StoreMaterialViewModel
						{
							Id = recPC.Id,
							StoreId = recPC.StoreId,
							MaterialId = recPC.MaterialId,
							MaterialName = source.Materials
								.FirstOrDefault(recC => recC.Id == recPC.MaterialId)?.MaterialName,
							Count = recPC.Count
						})
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StoreBindingModel model)
        {
            Store element = source.Stores.FirstOrDefault(rec => rec.StoreName == model.StoreName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Stores.Count > 0 ? source.Stores.Max(rec => rec.Id) : 0;
            source.Stores.Add(new Store
            {
                Id = maxId + 1,
                StoreName = model.StoreName
            });
        }
        public void UpdElement(StoreBindingModel model)
        {
            Store element = source.Stores.FirstOrDefault(rec =>
            rec.StoreName == model.StoreName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Stores.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StoreName = model.StoreName;
        }

        public void DelElement(int id)
        {
            Store element = source.Stores.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.StoreMaterials.RemoveAll(rec => rec.StoreId == id);
                source.Stores.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
