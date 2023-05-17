using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class ProductDTO 
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual string? CategoryName { get; set; }

        public string? ImageLink { get; set; }

    }
}
