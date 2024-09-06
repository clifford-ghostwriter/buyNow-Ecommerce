using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buyNow.DAL.Entities;
using buyNow.DAL.Interface;
using buyNow_Ecommerce.Data;

namespace buyNow.DAL.Implementation
{
   public class ProductRepository : Repository<Product>, IProduct
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
