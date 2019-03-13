using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplementDataBase.Implementations
{
    class DesignerServiceDB : IDesignerService
    {
        private AbstractDbContext context;

        public DesignerServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void AddElement(DesignerBindingModel model)
        {
            Designer element = context.Designers.FirstOrDefault(rec => rec.DesignerFIO == model.DesignerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Designers.Add(new Designer
            {
                DesignerFIO = model.DesignerFIO
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Designer element = context.Designers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Designers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public DesignerViewModel GetElement(int id)
        {
            Designer element = context.Designers.FirstOrDefault(rec => rec.Id == id);
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
            List<DesignerViewModel> result = context.Designers.Select(rec => new DesignerViewModel
            {
                Id = rec.Id,
                DesignerFIO = rec.DesignerFIO
            })
            .ToList();
            return result;
        }

        public void UpdElement(DesignerBindingModel model)
        {
            Designer element = context.Designers.FirstOrDefault(rec => rec.DesignerFIO == model.DesignerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Designers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.DesignerFIO = model.DesignerFIO;
            context.SaveChanges();
        }
    }
}
