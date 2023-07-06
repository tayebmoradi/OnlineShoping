using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services.Interface;
using Services.Service;

namespace OnlineShoping.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AddModel(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {

            if (Photo != null)
            {
                if (Product.Photo != null)
                {
                    string FileFolder =
                    Path.Combine(webHostEnvironment.WebRootPath, "img", Product.Photo);
                    System.IO.File.Delete(FileFolder);

                }
                Product.Photo = ProcessUploadFile();
            }

            productRepository.AddProduct(Product);
            return RedirectToPage("index");

        }
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string UploadsFolder =
                    Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(UploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
