using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Core.Models.Responses
{
    public class BookResponse
    {
        public Guid Id { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }
    }
}
