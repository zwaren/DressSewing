using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DressSewingRestApi.Servises;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;

namespace DressSewingRestApi.Controllers
{
    public class MainController : ApiController
    {
		private readonly IMainService _service;

        private readonly ITailorService _serviceTailor;

        public MainController(IMainService service, ITailorService serviceTailor)
		{
			_service = service;
            _serviceTailor = serviceTailor;
		}

		[HttpGet]
		public IHttpActionResult GetList()
		{
			var list = _service.GetList();
			if (list == null)
			{
				InternalServerError(new Exception("Нет данных"));
			}
			return Ok(list);
		}

		[HttpPost]
		public void CreateRequest(RequestBindingModel model)
		{
			_service.CreateRequest(model);
		}

		[HttpPost]
		public void TakeRequestInWork(RequestBindingModel model)
		{
			_service.TakeRequestInWork(model);
		}

		[HttpPost]
		public void FinishRequest(RequestBindingModel model)
		{
			_service.FinishRequest(model);
		}

		[HttpPost]
		public void PayRequest(RequestBindingModel model)
		{
			_service.PayRequest(model);
		}

		[HttpPost]
		public void PutMaterialInStore(StoreMaterialBindingModel model)
		{
			_service.PutMaterialInStore(model);
		}

        [HttpPost]
        public void StartWork()
        {
            List<RequestViewModel> requests = _service.GetFreeRequests();
            foreach (var request in requests)
            {
                TailorViewModel impl = _serviceTailor.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkTailor(_service, _serviceTailor, impl.Id, request.Id);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}
