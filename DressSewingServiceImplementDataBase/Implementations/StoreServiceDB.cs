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
    public class StoreServiceDB : IStoreService
    {
        private AbstractDbContext context;

        public StoreServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void AddElement(StoreBindingModel model)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.StoreName == model.StoreName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Stores.Add(new Store
            {
                StoreName = model.StoreName
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Stores.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public StoreViewModel GetElement(int id)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StoreViewModel
                {
                    Id = element.Id,
                    StoreName = element.StoreName,
                    StoreMaterials = context.StoreMaterials
                        .Where(x => x.StoreId == element.Id)
                        .Select(mat => new StoreMaterialViewModel
                        {
                            Id = mat.Id,
                            StoreId = mat.StoreId,
                            MaterialId = mat.MaterialId,
                            MaterialName = mat.Material.MaterialName,
                            Count = mat.Count
                        })
                        .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<StoreViewModel> GetList()
        {
            List<StoreViewModel> result = context.Stores.Select(rec => new StoreViewModel
            {
                Id = rec.Id,
                StoreName = rec.StoreName,
                StoreMaterials = context.StoreMaterials
                    .Where(x => x.StoreId == rec.Id)
                    .Select(mat => new StoreMaterialViewModel
                    {
                        Id = mat.Id,
                        StoreId = mat.StoreId,
                        MaterialId = mat.MaterialId,
                        MaterialName = mat.Material.MaterialName,
                        Count = mat.Count
                    })
                    .ToList()

            })
            .ToList();
            return result;
        }

        public void UpdElement(StoreBindingModel model)
        {
            Store element = context.Stores.FirstOrDefault(rec => rec.StoreName == model.StoreName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Stores.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StoreName = model.StoreName;
            context.SaveChanges();
        }
    }
}
