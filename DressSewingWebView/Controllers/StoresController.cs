using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressSewingWebView.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreService _service;
        private readonly IMaterialService _matService;
        private readonly IMainService _mainService;

        public StoresController(IStoreService service, IMaterialService matService, IMainService mainService)
        {
            _service = service;
            _matService = matService;
            _mainService = mainService;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Details(int id)
        {
            return View(_service.GetElement(id));
        }

        public ActionResult Delete(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            _service.AddElement(new StoreBindingModel
            {
                StoreName = Request["StoreName"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult AddMaterial()
        {
            var stores = new SelectList(_service.GetList(), "Id", "StoreName");
            ViewBag.Stores = stores;
            var materials = new SelectList(_matService.GetList(), "Id", "MaterialName");
            ViewBag.Materials = materials;
            return View();
        }

        [HttpPost]
        public ActionResult AddMaterialPost()
        {
            _mainService.PutMaterialInStore(new StoreMaterialBindingModel
            {
                MaterialId = int.Parse(Request["MaterialId"]),
                StoreId = int.Parse(Request["StoreId"]),
                Count = int.Parse(Request["Count"])
            });
            return RedirectToAction("Index");
        }
    }
}