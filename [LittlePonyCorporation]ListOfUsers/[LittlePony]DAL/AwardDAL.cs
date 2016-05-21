using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using _LittlePony_Interfaces.DAL;
using _LittlePony_Entites;
using _LittlePony_DAL.Exeption;

namespace _LittlePony_DAL
{
    public class AwardDAL : IAwardDAL
    {
        public static List<Award> ListOfAwards = new List<Award>();
        public static string filename;

        public AwardDAL()
        {
            if (ListOfAwards.ToArray().Length == 0)
            {
                try
                {
                    filename = ConfigurationManager.AppSettings["AwardFilePath"];
                }
                catch (DirectoryNotFoundException e)
                {
                    Logger.Logger.CreateLog(e);
                    throw new ConfigurationFileException("Problem whith the file path", e);
                }

                if (!(File.Exists(filename)))
                {
                    File.Create(filename);
                }
                else
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(filename);
                    if (file != null)
                    {
                        string line;
                        string[] temp = new string[2];
                        while ((line = file.ReadLine()) != null)
                        {
                            temp = line.Split('{');
                            ListOfAwards.Add(new Award(temp[1], Guid.Parse(temp[0])));
                        }
                    }

                    file.Close();
                }
            }
        }


        public bool Create(Award award)
        {
            try
            {
            ListOfAwards.Add(award);
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
            var temp = ListOfAwards.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                return false;
            }
            ListOfAwards.Remove(temp);
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
            return ListOfAwards.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Award> GetAll()
        {
            foreach (var item in ListOfAwards)
            {
                yield return item;
            }
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

        public bool Change(Guid id, string Title)
        {
            throw new NotImplementedException();
        }
    }
}
