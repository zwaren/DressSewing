using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveDressPrice(ReportBindingModel model);
        List<StoresLoadViewModel> GetStoresLoad();
        void SaveStoresLoad(ReportBindingModel model);
        List<DesignerRequestsModel> GetDesignerRequests(ReportBindingModel model);
        void SaveDesignerRequests(ReportBindingModel model);
    }
}
