using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IProductComponentService
    {
        List<ProductComponentViewModel> GetList();
        ProductComponentViewModel GetElement(int id);
        void AddElement(ProductComponentBindingModel model);
        void UpdElement(ProductComponentBindingModel model);
        void DelElement(int id);
    }
}
