using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_ListOfUsers.Entites.Awards
{
    public class Award
    {
        private string title;
        public Guid Id { get; set; }

        public Award(string title, Guid id)
        {
            Title = title;
            Id = id;
        }

        public Award(string title)
        {
            Title = title;
            Id = Guid.NewGuid();
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                title = value;
            }
        }
    }
}
