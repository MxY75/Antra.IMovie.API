namespace Antra.IMovie.Core.Model
{
    public class MovieGenreModel
    {

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public MovieResponseModel Movie { get; set; }
        public GenreModel Genre { get; set; }
    }
}