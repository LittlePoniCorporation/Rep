using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Awards.DAL
{
    public class ConfigurationFileException: Exception
    {
        public ConfigurationFileException()
        {

        }

        public ConfigurationFileException(string massage):base(massage)
        {

        }

        public ConfigurationFileException(string massage, Exception innerExeption):base(massage, innerExeption)
        {
             
        }
    }
}
