using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _LittlePony_Interfaces.BLL;
using _LittlePony_Entites;
using _LittlePony_Interfaces.DAL;
using System.IO;
using _LittlePony_DAL.Exeption;

namespace _LittlePony_BLL
{
    public class UsersBLL : IListOfUsersBLL
    {
        private IListOfUsersDAL DAL;

        public UsersBLL()
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
                            DAL = new _LittlePony_DAL.UserDAL();
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
                            DAL = new _LittlePony_DAL.DB.UsersDAL();
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            throw new ConfigurationFileException("Problem whith the data base ", e);
                        }

                    }
                    break;
            }
        }

        public bool Change(Guid id, string Sur, string Name, string SecName, DateTime Bday)
        {
            try
            {
                DAL.Delete(id);
                DAL.Create(new User(Sur,Name,SecName,Bday,id));
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Create(User user)
        {
            try
            {
                DAL.Create(user);
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
        public User Get(Guid id)
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

        public IEnumerable<User> GetAll()
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

        public IEnumerable<User> GetAllByCreteria(Func<User, bool> crit)
        {
            try
            {
                return DAL.GetAll().Where(crit).ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<User> GetAllSortBySurname()
        {
            try
            {
                return DAL.GetAll().OrderBy(x => x.Surname).ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

    }
}