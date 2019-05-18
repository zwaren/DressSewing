using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressSewingWebView.Controllers
{
    public class DressesController : Controller
    {
        private readonly IDressService _service;
        private readonly IMaterialService _matService;

        public DressesController(IDressService service, IMaterialService matService)
        {
            _service = service;
            _matService = matService;
        }

        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            if (Session["Dress"] == null)
            {
                var dress = new DressBindingModel();
                dress.DressMaterials = new List<DressMaterialBindingModel>();
                Session["Dress"] = dress;
            }
            return View((DressBindingModel) Session["Dress"]);
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var dress = (DressBindingModel) Session["Dress"];

            dress.DressName = Request["DressName"];
            dress.Price = Convert.ToDecimal(Request["Price"]);

            _service.AddElement(dress);

            Session.Remove("Dress");

            return RedirectToAction("Index");
        }

        public ActionResult AddMaterial()
        {
            var materials = new SelectList(_matService.GetList(), "Id", "MaterialName");
            ViewBag.Materials = materials;
            return View();
        }

        [HttpPost]
        public ActionResult AddMaterialPost()
        {
            var dress = (DressBindingModel) Session["Dress"];
            var material = new DressMaterialBindingModel
            {
                DressId = dress.Id,
                MaterialId = int.Parse(Request["MaterialId"]),
                MaterialName = _matService.GetElement(int.Parse(Request["MaterialId"])).MaterialName,
                Count = int.Parse(Request["Count"])
            };
            dress.DressMaterials.Add(material);
            Session["Dress"] = dress;
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new DressBindingModel
            {
                Id = id,
                DressName = viewModel.DressName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            _service.UpdElement(new DressBindingModel
            {
                Id = int.Parse(Request["Id"]),
                DressName = Request["DressName"]
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