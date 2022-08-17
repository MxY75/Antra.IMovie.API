using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.IMovie.Core.Entity
{
    public class MovieCast
    {


        [Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]

        public int CastId { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(450)]
        public string Character { get; set; }

        public virtual Movie Movie { get; set; }  
        public virtual Cast Cast { get; set; }  
    }
}