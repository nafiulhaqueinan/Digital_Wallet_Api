using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISendMoney<T, U, V>
    {
        V SendMoney(T sender, U receiver, decimal amount);
        V GetByPhone(U phone);
    }
}
