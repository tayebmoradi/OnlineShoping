using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ProductRepository : IProductRepository
    {
        public static IEnumerable<Product> Product ;
        public ProductRepository() 
        {
            Product = new List<Product>() 
            {
                new Product(){ProductId = 1 , Name = "aquoa" , Barecode = "123456", Description = "عرض 60 سانتی متر" , Price =10000,Photo="./wwwroot/img/1.jpg"},
                new Product(){ProductId = 2 , Name = "aquoa" , Barecode = "123451", Description = "عرض 90 سانتی متر" , Price =10000,Photo="./wwwroot/img/2.jpg"},
                new Product(){ProductId = 3 , Name = "aquoa" , Barecode = "123452", Description = "عرض 85 سانتی متر" , Price =10000,Photo="./wwwroot/img/3.jpg"},
                new Product(){ProductId = 4 , Name = "aquoa" , Barecode = "123453", Description = "عرض 80 سانتی متر" , Price =10000,Photo="./wwwroot/img/4.jpg"},
            };
        }
        public IEnumerable<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
