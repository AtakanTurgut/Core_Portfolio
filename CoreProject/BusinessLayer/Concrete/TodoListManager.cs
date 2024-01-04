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
    public class TodoListManager : ITodoListService
    {
        ITodoListDal _todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public void TAdd(TodoList item)
        {
            _todoListDal.Insert(item);
        }

        public void TDelete(TodoList item)
        {
            _todoListDal.Delete(item);
        }

        public TodoList TGetById(int id)
        {
            return _todoListDal.GetById(id);
        }

        public List<TodoList> TGetList()
        {
            return _todoListDal.GetList();
        }

        public List<TodoList> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(TodoList item)
        {
            _todoListDal.Update(item);
        }
    }
}
