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
    public class RegistrateBLL : IRegistrateBLL
    {
        private IRegistrateDAL DAL;
        public RegistrateBLL()
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
                            DAL = new _LittlePony_DAL.DB.RegistrateDAL();
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            throw new Exception("Problem whith the data base ", e);
                        }

                    }
                    break;
            }

        }

        public bool Change(string login, int roleId)
        {
            return DAL.Change(login, roleId);
        }

        public bool Create(Registrate reg)
        {
               return DAL.Create(reg);
        }

        public bool Delete(string login)
        {
            try
            {
                DAL.Delete(login);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Registrate Get(string login)
        {
                return DAL.Get(login);
        }

        public IEnumerable<Registrate> GetAll()
        {
            return DAL.GetAll().ToArray();
        }
    }
}
