using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetById(int id)
        {
            return _writerdal.Get(x => x.WriterID == id);
        }

        public List<Writer> Getlist()
        {
            return _writerdal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Delete(writer); 
        }

        public void WriterUpdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
