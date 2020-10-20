using CookBook.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Core.Entities
{
    public class File : Entity
    {
        public string Name { get; set; }

        public byte[] Content { get; set; }
    }
}
