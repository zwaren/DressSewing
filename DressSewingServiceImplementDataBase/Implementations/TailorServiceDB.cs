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
    public class TailorServiceDB : ITailorService
    {
        private AbstractDbContext context;

        public TailorServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void AddElement(TailorBindingModel model)
        {
            Tailor element = context.Tailors.FirstOrDefault(rec => rec.TailorFIO == model.TailorFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Tailors.Add(new Tailor
            {
                TailorFIO = model.TailorFIO
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Tailor element = context.Tailors.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Tailors.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public TailorViewModel GetElement(int id)
        {
            Tailor element = context.Tailors.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new TailorViewModel
                {
                    Id = element.Id,
                    TailorFIO = element.TailorFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public TailorViewModel GetFreeWorker()
        {
            var requestsWorker = context.Tailors
                .Select(x => new
                {
                    ImplId = x.Id,
                    Count = context.Requests.Where(o => o.Status == RequestStatus.Выполняется && o.TailorId == x.Id).Count()
                })
                .OrderBy(x => x.Count)
                .FirstOrDefault();
            if (requestsWorker != null)
            {
                return GetElement(requestsWorker.ImplId);
            }
            return null;
        }

        public List<TailorViewModel> GetList()
        {
            List<TailorViewModel> result = context.Tailors
                .Select(rec => new TailorViewModel
                {
                    Id = rec.Id,
                    TailorFIO = rec.TailorFIO
                })
                .ToList();
            return result;
        }

        public void UpdElement(TailorBindingModel model)
        {
            Tailor element = context.Tailors.FirstOrDefault(rec =>
                rec.TailorFIO == model.TailorFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Tailors.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.TailorFIO = model.TailorFIO;
            context.SaveChanges();
        }
    }
}
