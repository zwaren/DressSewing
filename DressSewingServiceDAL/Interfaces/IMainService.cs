using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<RequestViewModel> GetList();
        void CreateRequest(RequestBindingModel model);
        void TakeRequestInWork(RequestBindingModel model);
        void FinishRequest(RequestBindingModel model);
        void PayRequest(RequestBindingModel model);
        void PutMaterialInStore(StoreMaterialBindingModel model);
    }
}
