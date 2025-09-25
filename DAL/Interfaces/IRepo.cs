using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID,RET>
    {
        RET Create(CLASS obj);
        List<CLASS> Read();
        CLASS Read(ID id);
        
        RET Update(CLASS obj);
        RET Delete(ID id);

    }
}
