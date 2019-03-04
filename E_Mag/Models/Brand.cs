using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Mag.Models
{
    public class Brand
    {
        [Key]
        [ScaffoldColumn(false)]
        public int BrandId { get; set; }

        [Display(Name = "Бренд")]
        [MaxLength(20)]
        public string BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Brand()
        {
            Products = new HashSet<Product>();
        }        
    }
}