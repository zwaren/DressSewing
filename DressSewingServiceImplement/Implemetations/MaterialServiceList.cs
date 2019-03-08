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
            int maxId = 0;
            for (int i = 0; i < source.Materials.Count; ++i)
            {
                if (source.Materials[i].Id > maxId)
                {
                    maxId = source.Materials[i].Id;
                }
                if (source.Materials[i].MaterialName == model.MaterialName)
                {
                    throw new Exception("Уже есть материал с таким именем");
                }
            }
            source.Materials.Add(new Material
            {
                Id = maxId + 1,
                MaterialName = model.MaterialName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Materials.Count; ++i)
            {
                if (source.Materials[i].Id == id)
                {
                    source.Materials.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public MaterialViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Materials.Count; ++i)
            {
                if (source.Materials[i].Id == id)
                {
                    return new MaterialViewModel
                    {
                        Id = source.Materials[i].Id,
                        MaterialName = source.Materials[i].MaterialName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<MaterialViewModel> GetList()
        {
            List<MaterialViewModel> result = new List<MaterialViewModel>();
            for (int i = 0; i < source.Materials.Count; ++i)
            {
                result.Add(new MaterialViewModel
                {
                    Id = source.Materials[i].Id,
                    MaterialName = source.Materials[i].MaterialName
                });
            }
            return result;
        }

        public void UpdElement(MaterialBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Materials.Count; ++i)
            {
                if (source.Materials[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Materials[i].MaterialName == model.MaterialName &&
                source.Materials[i].Id != model.Id)
                {
                    throw new Exception("Уже есть материал с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Materials[index].MaterialName = model.MaterialName;
        }
    }
}
