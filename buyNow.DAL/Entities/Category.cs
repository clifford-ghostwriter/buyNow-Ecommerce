using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buyNow.DAL.Entities
{
    internal class Category
    {
        [Key]
        public int Id { get; set; }
       
        [DisplayName("Category Name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public int Description { get; set; }

        public virtual ICollection<Product> Categories { get; set;}

       

    

    }
}
