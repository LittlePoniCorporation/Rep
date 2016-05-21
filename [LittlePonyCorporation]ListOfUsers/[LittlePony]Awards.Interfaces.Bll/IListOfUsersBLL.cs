using _LittlePony_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Interfaces.BLL
{
    public interface IListOfUsersBLL
    {
        IEnumerable<User> GetAllSortBySurname();
        IEnumerable<User> GetAllByCreteria(Func<User, bool> crit);
        IEnumerable<User> GetAll();
        User Get(Guid id);
        bool Create(User user);
        bool Delete(Guid id);
        bool Change(Guid id, string Sur, string Name, string SecName, DateTime Bday);
    }
}
