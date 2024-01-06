using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericMessageService : IGenericService<GenericMessage>
    {
        List<GenericMessage> GetListSenderMessage(string param);
        List<GenericMessage> GetListReceiverMessage(string param);
    }
}
