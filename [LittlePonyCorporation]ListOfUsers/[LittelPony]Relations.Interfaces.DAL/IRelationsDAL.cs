using _LittlePony_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittelPony_Interfaces.DAL
{
    public interface IRelationsDAL
    {
        IEnumerable<Relations> GetAll();
        bool Add(Relations relation);
        bool Delete(Guid id);
    }
}
