using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.Service
{
    public class ProductRepository : IProductRepository
    {
        public static IList<Product> Product;
        public ProductRepository()
        {
            Product = new List<Product>()
            {
                new Product(){ProductId = 1 , Name = "aquoa" , Barecode = "123456", Description = "تنگ ماهی مدل استوانه شیشه ای" , Price =20000,Photo="./wwwroot/img/1.jpg"},
                new Product(){ProductId = 2 , Name = "aquoa" , Barecode = "123451", Description = "تنگ ماهی مدل استوانه شیشه ای" , Price =10000,Photo="./wwwroot/img/2.jpg"},
                new Product(){ProductId = 3 , Name = "aquoa" , Barecode = "123452", Description = "تنگ ماهی مدل استوانه شیشه ای" , Price =10000,Photo="./wwwroot/img/3.jpg"},
                new Product(){ProductId = 4 , Name = "aquoa" , Barecode = "123453", Description = "تنگ ماهی مدل استوانه شیشه ای" , Price =10000,Photo="./wwwroot/img/4.jpg"},
            };
        }

        public Product AddProduct(Product product)
        {
            int maxId = Product.Max(t => t.ProductId);
            var record = new Product()
            {
                ProductId = maxId++,
                Name = product.Name,
                Barecode = product.Barecode,
                Price = product.Price,
                Photo = product.Photo,
                Description = product.Description,
            };
            Product.Add(record);
            return record;
        }

        public Product DeleteProduct(int Id)
        {
            Product DeleteId = Product.FirstOrDefault(x => x.ProductId == Id);
            if (DeleteId != null)
            {
                Product.Remove(DeleteId);
            }
            return null;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var ProductList = Product.ToList();
            return ProductList;
        }

        public Product GetProductById(int id)
        {
            var record = Product.FirstOrDefault(x => x.ProductId == id);
            if (record != null)
            {
                return record;
            }
            return null;

        }

        public Product UpdateProduct(Product product)
        {
            Product ProdtctId = Product.First(v => v.ProductId == product.ProductId);
            if (ProdtctId != null)
            {
                ProdtctId.Name = product.Name;
                ProdtctId.Barecode = product.Barecode;
                ProdtctId.Price = product.Price;
                ProdtctId.Photo = product.Photo;
                ProdtctId.Description = product.Description;
            }

            return ProdtctId;
        }
    }
}
