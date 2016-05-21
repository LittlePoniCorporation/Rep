using _LittlePony_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Interfaces.DAL
{
    public interface IAwardDAL
    {
        IEnumerable<Award> GetAll();
        Award Get(Guid id);
        bool Create(Award award);
        bool Delete(Guid id);
        bool Change(Guid id, string Title);
    }
}
