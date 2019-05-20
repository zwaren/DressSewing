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
    [CustomInterface("Интерфейс для работы с платьями")]
    public interface IDressService
    {
        [CustomMethod("Метод получения списка платьев")]
        List<DressViewModel> GetList();

        [CustomMethod("Метод получения платья по id")]
        DressViewModel GetElement(int id);

        [CustomMethod("Метод добавления платья")]
        void AddElement(DressBindingModel model);

        [CustomMethod("Метод изменения данных по платью")]
        void UpdElement(DressBindingModel model);

        [CustomMethod("Метод удаления платья")]
        void DelElement(int id);
    }
}
