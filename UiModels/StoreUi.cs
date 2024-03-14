using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiModels
{
    public class StoreUi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookUi> Books { get; set; }
    }
}
