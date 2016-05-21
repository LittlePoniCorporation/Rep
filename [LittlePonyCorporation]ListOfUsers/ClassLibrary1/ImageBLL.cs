using _LittlePony_Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LittlePony_Entites;
using _LittlePony_Interfaces.DAL;
using System.Configuration;
using System.IO;
using _LittelPony_Interfaces.DAL;

namespace _LittlePony_BLL
{
    public class ImageBLL : IimageBLL
    {
        private IimageDAL DAL;
        public ImageBLL()
        {
            string temp;
            try
            {
                temp = ConfigurationManager.AppSettings["TypeDal"];
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Some problem whith file", ex);
            }
            switch (temp)
            {
                case "DB":
                    {
                        try
                        {
                            DAL = new _LittlePony_DAL.DB.ImageDAL();
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            throw new Exception("Problem whith the data base ", e);
                        }

                    }
                    break;
            }

        }

        public bool AddImage(Guid entites, Guid img, string AorU)
        {
            try
            {
                DAL.AddImage(entites, img, AorU);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Change(Guid Id, Image img)
        {
            try
            {
                DAL.Delete(Id);
                DAL.Create(new Image(Id, img.Content, img.ContentType));
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Create(Image img)
        {
            try
            {
                DAL.Create(img);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                DAL.Delete(Id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Image Get(Guid Id)
        {
            try
            {
                return DAL.Get(Id);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public Guid GetImageForEntites(Guid enttitesId, string AorU)
        {
            try
            {
                return DAL.GetImageForEntites(enttitesId, AorU);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }
    }
}
