using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DressSewingRestApi.Controllers
{
    public class TailorController : ApiController
    {
        private readonly ITailorService _service;
        public TailorController(ITailorService service)
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
        public void AddElement(TailorBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(TailorBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(TailorBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
