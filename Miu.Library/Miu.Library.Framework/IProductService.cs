using System;
using System.Collections.Generic;
using System.Text;

namespace Miu.Library.Framework
{
   public interface IProductService
    {
        (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex,
            int pageSize,
            string searchText,
            string sortText);
    }
}
