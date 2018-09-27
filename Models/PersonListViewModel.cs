using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationDemo.Models
{
    public class PersonListViewModel
    {
        public IEnumerable<Person> People { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
