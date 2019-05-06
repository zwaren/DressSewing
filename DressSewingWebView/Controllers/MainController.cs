using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressSewingWebView.Controllers
{
    public class MainController : Controller
    {
        private readonly IMainService _service;
        private readonly IDressService _dressService;
        private readonly IDesignerService _designerService;

        public MainController(IMainService service, IDressService dressService, IDesignerService designerService)
        {
            _service = service;
            _dressService = dressService;
            _designerService = designerService;
        }
        
        public ActionResult Index()
        {
            return View(_service.GetList());
        }

        public ActionResult Create()
        {
            var dresses = new SelectList(_dressService.GetList(), "Id", "DressName");
            var designers = new SelectList(_designerService.GetList(), "Id", "DesignerFIO");
            ViewBag.Dresses = dresses;
            ViewBag.Designers = designers;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var designerId = int.Parse(Request["DesignerId"]);
            var dressId = int.Parse(Request["DressId"]);
            var count = int.Parse(Request["Count"]);
            var sum = CalcSum(dressId, count);

            _service.CreateRequest(new RequestBindingModel
            {
                DesignerId = designerId,
                DressId = dressId,
                Count = count,
                Sum = sum

            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int Id, int Count)
        {
            DressViewModel dress = _dressService.GetElement(Id);
            return Count * dress.Price;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Processing":
                        _service.TakeRequestInWork(new RequestBindingModel { Id = id });
                        break;
                    case "Ready":
                        _service.FinishRequest(new RequestBindingModel { Id = id });
                        break;
                    case "Paid":
                        _service.PayRequest(new RequestBindingModel { Id = id });
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }


            return RedirectToAction("Index");
        }
    }
}