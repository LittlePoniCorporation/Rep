using System;
using _LittlePony_Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittelPony_Interfaces.DAL
{
   public interface IRegistrateDAL
    {
        Registrate Get(string login);
        bool Create(Registrate reg);
        bool Delete(string login);
        IEnumerable<Registrate> GetAll();
        bool Change(string login, int roleId);
    }
}
