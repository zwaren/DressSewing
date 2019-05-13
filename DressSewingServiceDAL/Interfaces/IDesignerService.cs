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
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface IDesignerService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<DesignerViewModel> GetList();

        [CustomMethod("Метод получения клиента по id")]
        DesignerViewModel GetElement(int id);

        [CustomMethod("Метод добавления клиента")]
        void AddElement(DesignerBindingModel model);

        [CustomMethod("Метод изменения данных по клиенту")]
        void UpdElement(DesignerBindingModel model);

        [CustomMethod("Метод удаления клиента")]
        void DelElement(int id);
    }
}
