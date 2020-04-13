namespace SystemBibloteka.Controllers.Response
{
    public class LibraryResponse
    {
        /// <summary>
        /// Bibloteka Id.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Miejscowość w której jest bibloteka.
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// Bibloteka nazwa.
        /// </summary>
        public string Name { get; set; }

        public virtual SchoolRespone SchoolResponse { get; set; }
    }
}
