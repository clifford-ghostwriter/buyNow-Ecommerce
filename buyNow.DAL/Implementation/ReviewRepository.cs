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
   public class ReviewRepository : Repository<Review>, IReview
    {

        private ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
