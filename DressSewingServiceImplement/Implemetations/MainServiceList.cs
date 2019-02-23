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
            List<RequestViewModel> result = new List<RequestViewModel>();
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                string DesignerFIO = string.Empty;
                for (int j = 0; j < source.Designers.Count; ++j)
                {
                    if (source.Designers[j].Id == source.Requests[i].DesignerId)
                    {
                        DesignerFIO = source.Designers[j].DesignerFIO;
                        break;
                    }
                }
                string DressName = string.Empty;
                for (int j = 0; j < source.Dresses.Count; ++j)
                {
                    if (source.Dresses[j].Id == source.Requests[i].DressId)
                    {
                        DressName = source.Dresses[j].DressName;
                        break;
                    }
                }
                result.Add(new RequestViewModel
                {
                    Id = source.Requests[i].Id,
                    DesignerId = source.Requests[i].DesignerId,
                    DesignerFIO = DesignerFIO,
                    DressId = source.Requests[i].DressId,
                    DressName = DressName,
                    Count = source.Requests[i].Count,
                    Sum = source.Requests[i].Sum,
                    DateCreate = source.Requests[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Requests[i].DateImplement?.ToLongDateString(),
                    Status = source.Requests[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateRequest(RequestBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Requests[i].Id > maxId)
                {
                    maxId = source.Designers[i].Id;
                }
            }
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
            int index = -1;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Requests[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Requests[index].Status != RequestStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Requests[index].DateImplement = DateTime.Now;
            source.Requests[index].Status = RequestStatus.Выполняется;
        }
        public void FinishRequest(RequestBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Designers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Requests[index].Status != RequestStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Requests[index].Status = RequestStatus.Готов;
        }
        public void PayRequest(RequestBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Designers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Requests[index].Status != RequestStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Requests[index].Status = RequestStatus.Оплачен;
        }
    }
}
