using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services.Interface;

namespace OnlineShoping.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [BindProperty]
        public IEnumerable<Product> products { get; set; }

        public void OnGet()
        {
         products = _productRepository.GetAllProduct().ToList();
        }


        public IActionResult OnPost(int id)
        {
            _productRepository.DeleteProduct(id);
            return Page();

        }
    }
}
