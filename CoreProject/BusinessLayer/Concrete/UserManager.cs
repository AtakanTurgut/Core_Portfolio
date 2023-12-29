using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TAdd(User item)
        {
            _userDal.Insert(item);
        }

        public void TDelete(User item)
        {
            _userDal.Delete(item);
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public void TUpdate(User item)
        {
            _userDal.Update(item);
        }
    }
}
