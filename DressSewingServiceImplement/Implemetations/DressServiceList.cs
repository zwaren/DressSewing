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
    public class DressServiceList : IDressService
    {
        private DataListSingleton source;
        public DressServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<DressViewModel> GetList()
        {
            List<DressViewModel> result = source.Dresses
                .Select(rec => new DressViewModel
                {
                    Id = rec.Id,
                    DressName = rec.DressName,
                    Price = rec.Price,
                    DressMaterials = source.DressMaterials
                        .Where(recPC => recPC.DressId == rec.Id)
                        .Select(recPC => new DressMaterialViewModel
                        {
                            Id = recPC.Id,
                            DressId = recPC.DressId,
                            MaterialId = recPC.MaterialId,
                            MaterialName = source.Materials.FirstOrDefault(recC => recC.Id == recPC.MaterialId)?.MaterialName,
                            Count = recPC.Count
                        })
                        .ToList()
                })
                .ToList();
            return result;
        }

        public DressViewModel GetElement(int id)
        {
            Dress element = source.Dresses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new DressViewModel
                {
                    Id = element.Id,
                    DressName = element.DressName,
                    Price = element.Price,
                    DressMaterials = source.DressMaterials
                        .Where(recPC => recPC.DressId == element.Id)
                        .Select(recPC => new DressMaterialViewModel
                        {
                            Id = recPC.Id,
                            DressId = recPC.DressId,
                            MaterialId = recPC.MaterialId,
                            MaterialName = source.Materials.FirstOrDefault(recC => recC.Id == recPC.MaterialId)?.MaterialName,
                            Count = recPC.Count
                        })
                        .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DressBindingModel model)
        {
            Dress element = source.Dresses.FirstOrDefault(rec => rec.DressName == model.DressName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Dresses.Count > 0 ? source.Dresses.Max(rec => rec.Id) : 0;
            source.Dresses.Add(new Dress
            {
                Id = maxId + 1,
                DressName = model.DressName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.DressMaterials.Count > 0 ? source.DressMaterials.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.DressMaterials
                .GroupBy(rec => rec.MaterialId)
                .Select(rec => new
                {
                    MaterialId = rec.Key,
                    Count = rec.Sum(r => r.Count)
                });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents)
            {
                source.DressMaterials.Add(new DressMaterial
                {
                    Id = ++maxPCId,
                    DressId = maxId + 1,
                    MaterialId = groupComponent.MaterialId,
                    Count = groupComponent.Count
                });
            }
        }

        public void UpdElement(DressBindingModel model)
        {
            Dress element = source.Dresses.FirstOrDefault(rec => rec.DressName == model.DressName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Dresses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.DressName = model.DressName;
            element.Price = model.Price;
            int maxPCId = source.DressMaterials.Count > 0 ? source.DressMaterials.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.DressMaterials.Select(rec => rec.MaterialId).Distinct();
            var updateComponents = source.DressMaterials.Where(rec => rec.DressId == model.Id && compIds.Contains(rec.MaterialId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.DressMaterials.FirstOrDefault(rec => rec.Id == updateComponent.Id).Count;
            }
            source.DressMaterials.RemoveAll(rec => rec.DressId == model.Id && !compIds.Contains(rec.MaterialId));
            // новые записи
            var groupComponents = model.DressMaterials
                .Where(rec => rec.Id == 0)
                .GroupBy(rec => rec.MaterialId)
                .Select(rec => new
                {
                    MaterialId = rec.Key,
                    Count = rec.Sum(r => r.Count)
                });
            foreach (var groupComponent in groupComponents)
            {
                DressMaterial elementPC = source.DressMaterials.FirstOrDefault(rec => rec.DressId == model.Id && rec.MaterialId == groupComponent.MaterialId);
                if (elementPC != null)
                {
                    elementPC.Count += groupComponent.Count;
                }
                else
                {
                    source.DressMaterials.Add(new DressMaterial
                    {
                        Id = ++maxPCId,
                        DressId = model.Id,
                        MaterialId = groupComponent.MaterialId,
                        Count = groupComponent.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Dress element = source.Dresses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.DressMaterials.RemoveAll(rec => rec.DressId == id);
                source.Dresses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
