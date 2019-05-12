using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplementDataBase.Implementations
{
	public class MainServiceDB : IMainService
    {
        private AbstractDbContext context;

        public MainServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void CreateRequest(RequestBindingModel model)
        {
            var request = new Request
            {
                DesignerId = model.DesignerId,
                DressId = model.DressId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = RequestStatus.Принят
            };
            context.Requests.Add(request);
            context.SaveChanges();

            var designer = context.Designers.FirstOrDefault(x => x.Id == model.DesignerId);
            SendEmail(designer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} создан успешно", request.Id, request.DateCreate.ToShortDateString()));
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
            SendEmail(element.Designer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передан на оплату", element.Id, element.DateCreate.ToShortDateString()));
        }

        public List<RequestViewModel> GetFreeRequests()
        {
            List<RequestViewModel> result = context.Requests
                .Where(x => x.Status == RequestStatus.Принят || x.Status == RequestStatus.НедостаточноРесурсов)
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id
                })
                .ToList();
            return result;
        }

        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = context.Requests.Select(rec => new RequestViewModel
            {
                Id = rec.Id,
                DesignerId = rec.DesignerId,
                DressId = rec.DressId,
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
                DressName = rec.Dress.DressName,
                TailorId = rec.Tailor.Id,
                TailorName = rec.Tailor.TailorFIO
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
            SendEmail(element.Designer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void PutMaterialInStore(StoreMaterialBindingModel model)
        {
            StoreMaterial element = context.StoreMaterials.FirstOrDefault(rec => rec.StoreId == model.StoreId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StoreMaterials.Add(new StoreMaterial
                {
                    StoreId = model.StoreId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                try
                {
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != RequestStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var dressMaterials = context.DressMaterials.Where(rec => rec.DressId == element.DressId);
                    // списываем
                    foreach (var dressMaterial in dressMaterials)
                    {
                        int countOnStores = dressMaterial.Count * element.Count;
                        var StoreMaterials = context.StoreMaterials.Where(rec => rec.MaterialId == dressMaterial.MaterialId);
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
                            throw new Exception("Не достаточно компонента " + dressMaterial.Material.MaterialName + " требуется " + dressMaterial.Count + ", не хватает " + countOnStores);
                        }
                    }
                    element.TailorId = model.TailorId;
                    //element.Tailor = context.Tailors.First(rec => rec.Id == model.TailorId);
                    element.DateImplement = DateTime.Now;
                    element.Status = RequestStatus.Выполняется;
                    context.SaveChanges();
                    SendEmail(element.Designer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передеан в работу", element.Id, element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    element.Status = RequestStatus.НедостаточноРесурсов;
                    context.SaveChanges();
                    transaction.Commit();
                    throw;
                }
            }
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailLogin"], ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}
