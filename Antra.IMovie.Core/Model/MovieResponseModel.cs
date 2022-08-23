namespace Antra.IMovie.Core.Model
{
    public class MovieResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline
        {
            get; set;
        }
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual IEnumerable<MovieGenreModel> MovieGenre { get; set; }

    }
}