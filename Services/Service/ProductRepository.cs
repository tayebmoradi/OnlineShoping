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
                new Product(){ProductId = 1 , Description = "اگر می خواهید یک آکواریوم بامزه و زیبا با چند تا ماهی کوچک و رنگی داشته باشید ... این آکواریوم یک انتخاب مناسب برای همه افرادی است که می خواهند یک آکواریوم کوچک و کم دردسر را تجربه کنند است. این آکواریوم با ظرفیت 3 لیتری برای ماهی های کوچک همانند ماهی های شب عید نوروز، فایتر، گوپی و ... مناسب است . این محصول با رنگ بندی های متنوع و کوچکی آن و کمی تزئین آن با سنگ ریزه ها و یک قطعه مجسمه آکواریومی و یا سبزه کوچک به میز کار، پیشخوان و یا هرجایی از فضای شما را زیبا خواهد کرد. ..." , Barecode = "123456", Name = "تنگ ماهی مدل استوانه شیشه ای" , Price =20000,Photo="1.webp"},
                new Product(){ProductId = 2 , Description = "اگر می خواهید یک آکواریوم بامزه و زیبا با چند تا ماهی کوچک و رنگی داشته باشید ... این آکواریوم یک انتخاب مناسب برای همه افرادی است که می خواهند یک آکواریوم کوچک و کم دردسر را تجربه کنند است. این آکواریوم با ظرفیت 3 لیتری برای ماهی های کوچک همانند ماهی های شب عید نوروز، فایتر، گوپی و ... مناسب است . این محصول با رنگ بندی های متنوع و کوچکی آن و کمی تزئین آن با سنگ ریزه ها و یک قطعه مجسمه آکواریومی و یا سبزه کوچک به میز کار، پیشخوان و یا هرجایی از فضای شما را زیبا خواهد کرد. ..." , Barecode = "123451", Name = "آکواریوم دلسا مدل k320" , Price =10000,Photo="2.webp"},
                new Product(){ProductId = 3 , Description = "اگر می خواهید یک آکواریوم بامزه و زیبا با چند تا ماهی کوچک و رنگی داشته باشید ... این آکواریوم یک انتخاب مناسب برای همه افرادی است که می خواهند یک آکواریوم کوچک و کم دردسر را تجربه کنند است. این آکواریوم با ظرفیت 3 لیتری برای ماهی های کوچک همانند ماهی های شب عید نوروز، فایتر، گوپی و ... مناسب است . این محصول با رنگ بندی های متنوع و کوچکی آن و کمی تزئین آن با سنگ ریزه ها و یک قطعه مجسمه آکواریومی و یا سبزه کوچک به میز کار، پیشخوان و یا هرجایی از فضای شما را زیبا خواهد کرد. ..." , Barecode = "123452", Name = "آکواریوم کد Aqua03 به همراه شن و گیاه" , Price =10000,Photo="3.webp"},
                new Product(){ProductId = 4 , Description = "اگر می خواهید یک آکواریوم بامزه و زیبا با چند تا ماهی کوچک و رنگی داشته باشید ... این آکواریوم یک انتخاب مناسب برای همه افرادی است که می خواهند یک آکواریوم کوچک و کم دردسر را تجربه کنند است. این آکواریوم با ظرفیت 3 لیتری برای ماهی های کوچک همانند ماهی های شب عید نوروز، فایتر، گوپی و ... مناسب است . این محصول با رنگ بندی های متنوع و کوچکی آن و کمی تزئین آن با سنگ ریزه ها و یک قطعه مجسمه آکواریومی و یا سبزه کوچک به میز کار، پیشخوان و یا هرجایی از فضای شما را زیبا خواهد کرد. ..." , Barecode = "123453", Name = "آکواریوم مکانیزه ماهیران مدل MA-21 حجم 9 لیتر" , Price =10000,Photo="4.jpg"},
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
