using _LittlePony_Entites;
using _LittlePony_Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _LittlePony_ListOfUsers.ASP.NET.Models
{
    public class ListRegistrate
    {
        private IRegistrateBLL RBLL;

        public ListRegistrate()
        {
            RBLL = new _LittlePony_BLL.RegistrateBLL();
        }

        public bool Create(Registrate reg)
        {
            return RBLL.Create(reg);
        }

        public bool Delete(string login)
        {
            return RBLL.Delete(login);
        }

        public Registrate Get(string login)
        {
            return RBLL.Get(login);
        }

        public bool Change(string login, int roleId)
        {
            return RBLL.Change(login, roleId);
        }

        public IEnumerable<Registrate> GetAll()
        {
            return RBLL.GetAll().ToArray();
        }

    }
}