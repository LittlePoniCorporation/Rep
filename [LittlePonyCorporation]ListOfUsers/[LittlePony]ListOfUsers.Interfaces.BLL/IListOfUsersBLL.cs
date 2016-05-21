using _LittlePony_ListOfUsers.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_ListOfUsers.Interfaces.BLL
{
    public interface IListOfUsersBLL
    {
        IEnumerable<User> GetAllSortBySurname();
        IEnumerable<User> GetAllByCreteria(Func<User, bool> crit);
        IEnumerable<User> GetAll();
        User Get(Guid id);
        bool Create(User user);
        bool Delete(Guid id);
        bool Save();
    }
}
