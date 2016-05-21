using _LittlePony_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Interfaces.Bll
{
    public interface IimageBLL
    {
        Image Get(Guid Id);
        bool Create(Image img);
        bool Delete(Guid Id);
        bool Change(Guid Id, Image img);
        bool AddImage(Guid entites, Guid img, string AorU);
        Guid GetImageForEntites(Guid enttitesId, string AorU);
    }
}
