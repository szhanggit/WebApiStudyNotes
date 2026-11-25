using System.Web.Http;

namespace ExampleApp.Models {
    public class Product {
        public int ProductID { get; set; }
        public string Name { get; set; }
        [HttpBindRequired]
        public decimal Price { get; set; }
        [HttpBindNever]
        public bool IncludeInSale { get; set; }
    }
}


/*
 [Compare("OtherProperty")]
 [CreditCard]
 [Email]
 [Enum(typeof(MyEnum)]
 [MaxLength(10)]
 [MinLength(2)]
 [Range(10, 20)]
 [RegularExpression("blue|green")]
 [Required]
 [StringLength(10)]
     */
