using Common.Domain;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.TxProduct
{
    public class GetExternalPropertyListQuery : IRequestWrapper<IEnumerable<ProductExternalPropertyModel>>
    {
        [Required(ErrorMessage = "ProductId required")]
        public int ProductId { get; set; }
    }
}
