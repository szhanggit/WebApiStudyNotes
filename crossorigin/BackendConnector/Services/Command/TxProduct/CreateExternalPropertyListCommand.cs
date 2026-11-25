using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Common.Services.Wrappers;
using Common.Domain;

namespace Services.Command.TxProduct
{
    public class CreateExternalPropertyListCommand : IRequestWrapper<int>
    {
        [Required(ErrorMessage = "ProductId required")]
        public int ProductId { get; set; }
        public List<ProductExternalPropertyModel> ProductExternalPropertyList { get; set; }
    }
}
