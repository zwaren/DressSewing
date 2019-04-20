using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;

namespace DressSewingRestApi.Controllers
{
    public class MainController : ApiController
    {
		private readonly IMainService _service;

		public MainController(IMainService service)
		{
			_service = service;
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
	}
}
