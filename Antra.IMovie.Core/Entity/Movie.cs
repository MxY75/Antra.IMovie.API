using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  
namespace Antra.IMovie.Core.Entity
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "Varchar")]
        public string Title { get; set; }


        [MaxLength(2048)]
        [Column(TypeName = "Varchar")]
        public string Overview { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "Varchar")]
        public string Tagline { get; set; }

        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }


        [MaxLength(2048)]
        [Column(TypeName = "Varchar")]
        public string PosterUrl { get; set; }

        [MaxLength(2048)]
        [Column(TypeName = "Varchar")]
        public string BackdropUrl { get; set; }
        [MaxLength(2048)]
        [Column(TypeName = "Varchar")]
        public string ImdbUrl { get; set; }
        
        
        [MaxLength(2048)]
        [Column(TypeName = "Varchar")]
        public string TmdbUrl { get; set; }

        [MaxLength(64)]
        [Column(TypeName = "Varchar")]
        public string OriginalLanguage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }

        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [MaxLength(48)]
        [Column(TypeName = "Varchar")]
        public string? UpdateBy { get; set; }

        [MaxLength(48)]
        [Column(TypeName = "Varchar")]

        public string? CreatedBy { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}