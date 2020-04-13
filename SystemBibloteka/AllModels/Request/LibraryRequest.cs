namespace SystemBibloteka.Controllers.Request
{
    public class LibraryRequest
    {
        /// <summary>
        /// Bibloteka Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bibloteka nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Miejscowość bibloteki.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Szkoła nazwa Id.
        /// </summary>
        public int SchoolId { get; set; }
    }
}
