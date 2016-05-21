using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using _LittlePony_Interfaces.BLL;
using _LittelPony_Interfaces.DAL;
using _LittlePony_Entites;
using _LittlePony_Interfaces.DAL;
using System.IO;
using _LittlePony_Awards.DAL;

namespace _LittlePony_BLL
{
    public class RelationsBLL : IRelationBLL
    {
        private IRelationsDAL DAL;
        private IAwardDAL DALAward;
        private IListOfUsersDAL DALUsers;

        public RelationsBLL()
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
                            DALAward = new _LittlePony_DAL.AwardDAL();
                            DALUsers = new _LittlePony_DAL.UserDAL();
                            DAL = new _LittlePony_DAL.RelationsDAL();
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
                            DALAward = new _LittlePony_DAL.DB.AwardDAL();
                            DALUsers = new _LittlePony_DAL.DB.UsersDAL();
                            DAL = new _LittlePony_DAL.DB.RelationsDAL();
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            throw new ConfigurationFileException("Problem whith the data base ", e);
                        }

                    }
                    break;
            }


        }
        public bool Add(Relations relation)
        {
            try
            {
                DAL.Add(relation);
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

        public IEnumerable<Relations> GetAll()
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

        public IEnumerable<Award> GetUsersAllAward(Guid idUs)
        {
            try
            {
                return DAL.GetAll().Where(x => x.IdUser == idUs).Join(DALAward.GetAll(), x => x.IdAward, y => y.Id, (x, y) => y).ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<User> GetAwardOfAllUsers(Guid idAw)
        {
            try
            {
                return DAL.GetAll().Where(x => x.IdAward == idAw).Join(DALUsers.GetAll(), x => x.IdUser, y => y.Id, (x, y) => y).ToArray();
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
                DAL.Save();
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }
    }
}
