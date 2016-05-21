using _LittlePony_ListOfUsers.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LittlePony_ListOfUsers.Entites;
using System.IO;

namespace _LittlePony_ListOfUsers.DAL.Collection
{
    public class DAL : IListOfUsersDAL
    {
        public static List<User> ListOfUser = new List<User>();
        public static DirectoryInfo mydirectory = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ListOfUsers");
        public static string filename = Path.Combine(mydirectory.FullName, "users.txt");

        public DAL()
        {
            FileInfo[] ff = mydirectory.GetFiles();
            int r = 0;
            foreach (var item in ff)
            {
                if (item.Name == "users.txt")
                {
                    r++;
                    return;
                }
            }
            if (r == 1)
            {
                File.Create(Path.Combine(mydirectory.FullName, "users.txt"));
            }
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
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

        public bool Create(User user)
        {
            ListOfUser.Add(user);
            return true;
        }

        public bool Delete(Guid id)
        {
            var temp = ListOfUser.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                return false;
            }
            ListOfUser.Remove(temp);
            return true;
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
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < ListOfUser.Count(); i++)
            {
                sw.Write(ListOfUser[i].Id.ToString() + "{" + ListOfUser[i].Surname + "{" + ListOfUser[i].Name + "{" + ListOfUser[i].Second_Name + "{" + ListOfUser[i].BDay.ToString("dd.MM.yyyy") + "\r\n");
            }
            sw.Close();
            return true;
        }
    }
}
