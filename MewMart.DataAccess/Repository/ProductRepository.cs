using MewMart.DataAccess.Data;
using MewMart.DataAccess.Repository.IRepository;
using MewMart.Models;

namespace MewMart.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault( u => u.Id == obj.Id);
            if (objFromDb != null) 
            { 
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Category = obj.Category;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Manufacturer = obj.Manufacturer;
                objFromDb.Prize = obj.Prize;
                objFromDb.Prize2 = obj.Prize2;
                objFromDb.Prize5 = obj.Prize5;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
