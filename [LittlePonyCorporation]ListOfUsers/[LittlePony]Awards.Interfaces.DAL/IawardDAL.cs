using _LittlePony_ListOfUsers.Entites.Awards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Awards.Interfaces.DAL
{
    public interface IAwardDAL
    {
        IEnumerable<Award> GetAll();
        Award Get(Guid id);
        bool Create(Award award);
        bool Delete(Guid id);
        bool Save();
    }
}
