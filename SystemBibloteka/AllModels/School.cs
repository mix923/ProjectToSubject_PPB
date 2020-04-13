using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBibloteka.Data;

namespace SystemBibloteka.Models
{
    public class School : Ibasicentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public virtual ICollection<Library> Libraries { get; set; }

        public School()
        {
            Libraries = new HashSet<Library>();
        }
    }
}
