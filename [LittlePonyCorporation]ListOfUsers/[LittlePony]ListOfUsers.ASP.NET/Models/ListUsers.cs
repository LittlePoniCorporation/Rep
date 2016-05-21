using _LittlePony_Entites;
using _LittlePony_Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _LittlePony_ListOfUsers.ASP.NET.Models
{
    public class ListUsers
    {
        private IListOfUsersBLL BLL;

        public ListUsers()
        {
            BLL = new _LittlePony_BLL.UsersBLL();
        }

        public bool Create(User user)
        {
            return BLL.Create(user);
        }

        public bool Delete(Guid id)
        {
            return BLL.Delete(id);
        }

        public User Get(Guid id)
        {
            return BLL.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return BLL.GetAll().ToArray();
        }

        public bool Change(Guid id, string Sur, string Name, string SecName, DateTime Bday)
        {
            return BLL.Change(id, Sur, Name, SecName, Bday);
        }
    }
}