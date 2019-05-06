using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressSewingWebView.Controllers
{
    public class DesignersController : Controller
    {
        private readonly IDesignerService _service;

        public DesignersController(IDesignerService service)
        {
            _service = service;
        }
        
        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            _service.AddElement(new DesignerBindingModel
            {
                DesignerFIO = Request["DesignerFIO"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new DesignerBindingModel
            {
                Id = id,
                DesignerFIO = viewModel.DesignerFIO
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new DesignerBindingModel
            {
                Id = int.Parse(Request["Id"]),
                DesignerFIO = Request["DesignerFIO"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("Index");
        }
    }
}