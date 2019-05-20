using DressSewingServiceDAL.Attributies;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    [CustomInterface("Главный интерфейс")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<RequestViewModel> GetList();

        [CustomMethod("Метод получения свободного заказа")]
        List<RequestViewModel> GetFreeRequests();

        [CustomMethod("Метод создания заказа")]
        void CreateRequest(RequestBindingModel model);

        [CustomMethod("Метод принятия на работу заказа")]
        void TakeRequestInWork(RequestBindingModel model);

        [CustomMethod("Метод окончания работы над заказом")]
        void FinishRequest(RequestBindingModel model);

        [CustomMethod("Метод оплаты заказа")]
        void PayRequest(RequestBindingModel model);

        [CustomMethod("Метод добавления материалов на склад")]
        void PutMaterialInStore(StoreMaterialBindingModel model);
    }
}
