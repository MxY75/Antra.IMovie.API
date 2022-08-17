using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Antra.IMovie.Core.Entity
{
    public class Cast
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "Varchar")]
        public string Name { get; set; }

        public string Gender { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "Varchar")]
        public string TmdbUrl { get; set; }
        [MaxLength(130)]
        [Column(TypeName = "Varchar")]
        public string ProfilePath { get; set; }

    }
}