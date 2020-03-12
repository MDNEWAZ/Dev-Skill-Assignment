using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Miu.Library.Framework;
using Miu.Library.Web.Areas.Admin.Models;

namespace Miu.Library.Web.Areas.Admin.Models
{
    public class ProductModel : AdminBaseModel
    {
        private readonly IProductService _productService;
        public ProductModel(IConfiguration configuration)
        {
            _productService = new ProductService(configuration.GetConnectionString("DefaultConnection"));
        }

        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            var data = _productService.GetProducts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Name", "Description", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name,
                            record.Description,
                            record.Price.ToString()

                        }
                    ).ToArray()

            };
        }
    }

}
