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
    public class UserMessageManager : IUserMessageService
    {
        IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public List<UserMessage> GetUserMessagesWithUserService()
        {
            return _userMessageDal.GetUserMessagesWithUser();
        }

        public void TAdd(UserMessage item)
        {
            _userMessageDal.Insert(item);
        }

        public void TDelete(UserMessage item)
        {
            _userMessageDal.Delete(item);
        }

        public UserMessage TGetById(int id)
        {
            return _userMessageDal.GetById(id);
        }

        public List<UserMessage> TGetList()
        {
            return _userMessageDal.GetList();
        }

        public void TUpdate(UserMessage item)
        {
            _userMessageDal.Update(item);
        }
    }
}
