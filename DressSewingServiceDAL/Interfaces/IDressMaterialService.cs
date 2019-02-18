using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IDressMaterialService
    {
        List<DressMaterialViewModel> GetList();
        DressMaterialViewModel GetElement(int id);
        void AddElement(DressMaterialBindingModel model);
        void UpdElement(DressMaterialBindingModel model);
        void DelElement(int id);
    }
}
