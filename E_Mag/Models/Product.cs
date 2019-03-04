using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Mag.Models
{
    
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Display(Name = "Товар")]
        [MaxLength(20)]
        public string ProductName { get; set; }

        public bool IsNew { get; set; }

        public bool IsSale { get; set; }

        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date)]       
        public DateTime DateOfAdding { get; set; }

        [Display(Name ="Стоимость")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name ="Описание")]
        public string Info { get; set; }

        [MaxLength(100)]
        public string Img { get; set; }

        public int WebID { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        //public List<Category> Categories { get; set; }

        [Display(Name = "Бренд")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Order>Orders { get; set; }  

        public Product()
        {
            Orders = new HashSet<Order>();
            //Categories = new List<Category>();            
        }
      
    }
}