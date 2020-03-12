using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Miu.Library.Web.Areas.Admin.Models;


namespace Miu.Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new ProductModel(_configuration);
            return View(model);
        }

        public IActionResult GetProducts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductModel(_configuration);
            var data = model.GetProducts(tableModel);
            return Json(data);
        }
    }
}