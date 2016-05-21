using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _LittelPony_Relations.Interfaces.DAL;
using _LittlePony_ListOfUsers.Entites;
using _LittlePony_ListOfUsers.Entites.Awards;

namespace _LittlePony_RelationsDAL
{
    public class RelationsDAL : IRelationsDAL
    {
        public static Dictionary<User, Award[]> dic = new Dictionary<User, Award[]>();

        public static DirectoryInfo mydirectory = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ListOfUsers");
        public static string filename = Path.Combine(mydirectory.FullName, "relations.txt");

        public RelationsDAL()
        {
            FileInfo[] ff = mydirectory.GetFiles();
            int r = 0;
            foreach (var item in ff)
            {
                if (item.Name == "relations.txt")
                {
                    r++;
                    return;
                }
            }
            if (r == 1)
            {
                File.Create(Path.Combine(mydirectory.FullName, "relations.txt"));
            }
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                if (file != null)
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        int t = 0;
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i]=='{')
                            {
                                t++;
                            }
                        }
                        string[] temp = new string[t];
                        temp = line.Split('{');
                        Award[] aw = new Award[t - 1];
                        for (int i = 0; i < t-1; i++)
                        {
                            Award.Get(temp[i + 1]);
                        }
                        dic.Add()
                            (new Award(temp[1], Guid.Parse(temp[0])));
                    }
                }

                file.Close();
            }
        }

        public bool Delete(Guid id)
        {
            var temp = ListOfAwards.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                return false;
            }
            ListOfAwards.Remove(temp);
            return true;
        }


        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        User IRelationsDAL.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Create(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < ListOfAwards.Count(); i++)
            {
                sw.Write(ListOfAwards[i].Id.ToString() + "{" + ListOfAwards[i].Title + "\r\n");
            }
            sw.Close();
            return true;
        }
    }
}

