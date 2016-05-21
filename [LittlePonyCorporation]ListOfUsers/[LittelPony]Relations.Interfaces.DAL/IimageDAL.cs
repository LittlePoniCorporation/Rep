using System;
using _LittlePony_Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittelPony_Interfaces.DAL
{
   public interface IimageDAL
    {
        Image Get(Guid Id);
        bool Create(Image img);
        bool Delete(Guid Id);
        bool AddImage(Guid entites, Guid img, string AorU);
        Guid GetImageForEntites(Guid entitesId, string AorU);
    }
}
