namespace Antra.IMovie.Core.Model
{
    public class FavoriteModel
    {

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public MovieModel Movie { get; set; }
        public UserModel User { get; set; }
    }
}