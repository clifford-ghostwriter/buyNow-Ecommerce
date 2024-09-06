using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buyNow.DAL.Entities
{
    public class Review
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
