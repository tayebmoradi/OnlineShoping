using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services.Interface;

namespace OnlineShoping.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DetailsModel(IProductRepository  productRepository)
        {
            _productRepository = productRepository;
        }
        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int id)
        {
            product = _productRepository.GetProductById(id);
        }
    }
}
