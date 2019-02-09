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
    public class ProductServiceList : IProductService
    {
        private DataListSingleton source;
        public ProductServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ProductViewModel> GetList()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            for (int i = 0; i < source.Products.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<ProductComponentViewModel> productComponents = new List<ProductComponentViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j)
                {
                    if (source.ProductComponents[j].ProductId == source.Products[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ProductComponents[j].ComponentId == source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        productComponents.Add(new ProductComponentViewModel
                        {
                            Id = source.ProductComponents[j].Id,
                            ProductId = source.ProductComponents[j].ProductId,
                            ComponentId = source.ProductComponents[j].ComponentId,
                            ProductComponentName = componentName,
                            Count = source.ProductComponents[j].Count
                        });
                    }
                }
                result.Add(new ProductViewModel
                {
                    Id = source.Products[i].Id,
                    ProductName = source.Products[i].ProductName,
                    Price = source.Products[i].Price,
                    ProductComponents = productComponents
                });
            }
            return result;
        }
        public ProductViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<ProductComponentViewModel> productComponents = new List<ProductComponentViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j)
                {
                    if (source.ProductComponents[j].ProductId == source.Products[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ProductComponents[j].ComponentId == source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        productComponents.Add(new ProductComponentViewModel
                        {
                            Id = source.ProductComponents[j].Id,
                            ProductId = source.ProductComponents[j].ProductId,
                            ComponentId = source.ProductComponents[j].ComponentId,
                            ProductComponentName = componentName,
                            Count = source.ProductComponents[j].Count
                        });
                    }
                }
                if (source.Products[i].Id == id)
                {
                    return new ProductViewModel
                    {
                        Id = source.Products[i].Id,
                        ProductName = source.Products[i].ProductName,
                        Price = source.Products[i].Price,
                        ProductComponents = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ProductBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id > maxId)
                {
                    maxId = source.Products[i].Id;
                }
                if (source.Products[i].ProductName == model.ProductName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Products.Add(new Product
            {
                Id = maxId + 1,
                ProductName = model.ProductName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.ProductComponents.Count; ++i)
            {
                for (int j = 1; j < model.ProductComponents.Count; ++j)
                {
                    if (model.ProductComponents[i].ComponentId ==
                    model.ProductComponents[j].ComponentId)
                    {
                        model.ProductComponents[i].Count +=
                        model.ProductComponents[j].Count;
                        model.ProductComponents.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.ProductComponents.Count; ++i)
            {
                source.ProductComponents.Add(new ProductComponent
                {
                    Id = ++maxPCId,
                    ProductId = maxId + 1,
                    ComponentId = model.ProductComponents[i].ComponentId,
                    Count = model.ProductComponents[i].Count
                });
            }
        }
        public void UpdElement(ProductBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                index = i;
                }
                if (source.Products[i].ProductName == model.ProductName &&
                source.Products[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Products[index].ProductName = model.ProductName;
            source.Products[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].ProductId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.ProductComponents.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.ProductComponents[i].Id == model.ProductComponents[j].Id)
                        {
                            source.ProductComponents[i].Count = model.ProductComponents[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.ProductComponents.RemoveAt(i--);
                    }
                }
            }

            // новые записи
            for (int i = 0; i < model.ProductComponents.Count; ++i)
            {
                if (model.ProductComponents[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.ProductComponents.Count; ++j)
                    {
                        if (source.ProductComponents[j].ProductId == model.Id &&
                        source.ProductComponents[j].ComponentId == model.ProductComponents[i].ComponentId)
                        {
                            source.ProductComponents[j].Count += model.ProductComponents[i].Count;
                            model.ProductComponents[i].Id = source.ProductComponents[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.ProductComponents[i].Id == 0)
                    {
                        source.ProductComponents.Add(new ProductComponent
                        {
                            Id = ++maxPCId,
                            ProductId = model.Id,
                            ComponentId = model.ProductComponents[i].ComponentId,
                            Count = model.ProductComponents[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].ProductId == id)
                {
                    source.ProductComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
