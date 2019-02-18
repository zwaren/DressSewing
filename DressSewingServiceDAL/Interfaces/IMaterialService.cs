using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IMaterialService
    {
        List<MaterialViewModel> GetList();
		MaterialViewModel GetElement(int id);
        void AddElement(MaterialBindingModel model);
        void UpdElement(MaterialBindingModel model);
        void DelElement(int id);
    }
}
