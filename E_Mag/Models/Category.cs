using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Mag.Models
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CategoryId {get;set;}

        [Display(Name ="Категория")]
        [MaxLength(20)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product>Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}