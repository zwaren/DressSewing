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
    public class ReportController : ApiController
    {
		private readonly IReportService _service;
		public ReportController(IReportService service)
		{
			_service = service;
		}
		[HttpGet]
		public IHttpActionResult GetStoresLoad()
		{
			var list = _service.GetStoresLoad();
			if (list == null)
			{
				InternalServerError(new Exception("Нет данных"));
			}
			return Ok(list);
		}
		[HttpPost]
		public IHttpActionResult GetDesignerRequests(ReportBindingModel model)
		{
			var list = _service.GetDesignerRequests(model);
			if (list == null)
			{
				InternalServerError(new Exception("Нет данных"));
			}
			return Ok(list);
		}
		[HttpPost]
		public void SaveDressPrice(ReportBindingModel model)
		{
			_service.SaveDressPrice(model);
		}
		[HttpPost]
		public void SaveStoresLoad(ReportBindingModel model)
		{
			_service.SaveStoresLoad(model);
		}
		[HttpPost]
		public void SaveDesignerRequests(ReportBindingModel model)
		{
			_service.SaveDesignerRequests(model);
		}
	}
}
