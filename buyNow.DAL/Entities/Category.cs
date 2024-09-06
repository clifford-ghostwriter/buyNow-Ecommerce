using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace buyNow.DAL.Entities
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
       
        [DisplayName("Category Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }


        [ForeignKey("CategoryId")]
        [BindNever]
        public virtual ICollection<Product>? Categories { get; set;}

       

    

    }
}
