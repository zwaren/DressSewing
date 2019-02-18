using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplement.Implemetations
{
    public class DressServiceList : IDressService
    {
        private DataListSingleton source;
        public DressServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<DressViewModel> GetList()
        {
            List<DressViewModel> result = new List<DressViewModel>();
            for (int i = 0; i < source.Dresses.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<DressMaterialViewModel> DressMaterials = new List<DressMaterialViewModel>();
                for (int j = 0; j < source.DressMaterials.Count; ++j)
                {
                    if (source.DressMaterials[j].DressId == source.Dresses[i].Id)
                    {
                        string MaterialName = string.Empty;
                        for (int k = 0; k < source.Materials.Count; ++k)
                        {
                            if (source.DressMaterials[j].MaterialId == source.Materials[k].Id)
                            {
                                MaterialName = source.Materials[k].MaterialName;
                                break;
                            }
                        }
                        DressMaterials.Add(new DressMaterialViewModel
                        {
                            Id = source.DressMaterials[j].Id,
                            DressId = source.DressMaterials[j].DressId,
                            MaterialId = source.DressMaterials[j].MaterialId,
                            MaterialName = MaterialName,
                            Count = source.DressMaterials[j].Count
                        });
                    }
                }
                result.Add(new DressViewModel
                {
                    Id = source.Dresses[i].Id,
                    DressName = source.Dresses[i].DressName,
                    Price = source.Dresses[i].Price,
                    DressMaterials = DressMaterials
                });
            }
            return result;
        }
        public DressViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Dresses.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<DressMaterialViewModel> DressMaterials = new List<DressMaterialViewModel>();
                for (int j = 0; j < source.DressMaterials.Count; ++j)
                {
                    if (source.DressMaterials[j].DressId == source.Dresses[i].Id)
                    {
                        string MaterialName = string.Empty;
                        for (int k = 0; k < source.Materials.Count; ++k)
                        {
                            if (source.DressMaterials[j].MaterialId == source.Materials[k].Id)
                            {
                                MaterialName = source.Materials[k].MaterialName;
                                break;
                            }
                        }
                        DressMaterials.Add(new DressMaterialViewModel
                        {
                            Id = source.DressMaterials[j].Id,
                            DressId = source.DressMaterials[j].DressId,
                            MaterialId = source.DressMaterials[j].MaterialId,
                            MaterialName = MaterialName,
                            Count = source.DressMaterials[j].Count
                        });
                    }
                }
                if (source.Dresses[i].Id == id)
                {
                    return new DressViewModel
                    {
                        Id = source.Dresses[i].Id,
                        DressName = source.Dresses[i].DressName,
                        Price = source.Dresses[i].Price,
                        DressMaterials = DressMaterials
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DressBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Dresses.Count; ++i)
            {
                if (source.Dresses[i].Id > maxId)
                {
                    maxId = source.Dresses[i].Id;
                }
                if (source.Dresses[i].DressName == model.DressName)
                {
                    throw new Exception("Уже есть платье с таким названием");
                }
            }
            source.Dresses.Add(new Dress
            {
                Id = maxId + 1,
                DressName = model.DressName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].Id > maxPCId)
                {
                    maxPCId = source.DressMaterials[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.DressMaterials.Count; ++i)
            {
                for (int j = 1; j < model.DressMaterials.Count; ++j)
                {
                    if (model.DressMaterials[i].MaterialId ==
                    model.DressMaterials[j].MaterialId)
                    {
                        model.DressMaterials[i].Count +=
                        model.DressMaterials[j].Count;
                        model.DressMaterials.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.DressMaterials.Count; ++i)
            {
                source.DressMaterials.Add(new DressMaterial
                {
                    Id = ++maxPCId,
                    DressId = maxId + 1,
                    MaterialId = model.DressMaterials[i].MaterialId,
                    Count = model.DressMaterials[i].Count
                });
            }
        }
        public void UpdElement(DressBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Dresses.Count; ++i)
            {
                if (source.Dresses[i].Id == model.Id)
                {
                index = i;
                }
                if (source.Dresses[i].DressName == model.DressName &&
                source.Dresses[i].Id != model.Id)
                {
                    throw new Exception("Уже есть платье с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Dresses[index].DressName = model.DressName;
            source.Dresses[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].Id > maxPCId)
                {
                    maxPCId = source.DressMaterials[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].DressId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.DressMaterials.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.DressMaterials[i].Id == model.DressMaterials[j].Id)
                        {
                            source.DressMaterials[i].Count = model.DressMaterials[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.DressMaterials.RemoveAt(i--);
                    }
                }
            }

            // новые записи
            for (int i = 0; i < model.DressMaterials.Count; ++i)
            {
                if (model.DressMaterials[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.DressMaterials.Count; ++j)
                    {
                        if (source.DressMaterials[j].DressId == model.Id &&
                        source.DressMaterials[j].MaterialId == model.DressMaterials[i].MaterialId)
                        {
                            source.DressMaterials[j].Count += model.DressMaterials[i].Count;
                            model.DressMaterials[i].Id = source.DressMaterials[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.DressMaterials[i].Id == 0)
                    {
                        source.DressMaterials.Add(new DressMaterial
                        {
                            Id = ++maxPCId,
                            DressId = model.Id,
                            MaterialId = model.DressMaterials[i].MaterialId,
                            Count = model.DressMaterials[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.DressMaterials.Count; ++i)
            {
                if (source.DressMaterials[i].DressId == id)
                {
                    source.DressMaterials.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Dresses.Count; ++i)
            {
                if (source.Dresses[i].Id == id)
                {
                    source.Dresses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
