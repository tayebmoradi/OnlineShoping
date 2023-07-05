using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int id);
        Product DeleteProduct(int Id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
    }
}
