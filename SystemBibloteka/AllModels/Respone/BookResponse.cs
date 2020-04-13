namespace SystemBibloteka.Controllers.Response
{
    public class BookResponse
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
        /// Bibloteki.
        /// </summary>
        public virtual LibraryResponse LibararyResponse { get; set; }
    }
}
