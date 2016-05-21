using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _LittlePony_Entites;
using _LittelPony_Interfaces.DAL;

namespace _LittlePony_DAL
{
    public class RelationsDAL : IRelationsDAL
    {
        public static List<Relations> ListOfRelations = new List<Relations>();
        public static string filename;

        public RelationsDAL()
        {
            if (ListOfRelations.ToArray().Length == 0)
            {
                try
                {
                    filename = ConfigurationManager.AppSettings["RelationFilePath"];
                }
                catch (DirectoryNotFoundException e)
                {
                    throw new Exception("Problem whith the file path", e);
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
                            ListOfRelations.Add(new Relations(Guid.Parse(temp[0]), Guid.Parse(temp[1])));
                        }
                    }

                    file.Close();
                }
            }
        }

        public IEnumerable<Relations> GetAll()
        {
            foreach (var item in ListOfRelations)
            {
                yield return item;
            }
        }

        public bool Add(Relations relation)
        {
            try
            {
                ListOfRelations.Add(relation);
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
                var temp = ListOfRelations.FirstOrDefault(x => x.IdAward == id);
                if (temp == null)
                {
                    return false;
                }
                ListOfRelations.Remove(temp);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Save()
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < ListOfRelations.Count(); i++)
            {
                sw.Write(ListOfRelations[i].IdUser.ToString() + "{" + ListOfRelations[i].IdAward + "\r\n");
            }
            sw.Close();
            return true;
        }
    }
}

