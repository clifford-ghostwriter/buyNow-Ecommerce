using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buyNow.DAL.Entities
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Brand Name")]
        public string BrandName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        [Required]
        [MaxLength(200)]
        public string Features { get; set; }
        [Required]
        [MaxLength(20)]
        public int Price { get; set; }
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }
        [Required]
        [MaxLength(20)]
        public string ImagerUrl { get; set; }

    }
}
