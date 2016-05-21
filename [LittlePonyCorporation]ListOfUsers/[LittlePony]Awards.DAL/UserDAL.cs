using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using _LittlePony_Interfaces.DAL;
using _LittlePony_Entites;
using _LittlePony_Awards.DAL;

namespace _LittlePony_DAL
{
    public class UserDAL : IListOfUsersDAL
    {
        public static List<User> ListOfUser = new List<User>();
        public static string filename;
 
        public UserDAL()
        {
            if (ListOfUser.ToArray().Length == 0)
            {
                try
                {
                    filename = ConfigurationManager.AppSettings["UserFilePath"];
                }
                catch (DirectoryNotFoundException e)
                {
                    throw new ConfigurationFileException("Problem whith the file path", e);
                }

                if (!(File.Exists(filename)))
                {
                    File.Create(filename);
                }
                else
                {
                    System.IO.StreamReader file = null;
                    try
                    {
                        file = new System.IO.StreamReader(filename);
                    }
                    catch (Exception e)
                    {
                        Logger.Logger.CreateLog(e);
                    }
                    if (file != null)
                    {
                        string line;
                        string[] temp = new string[5];
                        while ((line = file.ReadLine()) != null)
                        {
                            temp = line.Split('{');
                            ListOfUser.Add(new User(temp[1], temp[2], temp[3], DateTime.Parse(temp[4]), Guid.Parse(temp[0])));
                        }
                    }

                    file.Close();
                }
            }
        }

        public bool Create(User user)
        {
            try
            {
                ListOfUser.Add(user);
                return true;
            }
            catch (IOException e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var temp = ListOfUser.FirstOrDefault(x => x.Id == id);
                if (temp == null)
                {
                    return false;
                }
                ListOfUser.Remove(temp);
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
            return ListOfUser.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var item in ListOfUser)
            {
                yield return item;
            }
        }

        public bool Save()
        {
//FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(filename, false);
            for (int i = 0; i < ListOfUser.Count(); i++)
            {
                sw.Write(ListOfUser[i].Id.ToString() + "{" + ListOfUser[i].Surname + "{" + ListOfUser[i].Name + "{" + ListOfUser[i].Second_Name + "{" + ListOfUser[i].BDay.ToString("dd.MM.yyyy") + "\r\n");
            }
            sw.Close();
            return true;
        }

        public bool AddImage(Guid user, Guid img)
        {
            return true;
        }
    }
}
