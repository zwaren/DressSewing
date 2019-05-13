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
    [CustomInterface("Интерфейс для работы с письмами")]
    public interface IMessageInfoService
    {
        [CustomMethod("Метод получения списка писем")]
        List<MessageInfoViewModel> GetList();

        [CustomMethod("Метод получения письма по id")]
        MessageInfoViewModel GetElement(int id);

        [CustomMethod("Метод добавления письма")]
        void AddElement(MessageInfoBindingModel model);
    }
}
