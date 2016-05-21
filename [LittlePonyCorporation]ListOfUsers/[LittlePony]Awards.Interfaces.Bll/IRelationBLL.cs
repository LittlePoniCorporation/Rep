using _LittlePony_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Interfaces.BLL
{
    public interface IRelationBLL
    {
        IEnumerable<Relations> GetAll();
        IEnumerable<Award> GetAllAwards(Guid id);
        IEnumerable<User> GetAllUsers(Guid id);
        bool Add(Relations relation);
        bool Delete(Guid id);
    }
}
