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
    [CustomInterface("Интерфейс для работы с материалами")]
    public interface IMaterialService
    {
        [CustomMethod("Метод получения списка материалов")]
        List<MaterialViewModel> GetList();

        [CustomMethod("Метод получения материала по id")]
        MaterialViewModel GetElement(int id);

        [CustomMethod("Метод добавления материала")]
        void AddElement(MaterialBindingModel model);

        [CustomMethod("Метод изменения данных по материалу")]
        void UpdElement(MaterialBindingModel model);

        [CustomMethod("Метод удаления материала")]
        void DelElement(int id);
    }
}
