using _LittlePony_ListOfUsers.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_ListOfUsers.Interfaces.DAL
{
    public interface IListOfUsersDAL
    {
        IEnumerable<User> GetAll();
        User Get(Guid id);
        bool Create(User user);
        bool Delete(Guid id);
        bool Save();
    }
}
