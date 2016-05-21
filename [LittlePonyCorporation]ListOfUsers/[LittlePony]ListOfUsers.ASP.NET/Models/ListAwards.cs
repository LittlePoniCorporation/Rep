using _LittlePony_Entites;
using _LittlePony_Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _LittlePony_ListOfUsers.ASP.NET.Models
{
    public class ListAwards
    {
        private IAwardBLL ABLL;

        public ListAwards()
        {
            ABLL = new _LittlePony_BLL.AwardBLL();
        }

        public bool Create(Award award)
        {
            return ABLL.Create(award);
        }

        public bool Delete(Guid id)
        {
            return ABLL.Delete(id);
        }

        public Award Get(Guid id)
        {
            return ABLL.Get(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return ABLL.GetAll().ToArray();
        }

        public IEnumerable<Award> GetAllSortByTitle()
        {
            return ABLL.GetAll().OrderBy(x => x.Title).ToArray();
        }

        public bool Change(Guid id, string Title)
        {
            return ABLL.Change(id, Title);
        }
    }
}