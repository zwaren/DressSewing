using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IDesignerService
    {
        List<DesignerViewModel> GetList();
        DesignerViewModel GetElement(int id);
        void AddElement(DesignerBindingModel model);
        void UpdElement(DesignerBindingModel model);
        void DelElement(int id);
    }
}
