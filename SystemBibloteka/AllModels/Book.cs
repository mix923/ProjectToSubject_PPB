using SystemBibloteka.Data;

namespace SystemBibloteka.Models
{
    public class Book : Ibasicentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Date { get; set; }

        public int Side { get; set; }

        public int LibraryId { get; set; }

        public virtual Library Library { get; set; }
    }
}
