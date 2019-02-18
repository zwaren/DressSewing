using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IDressService
    {
        List<DressViewModel> GetList();
        DressViewModel GetElement(int id);
        void AddElement(DressBindingModel model);
        void UpdElement(DressBindingModel model);
        void DelElement(int id);
    }
}
