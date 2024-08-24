using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_AspNet_LS3_second.Entities
{
    public class Product
    {
        [DisplayName("Product_ID")]
        public int Id { get; set; }


        [DisplayName("Pr_Name")]
        [Required(ErrorMessage = "Product Name can not be empty !")]
        public string Name { get; set; }

        [DisplayName("Pr_Description")]
        [Required(ErrorMessage = "Product Description can not be empty !")]
        public string Description { get; set; }

        [DisplayName("Pr_Discount")]
        [Required(ErrorMessage = "Product Discount can not be empty !")]
        [Range(0.5, double.MaxValue, ErrorMessage = "Discount can not be smaller than 0.5 !")]
        [RegularExpression(@"^\d+,\d+$", ErrorMessage = "TRUE_FORMAT(0,1) - FALSE_FORMAT(0.1)")]
        public double Discount { get; set; }

        [DisplayName("Pr_Price")]
        [Required(ErrorMessage = "Product Price can not be empty !")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price can not be smaller than 0.1 !")]
        [RegularExpression(@"^\d+,\d+$", ErrorMessage = "TRUE_FORMAT(0,1) - FALSE_FORMAT(0.1)")]
        public double Price { get; set; }

        [DisplayName("Pr_ImagePath")]
        [Required(ErrorMessage = "Product ImagePath can not be empty !")]
        public string ImagePath { get; set; }
    }
}
