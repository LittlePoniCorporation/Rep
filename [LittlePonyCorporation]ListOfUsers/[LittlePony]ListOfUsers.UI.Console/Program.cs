using _LittlePony_BLL;
using _LittlePony_Entites;
using _LittlePony_Interfaces.Bll;
using _LittlePony_Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_ListOfUsers.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IListOfUsersBLL logic = null;
            IAwardBLL awards = null;
            IRelationBLL relation = null;

            try
            {
                logic = new UsersBLL();
                awards = new AwardBLL();
                relation = new RelationsBLL();
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.Logger.CreateLog(ex);
                System.Console.WriteLine("Программа не работает.");
                System.Console.ReadLine();
                return;
            }
            catch (FileNotFoundException e)
            {
                Logger.Logger.CreateLog(e);
                System.Console.WriteLine("Программа не работает.");
                System.Console.ReadLine();
                return;
            }
            int someCase = 0;
            do
            {
                System.Console.WriteLine("Выберите действие:\n1 - Посмотреть список всех пользователей\n2 - Добавить пользователя\n3 - Удалить пользователя\n4 - Посмотреть награды у пользователя\n5 - Добавить награду пользователю\n6 - Удалить награду\n7 - Добавить награду\n0 - Выход\n");
                int.TryParse(System.Console.ReadLine(), out someCase);
                try
                {
                    switch (someCase)
                    {
                        case 1:
                            {
                                if (logic.GetAll().ToArray().Length == 0)
                                {
                                    System.Console.WriteLine("Еще не добавлен ни один пользователь");
                                }
                                else
                                {
                                    int temp = 0;
                                    foreach (var item in logic.GetAllSortBySurname())
                                    {
                                        System.Console.WriteLine("{0} - {1} {2} {3} возраст:{4}", ++temp, item.Surname, item.Name, item.Second_Name, item.Age());
                                    }
                                }
                            }
                            break;
                        case 2:
                            {
                                System.Console.WriteLine("Фамилия:");
                                string surname = System.Console.ReadLine();
                                System.Console.WriteLine("Имя:");
                                string name = System.Console.ReadLine();
                                System.Console.WriteLine("Отчество:");
                                string secondname = System.Console.ReadLine();
                                System.Console.WriteLine("Дата рождения (d.m.y):");
                                try
                                {
                                    DateTime bday = DateTime.Parse(System.Console.ReadLine());
                                    if (logic.Create(new User(surname, name, secondname, bday)))
                                    {
                                        System.Console.WriteLine("Пользователь добавлен");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Пользователь не добавлен");
                                    }
                                }
                                catch (Exception e)
                                {
                                    System.Console.WriteLine("Введены некорректные данные");
                                    Logger.Logger.CreateLog(e);
                                }
                            }
                            break;
                        case 3:
                            {
                                if (logic.GetAll().ToArray().Length == 0)
                                {
                                    System.Console.WriteLine("Еще не добавлен ни один пользователь");
                                }
                                else
                                {
                                    System.Console.WriteLine("Выберите номер пользователя, которого хотите удалить:");
                                    int temp = 0;
                                    List<Guid> arr = new List<Guid>();
                                    foreach (var item in logic.GetAllSortBySurname())
                                    {
                                        System.Console.WriteLine("{0} - {1} {2} {3} возраст:{4}", ++temp, item.Surname, item.Name, item.Second_Name, item.Age());
                                        arr.Add(item.Id);
                                    }
                                    int t = 0;
                                    int.TryParse(System.Console.ReadLine(), out t);
                                    logic.Delete(arr[t - 1]);
                                }
                            }
                            break;
                        case 4:
                            {
                                if (relation.GetAll().ToArray().Length == 0)
                                {
                                    System.Console.WriteLine("Еще не добавлена ни одна награда ни одному пользователю");
                                }
                                else
                                {
                                    System.Console.WriteLine("Выберите номер пользователя, чьи награды вы хотите посмотреть:");
                                    int temp = 0;
                                    List<Guid> arr = new List<Guid>();
                                    foreach (var item in logic.GetAllSortBySurname())
                                    {
                                        System.Console.WriteLine("{0} - {1} {2} {3} возраст:{4}", ++temp, item.Surname, item.Name, item.Second_Name, item.Age());
                                        arr.Add(item.Id);
                                    }
                                    int t = 0;
                                    int.TryParse(System.Console.ReadLine(), out t);
                                    foreach (var item in relation.GetAllAwards(arr[t - 1]))
                                    {
                                        System.Console.WriteLine(item.Title);
                                    }
                                }
                            }
                            break;
                        case 5:
                            {
                                if (awards.GetAll().ToArray().Length == 0 || logic.GetAll().ToArray().Length == 0)
                                {
                                    System.Console.WriteLine("Еще не добавлено ни одной награды или не добавлен ни один пользователь");
                                }
                                else
                                {
                                    System.Console.WriteLine("Выберите номер награды, которую вы хотите добавить:");
                                    int temp1 = 0;
                                    List<Guid> arr1 = new List<Guid>();
                                    foreach (var item in awards.GetAllSortByTitle())
                                    {
                                        System.Console.WriteLine("{0} - {1}", ++temp1, item.Title);
                                        arr1.Add(item.Id);
                                    }
                                    int r = 0;
                                    int.TryParse(System.Console.ReadLine(), out r);

                                    System.Console.WriteLine("Выберите номер пользователя, кому вы хотите добавить награду:");
                                    int temp = 0;
                                    List<Guid> arr = new List<Guid>();
                                    foreach (var item in logic.GetAllSortBySurname())
                                    {
                                        System.Console.WriteLine("{0} - {1} {2} {3} возраст:{4}", ++temp, item.Surname, item.Name, item.Second_Name, item.Age());
                                        arr.Add(item.Id);
                                    }
                                    int t = 0;
                                    int.TryParse(System.Console.ReadLine(), out t);

                                    relation.Add(new Relations(arr[t - 1], arr1[r - 1]));
                                }
                            }
                            break;
                        case 6:
                            {
                                if (awards.GetAll().ToArray().Length == 0)
                                {
                                    System.Console.WriteLine("Еще не добавлено ни одной награды");
                                }
                                else
                                {
                                    System.Console.WriteLine("Выберите номер награды, которую хотите удалить:");
                                    int temp = 0;
                                    List<Guid> arr = new List<Guid>();
                                    foreach (var item in awards.GetAllSortByTitle())
                                    {
                                        System.Console.WriteLine("{0} - {1}", ++temp, item.Title);
                                        arr.Add(item.Id);
                                    }
                                    int t = 0;
                                    int.TryParse(System.Console.ReadLine(), out t);
                                    awards.Delete(arr[t - 1]);
                                }
                            }
                            break;
                        case 7:
                            {
                                System.Console.WriteLine("Введите имя награды, которую хотите добавить:");
                                try
                                {
                                    awards.Create(new Award(System.Console.ReadLine()));
                                }
                                catch (Exception e)
                                {
                                    System.Console.WriteLine("Введены некорректные данные");
                                    Logger.Logger.CreateLog(e);
                                }
                            }
                            break;
                    }
                }
                catch (Exception exs)
                {
                    Logger.Logger.CreateLog(exs);
                }

                System.Console.ReadLine();
                System.Console.Clear();
            } while (someCase != 0);

        ////    logic.Save();
        ////    awards.Save();
        ////    relation.Save();
        }
    }
}
