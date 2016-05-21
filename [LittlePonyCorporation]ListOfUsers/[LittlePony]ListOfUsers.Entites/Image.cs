using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Entites
{
    public class Image
    {
        private string contentType;
        private byte[] content;
        public Guid Id { get; set; }


        public Image(byte[] Cont, string ContType)
        {
            Id = new Guid();
            Content = Cont;
            ContentType = ContType;
        }

        public Image(Guid id, byte[] Cont, string ContType)
        {
            Id = id;
            Content = Cont;
            ContentType = ContType;
        }

        public string ContentType
        {
            get { return contentType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                contentType = value;
            }
        }

        public byte[] Content
        {
            get { return content; }
            set
            {
                if (value == default(byte[]))
                {
                    throw new Exception();
                }
                content = value;
            }
        }

    }
}
