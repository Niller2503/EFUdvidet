using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUdvidet.Models
{
    public class Store
    {
        public Store()
        {
            Books=new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book>Books { get; set; }
    }
}
