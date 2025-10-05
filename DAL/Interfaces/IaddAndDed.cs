using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IaddAndDed<CLASS, ID, RET>
    {
        RET AddMoney(ID id, decimal amount);
        RET DeductMoney(ID id, decimal amount);

    }
}
