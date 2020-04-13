using SystemBibloteka.Data;
using System.Collections.Generic;

namespace SystemBibloteka.Models
{
    public class Library : Ibasicentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }


        public int SchoolId { get; set; }

        public virtual School School { get; set; }


        public virtual ICollection<Book> Books { get; set; }

        public Library()
        {
            Books = new HashSet<Book>();
        }
    }
}
