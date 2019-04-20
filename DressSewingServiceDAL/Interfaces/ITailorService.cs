using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface ITailorService
    {
        List<TailorViewModel> GetList();

        TailorViewModel GetElement(int id);

        void AddElement(TailorBindingModel model);

        void UpdElement(TailorBindingModel model);

        void DelElement(int id);

        TailorViewModel GetFreeWorker();
    }
}
