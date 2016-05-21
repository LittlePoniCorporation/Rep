using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Entites
{
    public class User
    {
        private string surname, name, second_name;
        private DateTime bday;
        public Guid Id { get; set; }

        public User(string aSurname, string aName, string aSecondName, DateTime aBday)
        {
            Surname = aSurname;
            Name = aName;
            Second_Name = aSecondName;
            BDay = aBday;
            Id = Guid.NewGuid();
        }

        public User(string aSurname, string aName, string aSecondName, DateTime aBday, Guid id)
        {
            Surname = aSurname;
            Name = aName;
            Second_Name = aSecondName;
            BDay = aBday;
            Id = id;
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                surname = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new Exception(); }
                else
                { name = value; }
            }
        }

        public string Second_Name
        {
            get { return second_name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) & value != null)
                { throw new Exception();}
                else
                { second_name = value; }
            }
        }

        public DateTime BDay
        {
            get { return bday; }
            set
            {
                if (Agehelp(value) > 0 && Agehelp(value) < 140)
                { bday = value; }
                else { throw new Exception(); }
            }
        }

        public int Age()
        {
            return Agehelp(BDay);
        }

        protected int Agehelp(DateTime BDay)
        {
            int age = DateTime.Now.Year - BDay.Year;
            if (BDay.Month > DateTime.Now.Month)
            {
                if (BDay.Day > DateTime.Now.Day)
                {
                    age--;
                }
            }
            return age;
        }
    }
}