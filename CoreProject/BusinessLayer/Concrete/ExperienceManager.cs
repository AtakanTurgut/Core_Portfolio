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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void TAdd(Experience item)
        {
            _experienceDal.Insert(item);
        }

        public void TDelete(Experience item)
        {
            _experienceDal.Delete(item);
        }

        public Experience TGetById(int id)
        {
            return _experienceDal.GetById(id);
        }

        public List<Experience> TGetList()
        {
            return _experienceDal.GetList();
        }

        public List<Experience> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience item)
        {
            _experienceDal.Update(item);
        }
    }
}
