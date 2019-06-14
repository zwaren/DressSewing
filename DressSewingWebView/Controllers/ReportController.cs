using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressSewingWebView.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public FileResult DressPrice()
        {
            ReportBindingModel model = new ReportBindingModel { FileName = @"C:\Users\user\Documents\test.docx" };
            _service.SaveDressPrice(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.docx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public FileResult StoresLoad()
        {
            ReportBindingModel model = new ReportBindingModel { FileName = @"C:\Users\user\Documents\test.xls" };
            _service.SaveStoresLoad(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.xls";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public ActionResult DesignerRequests()
        {
            return View();
        }

        [HttpPost]
        public FileResult DesignerRequests(ReportBindingModel model)
        {
            model.FileName = @"C:\Users\user\Documents\test.pdf";
            _service.SaveDesignerRequests(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}