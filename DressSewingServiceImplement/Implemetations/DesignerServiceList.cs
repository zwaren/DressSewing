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
    public class DesignerServiceList : IDesignerService
    {
        private DataListSingleton source;

        public DesignerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(DesignerBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Designers.Count; ++i)
            {
                if (source.Designers[i].Id > maxId)
                {
                    maxId = source.Designers[i].Id;
                }
                if (source.Designers[i].DesignerFIO == model.DesignerFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Designers.Add(new Designer
            {
                Id = maxId + 1,
                DesignerFIO = model.DesignerFIO
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Designers.Count; ++i)
            {
                if (source.Designers[i].Id == id)
                {
                    source.Designers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public DesignerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Designers.Count; ++i)
            {
                if (source.Designers[i].Id == id)
                {
                    return new DesignerViewModel
                    {
                        Id = source.Designers[i].Id,
                        DesignerFIO = source.Designers[i].DesignerFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<DesignerViewModel> GetList()
        {
            List<DesignerViewModel> result = new List<DesignerViewModel>();
            for (int i = 0; i < source.Designers.Count; ++i)
            {
                result.Add(new DesignerViewModel
                {
                    Id = source.Designers[i].Id,
                    DesignerFIO = source.Designers[i].DesignerFIO
                });
            }
            return result;
        }

        public void UpdElement(DesignerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Designers.Count; ++i)
            {
                if (source.Designers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Designers[i].DesignerFIO == model.DesignerFIO &&
                source.Designers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Designers[index].DesignerFIO = model.DesignerFIO;
        }
    }
}
