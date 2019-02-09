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
    public class ComponentServiceList : IComponentService
    {
        private DataListSingleton source;

        public ComponentServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(ComponentBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id > maxId)
                {
                    maxId = source.Components[i].Id;
                }
                if (source.Components[i].ComponentName == model.ComponentName)
                {
                    throw new Exception("Уже есть компонент с таким именем");
                }
            }
            source.Components.Add(new Component
            {
                Id = maxId + 1,
                ComponentName = model.ComponentName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == id)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public ComponentViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == id)
                {
                    return new ComponentViewModel
                    {
                        Id = source.Components[i].Id,
                        ComponentName = source.Components[i].ComponentName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ComponentViewModel> GetList()
        {
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            for (int i = 0; i < source.Components.Count; ++i)
            {
                result.Add(new ComponentViewModel
                {
                    Id = source.Components[i].Id,
                    ComponentName = source.Components[i].ComponentName
                });
            }
            return result;
        }

        public void UpdElement(ComponentBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Components[i].ComponentName == model.ComponentName &&
                source.Components[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Components[index].ComponentName = model.ComponentName;
        }
    }
}
