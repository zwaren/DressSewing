using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IStoreService
    {
        List<StoreViewModel> GetList();
        StoreViewModel GetElement(int id);
        void AddElement(StoreBindingModel model);
        void UpdElement(StoreBindingModel model);
        void DelElement(int id);
    }
}
