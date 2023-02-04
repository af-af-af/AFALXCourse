using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientShowcase.Models
{
    public class BookShelf
    {
        public int Id { get; set; }
        public List<Book> Books { get; set;}
    }
}
