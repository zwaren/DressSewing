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
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод сохранения прайс-листа")]
        void SaveDressPrice(ReportBindingModel model);

        [CustomMethod("Метод получения отчета по загруженности складов")]
        List<StoresLoadViewModel> GetStoresLoad();

        [CustomMethod("Метод сохранения отчета по загруженности складов")]
        void SaveStoresLoad(ReportBindingModel model);

        [CustomMethod("Метод получения отчета по заказам")]
        List<DesignerRequestsModel> GetDesignerRequests(ReportBindingModel model);

        [CustomMethod("Метод сохранения отчета по заказам")]
        void SaveDesignerRequests(ReportBindingModel model);
    }
}
