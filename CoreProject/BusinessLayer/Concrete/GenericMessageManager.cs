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
    public class GenericMessageManager : IGenericMessageService
    {
        IGenericMessageDal _genericMessageDal;

        public GenericMessageManager(IGenericMessageDal genericMessageDal)
        {
            _genericMessageDal = genericMessageDal;
        }

        public void TAdd(GenericMessage item)
        {
            _genericMessageDal.Insert(item);
        }

        public void TDelete(GenericMessage item)
        {
            _genericMessageDal.Delete(item);
        }

        public GenericMessage TGetById(int id)
        {
            return _genericMessageDal.GetById(id);
        }

        public List<GenericMessage> TGetList()
        {
            return _genericMessageDal.GetList();
        }

        public void TUpdate(GenericMessage item)
        {
            _genericMessageDal.Update(item);
        }

        public List<GenericMessage> GetListReceiverMessage(string param)
        {
            return _genericMessageDal.GetListByFilter(f => f.Receiver == param);
        }

        public List<GenericMessage> GetListSenderMessage(string param)
        {
            return _genericMessageDal.GetListByFilter(f => f.Sender == param);
        }

        /**/
        public List<GenericMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

    }
}

