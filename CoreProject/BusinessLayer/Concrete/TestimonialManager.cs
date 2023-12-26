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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial item)
        {
            _testimonialDal.Insert(item);
        }

        public void TDelete(Testimonial item)
        {
            _testimonialDal.Delete(item);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDal.GetList();
        }

        public void TUpdate(Testimonial item)
        {
            _testimonialDal.Update(item);
        }
    }
}
