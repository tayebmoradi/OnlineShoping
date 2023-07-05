using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services.Interface;

namespace OnlineShoping.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public EditModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            if(id  == 0)
            {
                Product = null;
            }
           Product =  _productRepository.GetProductById(id);
        }

        public IActionResult OnPost()
        {
            if (Product.ProductId == 0)
            {
                Product = _productRepository.AddProduct(Product);
                return RedirectToPage("index");
            }
            else
            {
               
              Product =  _productRepository.UpdateProduct(Product);
              return RedirectToPage("index");
              
            }
            
        }
    }
}
