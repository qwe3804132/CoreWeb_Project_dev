using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UrlDb
    {
        private CoreWebDbEntities db;
        public UrlDb()
        {
            db = new CoreWebDbEntities();
        }
        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }

        public tbl_Url GetByID(int Id)
        {
            return db.tbl_Url.Find(Id);
        }

        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();

        }
        
        public void Delete(int id)
        {
            tbl_Url url = db.tbl_Url.Find(id);
            db.tbl_Url.Remove(url);
            Save();
        }

        public void Update(tbl_Url url)
        {
            db.Entry(url).State = EntityState.Modified;
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
