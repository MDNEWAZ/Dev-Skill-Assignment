using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miu.Library.Data;

namespace Miu.Library.Framework
{
    public class ProductService :IProductService
    {
        
        private string _connectionString;

        public ProductService(string connectionString)
        {
            _connectionString = connectionString;

        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            using var dbProvider = new SqlServerDataProvider<Product>(_connectionString);
            var products = dbProvider.GetData("select * from Products");

            var filteredBooks = products.Where(x => x.Name.Contains(searchText)
                                                    || x.Description.Contains(searchText));

            var filteredBooksCount = filteredBooks.Count();
            var totalBooks = products.Count();

            var filteredBooksList = filteredBooks.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return (filteredBooksList, totalBooks, filteredBooksCount);
        }
    }
}
