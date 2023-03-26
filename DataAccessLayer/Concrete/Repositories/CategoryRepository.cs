using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

        Context c= new Context();
        DbSet<Category> _object;
        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();//Context'te değişiklikleri kaydet demek ado.net karşılığı ise ExecuteNonQuery(); metotudur
        }

        public List<Category> List()
        {
            /*
             Entity Framework Verileri listelemek için kullanılan metot ToList()
            Diğer işe yarar ifadeler
            ToList(şuanki)
            Add
            Remove
            Find
            */
            return _object.ToList();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
