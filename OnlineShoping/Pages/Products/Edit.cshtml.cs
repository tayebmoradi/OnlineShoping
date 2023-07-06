using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services.Interface;

namespace OnlineShoping.Pages.Products
{
	public class EditModel : PageModel
	{
		private readonly IProductRepository _productRepository;
		private readonly IWebHostEnvironment webHostEnvironment;

		public EditModel(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
		{
			_productRepository = productRepository;
			this.webHostEnvironment = webHostEnvironment;
		}

		[BindProperty]
		public IFormFile Photo { get; set; }
		[BindProperty]
		public int ProductId { get; set; }
		[BindProperty]
		public Product Product { get; set; }
		public void OnGet(int id)
		{

			if (id == 0)
			{
				Product = null;
			}
			Product = _productRepository.GetProductById(id);
		}

		public IActionResult OnPost(Product product)
		{
			if (ModelState.IsValid)
			{
				if (Photo != null)
				{
					if (product.Photo != null)
					{
						string FileFolder =
						Path.Combine(webHostEnvironment.WebRootPath, "css", product.Photo);
						System.IO.File.Delete(FileFolder);

					}
                    product.Photo = ProcessUploadFile();
                }
				if (Product.ProductId == 0)
				{
					Product = _productRepository.AddProduct(Product);
					return RedirectToPage("index");
				}
				else
				{
                    
                    
					Product = _productRepository.UpdateProduct(Product);
					return RedirectToPage("index");

				}
			}
            return RedirectToPage("index");


        }
		private string ProcessUploadFile()
		{
			string uniqueFileName = null;

			if (Photo != null)
			{
				string UploadsFolder =
					Path.Combine(webHostEnvironment.WebRootPath, "css");
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
