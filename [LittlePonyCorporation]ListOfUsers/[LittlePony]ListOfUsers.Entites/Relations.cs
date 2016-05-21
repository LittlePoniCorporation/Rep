using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Entites
{
    public class Relations
    {
        public Guid IdUser { get; set; }
        public Guid IdAward { get; set; }

        public Relations(Guid idUs, Guid idAw)
        {
            IdUser = idUs;
            IdAward = idAw;
        }
    }
}
