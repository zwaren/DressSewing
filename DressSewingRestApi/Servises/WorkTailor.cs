using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace DressSewingRestApi.Servises
{
    public class WorkTailor
    {
        private readonly IMainService _service;

        private readonly ITailorService _serviceTailor;

        private readonly int _TailorId;

        private readonly int _orderId;

        // семафор
        static Semaphore _sem = new Semaphore(3, 3);

        Thread myThread;

        public WorkTailor(IMainService service, ITailorService serviceTailor, int TailorId, int orderId)
        {
            _service = service;
            _serviceTailor = serviceTailor;
            _TailorId = TailorId;
            _orderId = orderId;
            try
            {
                _service.TakeRequestInWork(new RequestBindingModel
                {
                    Id = _orderId,
                    TailorId = _TailorId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }

        public void Work()
        {
            try
            {
                // забиваем мастерскую
                _sem.WaitOne();
                // Типа выполняем
                Thread.Sleep(10000);
                _service.FinishRequest(new RequestBindingModel
                {
                    Id = _orderId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую
                _sem.Release();
            }
        }
    }
}