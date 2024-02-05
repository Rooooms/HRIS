using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }  
    }
}
