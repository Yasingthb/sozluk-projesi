using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);

        }

        public List<Message> GetDraftMessage()
        {
            return _messagedal.List(x => x.DraftMessage == true);
        }

        public List<Message> GetListInbox()
        {
            return _messagedal.List(x=>x.ReceiverMail=="admin@admin.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messagedal.List(x => x.SenderMail == "admin@admin.com");

        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }
    }
}
