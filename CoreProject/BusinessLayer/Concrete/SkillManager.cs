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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void TAdd(Skill item)
        {
            _skillDal.Insert(item);
        }

        public void TDelete(Skill item)
        {
            _skillDal.Delete(item);
        }

        public Skill TGetById(int id)
        {
            return _skillDal.GetById(id);
        }

        public List<Skill> TGetList()
        {
            return _skillDal.GetList();
        }

        public void TUpdate(Skill item)
        {
            _skillDal.Update(item);
        }
    }
}
