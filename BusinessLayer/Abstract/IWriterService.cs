using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> Getlist();
        void WriterAdd(Writer writer);

        void WriterDelete(Writer writer);

        void WriterUpdate(Writer writer);

        Writer GetById(int id);

    }
}
