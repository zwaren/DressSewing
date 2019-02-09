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
    public class ProductComponentServiceList : IProductComponentService
    {
        private DataListSingleton source;

        public ProductComponentServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(ProductComponentBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxId)
                {
                    maxId = source.ProductComponents[i].Id;
                }
                if (source.ProductComponents[i].ProductComponentName == model.ProductComponentName)
                {
                    throw new Exception("Уже есть компонент с таким именем");
                }
            }
            source.ProductComponents.Add(new ProductComponent
            {
                Id = maxId + 1,
                ProductId = model.ProductId,
                ComponentId = model.ComponentId,
                Count = model.Count,
                ProductComponentName = model.ProductComponentName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id == id)
                {
                    source.ProductComponents.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public ProductComponentViewModel GetElement(int id)
        {
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id == id)
                {
                    return new ProductComponentViewModel
                    {
                        Id = source.ProductComponents[i].Id,
                        ProductComponentName = source.ProductComponents[i].ProductComponentName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ProductComponentViewModel> GetList()
        {
            List<ProductComponentViewModel> result = new List<ProductComponentViewModel>();
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                result.Add(new ProductComponentViewModel
                {
                    Id = source.ProductComponents[i].Id,
                    ProductId = source.ProductComponents[i].ProductId,
                    ComponentId = source.ProductComponents[i].ComponentId,
                    Count = source.ProductComponents[i].Count,
                    ProductComponentName = source.ProductComponents[i].ProductComponentName
                });
            }
            return result;
        }

        public void UpdElement(ProductComponentBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.ProductComponents[i].ProductComponentName == model.ProductComponentName &&
                source.ProductComponents[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.ProductComponents[index].ProductComponentName = model.ProductComponentName;
        }
    }
}
