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
            Designer element = source.Designers.FirstOrDefault(rec => rec.DesignerFIO == model.DesignerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Designers.Count > 0 ? source.Designers.Max(rec => rec.Id) : 0;
            source.Designers.Add(new Designer
            {
                Id = maxId + 1,
                DesignerFIO = model.DesignerFIO
            });
        }

        public void DelElement(int id)
        {
            Designer element = source.Designers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Designers.Remove(element);
            }
            else throw new Exception("Элемент не найден");
        }

        public DesignerViewModel GetElement(int id)
        {
            Designer element = source.Designers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new DesignerViewModel
                {
                    Id = element.Id,
                    DesignerFIO = element.DesignerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<DesignerViewModel> GetList()
        {
            List<DesignerViewModel> result = source.Designers.Select(rec => new DesignerViewModel
			{
				Id = rec.Id,
				DesignerFIO = rec.DesignerFIO
			})
			.ToList();
            return result;
        }

        public void UpdElement(DesignerBindingModel model)
        {
            Designer element = source.Designers.FirstOrDefault(rec => rec.DesignerFIO == model.DesignerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Designers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.DesignerFIO = model.DesignerFIO;
        }
    }
}
