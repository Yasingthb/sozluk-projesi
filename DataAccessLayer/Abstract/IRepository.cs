using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> //T = TYPE Gönderdiğimiz entity tipi demek
    {
        List<T> List();

        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        List<T> List(Expression<Func<T,bool>> filter);//Buradaki İfade Şartlı Listeleme Yapar örneğin Yasin isimdekileri getir gibi bir spesifik durum


    }
}
