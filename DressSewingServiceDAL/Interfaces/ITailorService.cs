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
    [CustomInterface("Интерфейс для работы с портными")]
    public interface ITailorService
    {
        [CustomMethod("Метод получения списка портных")]
        List<TailorViewModel> GetList();

        [CustomMethod("Метод получения портного по id")]
        TailorViewModel GetElement(int id);

        [CustomMethod("Метод добавления портного")]
        void AddElement(TailorBindingModel model);

        [CustomMethod("Метод изменения данных по портным")]
        void UpdElement(TailorBindingModel model);

        [CustomMethod("Метод удаления портного")]
        void DelElement(int id);

        [CustomMethod("Метод получения свободного портного")]
        TailorViewModel GetFreeWorker();
    }
}
