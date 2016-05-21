using _LittlePony_ListOfUsers.Interfaces.BLL;
using _LittlePony_ListOfUsers.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _LittlePony_ListOfUsers.Entites;

namespace _LittlePony_ListOfUsers.BLL.ListLogic
{
    public class ListLogic : IListOfUsersBLL
    {
        private IListOfUsersDAL DAL;

        public ListLogic()
        {
            string temp = ConfigurationManager.AppSettings["TypeDal"];
            switch (temp)
            {
                case "Files":
                    {
                        DAL = new _LittlePony_ListOfUsers.DAL.Collection.DAL();
                    }
                break;
            }
        }
       
        public bool Create(User user)
        {
            return DAL.Create(user);
        }

        public bool Delete(Guid id)
        {
            return DAL.Delete(id);
        }

        public User Get(Guid id)
        {
            return DAL.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return DAL.GetAll().ToArray();
        }

        public IEnumerable<User> GetAllByCreteria(Func<User, bool> crit)
        {
            return DAL.GetAll().Where(crit).ToArray();
        }

        public IEnumerable<User> GetAllSortBySurname()
        {
            return DAL.GetAll().OrderBy(x => x.Surname).ToArray();
        }

        public bool Save()
        {
            return DAL.Save();
        }
    }
}