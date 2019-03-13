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
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = source.Requests
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    DesignerId = rec.DesignerId,
                    DressId = rec.DressId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    DesignerFIO = source.Designers.FirstOrDefault(recC => recC.Id == rec.DesignerId)?.DesignerFIO,
                    DressName = source.Dresses.FirstOrDefault(recP => recP.Id == rec.DressId)?.DressName,
                })
                .ToList();
            return result;
        }

        public void CreateRequest(RequestBindingModel model)
        {
            int maxId = source.Requests.Count > 0 ? source.Requests.Max(rec => rec.Id) : 0;
            source.Requests.Add(new Request
            {
                Id = maxId + 1,
                DesignerId = model.DesignerId,
                DressId = model.DressId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = RequestStatus.Принят
            });
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            Request element = source.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != RequestStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
			// смотрим по количеству компонентов на складах
			var dressMaterials = source.DressMaterials.Where(rec => rec.DressId == element.DressId);
			foreach (var dressMaterial in dressMaterials)
			{
				int countOnStores = source.StoreMaterials
				.Where(rec => rec.MaterialId ==
				dressMaterial.MaterialId)
				.Sum(rec => rec.Count);
				if (countOnStores < dressMaterial.Count * element.Count)
				{
					var MaterialName = source.Materials.FirstOrDefault(rec => rec.Id ==
					dressMaterial.MaterialId);
					throw new Exception("Не достаточно компонента " +
					MaterialName?.MaterialName + " требуется " + (dressMaterial.Count * element.Count) +
					", в наличии " + countOnStores);
				}
			}
			// списываем
			foreach (var dressMaterial in dressMaterials)
			{
				int countOnStores = dressMaterial.Count * element.Count;
				var storeMaterials = source.StoreMaterials.Where(rec => rec.MaterialId
				== dressMaterial.MaterialId);
				foreach (var storeMaterial in storeMaterials)
				{
					// компонентов на одном слкаде может не хватать
					if (storeMaterial.Count >= countOnStores)
					{
						storeMaterial.Count -= countOnStores;
						break;
					}
					else
					{
						countOnStores -= storeMaterial.Count;
						storeMaterial.Count = 0;
					}
				}
			}
			element.DateImplement = DateTime.Now;
            element.Status = RequestStatus.Выполняется;
        }

        public void FinishRequest(RequestBindingModel model)
        {
            Request element = source.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != RequestStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = RequestStatus.Готов;
        }

        public void PayRequest(RequestBindingModel model)
        {
            Request element = source.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != RequestStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = RequestStatus.Оплачен;
        }

        public void PutMaterialInStore(StoreMaterialBindingModel model)
        {
            StoreMaterial element = source.StoreMaterials.FirstOrDefault(rec => rec.StoreId == model.StoreId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StoreMaterials.Count > 0 ? source.StoreMaterials.Max(rec => rec.Id) : 0;
                source.StoreMaterials.Add(new StoreMaterial
                {
                    Id = ++maxId,
                    StoreId = model.StoreId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
        }
    }
}
