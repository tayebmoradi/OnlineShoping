using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = " نام محصول نمی تواند خالی باشد")]
        public string Name { get; set; }
        [Required(ErrorMessage = "توضیحات محصول نمی تواند خالی باشد")]
        public string Description { get; set; }
        [Required(ErrorMessage = "بارکد محصول نمی تواند خالی باشد")]
        public string Barecode { get; set; }
        [Required(ErrorMessage = "قیمت محصول نمی تواند خالی باشد")]
        public double Price { get; set; }
        [Required(ErrorMessage = "تصویر محصول نمی تواند خالی باشد")]
        public string Photo { get; set; }
    }
}
