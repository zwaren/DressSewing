using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplementDataBase.Implementations
{
    class MainServiceDB : IMainService
    {
        private AbstractDbContext context;

        public MainServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void CreateRequest(RequestBindingModel model)
        {
            context.Requests.Add(new Request
            {
                DesignerId = model.DesignerId,
                ProductId = model.ProductId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = RequestStatus.Принят
            });
            context.SaveChanges();
        }

        public void FinishRequest(RequestBindingModel model)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            { 
                throw new Exception("Элемент не найден");
            }
            if (element.Status != RequestStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = RequestStatus.Готов;
            context.SaveChanges();
        }

        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = context.Requests.Select(rec => new RequestViewModel
            {
                Id = rec.Id,
                DesignerId = rec.DesignerId,
                ProductId = rec.ProductId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                        SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                        SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
                        SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " +
                        SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " +
                        SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                DesignerFIO = rec.Designer.DesignerFIO,
                ProductName = rec.Product.ProductName
            })
            .ToList();
            return result;
        }

        public void PayRequest(RequestBindingModel model)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != RequestStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = RequestStatus.Оплачен;
            context.SaveChanges();
        }

        public void PutMaterialInStore(StoreMaterialBindingModel model)
        {
            StoreMaterial element = context.StoreMaterials.FirstOrDefault(rec => rec.StoreId == model.StoreId && rec.ComponentId == model.ComponentId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StoreMaterials.Add(new StoreMaterial
                {
                    StoreId = model.StoreId,
                    ComponentId = model.ComponentId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != RequestStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var dressMaterials = context.DressMaterials.Include(rec => rec.Component).Where(rec => rec.ProductId == element.ProductId);
                    // списываем
                    foreach (var dressMaterial in dressMaterials)
                    {
                        int countOnStores = dressMaterial.Count * element.Count;
                        var StoreMaterials = context.StoreMaterials.Where(rec => rec.ComponentId == dressMaterial.ComponentId);
                        foreach (var StoreMaterial in StoreMaterials)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (StoreMaterial.Count >= countOnStores)
                            {
                                StoreMaterial.Count -= countOnStores;
                                countOnStores = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStores -= StoreMaterial.Count;
                                StoreMaterial.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStores > 0)
                        {
                            throw new Exception("Не достаточно компонента " + dressMaterial.Component.ComponentName + " требуется " + dressMaterial.Count + ", не хватает " + countOnStores);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = RequestStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
