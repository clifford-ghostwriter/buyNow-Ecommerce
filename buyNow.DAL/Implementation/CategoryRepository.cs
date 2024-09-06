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
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }
    }
}

