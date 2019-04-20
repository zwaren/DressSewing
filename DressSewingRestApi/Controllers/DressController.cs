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
    public class DressController : ApiController
    {
		private readonly IDressService _service;

		public DressController(IDressService service)
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

		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var element = _service.GetElement(id);
			if (element == null)
			{
				InternalServerError(new Exception("Нет данных"));
			}
			return Ok(element);
		}

		[HttpPost]
		public void AddElement(DressBindingModel model)
		{
			_service.AddElement(model);
		}

		[HttpPost]
		public void UpdElement(DressBindingModel model)
		{
			_service.UpdElement(model);
		}

		[HttpPost]
		public void DelElement(DressBindingModel model)
		{
			_service.DelElement(model.Id);
		}
	}
}
