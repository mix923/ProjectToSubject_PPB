namespace SystemBibloteka.Controllers.Request
{
    public class BookRequest
    {
        /// <summary>
        /// Ksiazka Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ksiazka nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nazwa Autora ksiazki.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Data powstania ksiazki.
        /// </summary>
        public string Date { get; set; }


        /// <summary>
        /// Liczba stron ksiazki.
        /// </summary>
        public int Side { get; set; }


        /// <summary>
        /// Bibloteka Id.
        /// </summary>
        public int LibraryId { get; set; }
    }
}
