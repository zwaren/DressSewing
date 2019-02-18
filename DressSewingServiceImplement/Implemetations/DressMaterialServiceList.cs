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
            int maxId = 0;
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].Id > maxId)
                {
                    maxId = source.DressMaterials[i].Id;
                }
                if (source.DressMaterials[i].MaterialName == model.MaterialName)
                {
                    throw new Exception("Уже есть материал с таким именем");
                }
            }
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
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].Id == id)
                {
                    source.DressMaterials.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public DressMaterialViewModel GetElement(int id)
        {
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].Id == id)
                {
                    return new DressMaterialViewModel
                    {
                        Id = source.DressMaterials[i].Id,
                        MaterialName = source.DressMaterials[i].MaterialName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<DressMaterialViewModel> GetList()
        {
            List<DressMaterialViewModel> result = new List<DressMaterialViewModel>();
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                result.Add(new DressMaterialViewModel
                {
                    Id = source.DressMaterials[i].Id,
                    DressId = source.DressMaterials[i].DressId,
                    MaterialId = source.DressMaterials[i].MaterialId,
                    Count = source.DressMaterials[i].Count,
                    MaterialName = source.DressMaterials[i].MaterialName
                });
            }
            return result;
        }

        public void UpdElement(DressMaterialBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.DressMaterials[i].MaterialName == model.MaterialName &&
                source.DressMaterials[i].Id != model.Id)
                {
                    throw new Exception("Уже есть материал с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.DressMaterials[index].MaterialName = model.MaterialName;
        }
    }
}
