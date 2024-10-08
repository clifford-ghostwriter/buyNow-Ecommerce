using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace buyNow.DAL.Entities
{
    public class Product
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
        //[Required]
        [MaxLength(20)]

		[Column(TypeName = "decimal(18, 4)")]
		public decimal Price { get; set; }
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }
        [Required]
        [MaxLength(20)]

		public string ContentType { get; set; }
		public string ImagerUrl { get; set; }

		[NotMapped]
		public virtual ICollection<SelectListItem> Categories { get; set; }

		public int Category { get; set; }



	}
}
