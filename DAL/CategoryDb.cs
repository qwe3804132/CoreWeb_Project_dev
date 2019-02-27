using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private CoreWebDbEntities db;
        public CategoryDb()
        {
            db = new CoreWebDbEntities();
        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetByID(int Id)
        {
            return db.tbl_Category.Find(Id);
        }

        public void Insert(tbl_Category category)
        {
            db.tbl_Category.Add(category);
            Save();

        }

        public void Delete(int Id)
        {
            tbl_Category category = db.tbl_Category.Find(Id);
            db.tbl_Category.Remove(category);
            Save();
        }

        public void Update(tbl_Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
        //tbl_Url GetByID(int Id);
        //void Insert(tbl_Url url);
        //void Delete(int Id);
        //void Update(tbl_Url url);
        //void Save();

    }
}
