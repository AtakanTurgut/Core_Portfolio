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
    public class ReUserManager : IReUserService
    {
        IReUserDal _reUserDal;

        public ReUserManager(IReUserDal reUserDal)
        {
            _reUserDal = reUserDal;
        }

        public void TAdd(ReUser item)
        {
            _reUserDal.Insert(item);
        }

        public void TDelete(ReUser item)
        {
            _reUserDal.Delete(item);
        }

        public ReUser TGetById(int id)
        {
            return _reUserDal.GetById(id);
        }

        public List<ReUser> TGetList()
        {
            return _reUserDal.GetList();
        }

        public void TUpdate(ReUser item)
        {
            _reUserDal.Update(item);
        }
    }
}
