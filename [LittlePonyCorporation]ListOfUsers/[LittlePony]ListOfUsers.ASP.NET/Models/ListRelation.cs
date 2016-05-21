using _LittlePony_Entites;
using _LittlePony_Interfaces.Bll;
using _LittlePony_Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _LittlePony_ListOfUsers.ASP.NET.Models
{
    public class ListRelation
    {
        private IRelationBLL RBLL;

        public ListRelation()
        {
            RBLL = new _LittlePony_BLL.RelationsBLL();
        }

        public bool Add(Relations relation)
        {
            return RBLL.Add(relation);
        }

        public bool Delete(Guid id)
        {
            return RBLL.Delete(id);
        }

        public IEnumerable<Award> GetAllAwards(Guid idUs)
        {
            return RBLL.GetAllAwards(idUs);
        }

        public IEnumerable<User> GetAllUsers(Guid idAw)
        {
            return RBLL.GetAllUsers(idAw);
        }
    }
}