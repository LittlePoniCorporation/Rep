using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _LittlePony_Entites;
using _LittlePony_Interfaces.DAL;
using _LittlePony_Interfaces.Bll;
using _LittlePony_Awards.DAL;
using System.IO;

namespace _LittlePony_BLL
{
    public class AwardBLL : IAwardBLL
    {
        private IAwardDAL DAL;

        public AwardBLL()
        {
            string temp;
            try
            {
                temp = ConfigurationManager.AppSettings["TypeDal"];
            }
            catch (FileNotFoundException ex)
            {
                throw new ConfigurationFileException("Some problem whith file", ex);
            }
            switch (temp)
            {
                case "Files":
                    {
                        try
                        {
                            DAL = new _LittlePony_DAL.AwardDAL();
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            throw new ConfigurationFileException("Problem whith the file path ", e);
                        }
                    }
                    break;
                case "DB":
                    {
                        try
                        {
                            DAL = new _LittlePony_DAL.DB.AwardDAL();
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            throw new ConfigurationFileException("Problem whith the data base ", e);
                        }

                    }
                    break;
            }
        }

        public bool Create(Award award)
        {
            try
            {
                DAL.Create(award);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                DAL.Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Award Get(Guid id)
        {
            try
            {
                return DAL.Get(id);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            try
            {
                return DAL.GetAll().ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<Award> GetAllSortByTitle()
        {
            try
            {
                return DAL.GetAll().OrderBy(x => x.Title).ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public bool Save()
        {
            try
            {
                return DAL.Save();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }
    }
}
