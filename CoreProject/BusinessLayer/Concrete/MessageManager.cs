using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message item)
        {
            _messageDal.Insert(item);
        }

        public void TDelete(Message item)
        {
            _messageDal.Delete(item);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public List<Message> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message item)
        {
            _messageDal.Update(item);
        }

    }
}
