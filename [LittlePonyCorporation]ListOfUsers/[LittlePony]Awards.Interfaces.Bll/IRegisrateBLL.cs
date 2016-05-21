using _LittlePony_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Interfaces.Bll
{
    public interface IRegistrateBLL
    {
        Registrate Get(string login);
        bool Create(Registrate reg);
        bool Delete(string login);
        IEnumerable<Registrate> GetAll();
        bool Change(string login, int roleId);
    }
}
