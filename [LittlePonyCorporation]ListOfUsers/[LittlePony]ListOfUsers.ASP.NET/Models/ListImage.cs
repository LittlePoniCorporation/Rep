using _LittlePony_Entites;
using _LittlePony_Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _LittlePony_ListOfUsers.ASP.NET.Models
{
    public class ListImage
    {
        private IimageBLL IBLL;

        public ListImage()
        {
            IBLL = new _LittlePony_BLL.ImageBLL();
        }

        public bool Create(Image img)
        {
            return IBLL.Create(img);
        }

        public bool Delete(Guid id)
        {
            return IBLL.Delete(id);
        }

        public Image Get(Guid id)
        {
            return IBLL.Get(id);
        }

        public bool Change(Guid id, Image img)
        {
            return IBLL.Change(id, img);
        }

        public bool AddImage(Guid entites, Guid img, string AorU)
        {
            return IBLL.AddImage(entites, img, AorU);
        }

        public Guid GetImageForEntites(Guid entitesId, string AorU)
        {
            return IBLL.GetImageForEntites(entitesId, AorU);
        }

    }
}