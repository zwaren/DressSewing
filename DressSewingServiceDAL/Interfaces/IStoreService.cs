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
    [CustomInterface("Интерфейс для работы с складами")]
    public interface IStoreService
    {
        [CustomMethod("Метод получения списка складов")]
        List<StoreViewModel> GetList();

        [CustomMethod("Метод получения склада по id")]
        StoreViewModel GetElement(int id);

        [CustomMethod("Метод добавления склада")]
        void AddElement(StoreBindingModel model);

        [CustomMethod("Метод изменения данных по складу")]
        void UpdElement(StoreBindingModel model);

        [CustomMethod("Метод удаления склада")]
        void DelElement(int id);
    }
}
