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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void TAdd(Portfolio item)
        {
            _portfolioDal.Insert(item);
        }

        public void TDelete(Portfolio item)
        {
            _portfolioDal.Delete(item);
        }

        public Portfolio TGetById(int id)
        {
            return _portfolioDal.GetById(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDal.GetList();
        }

        public void TUpdate(Portfolio item)
        {
            _portfolioDal.Update(item);
        }
    }
}
