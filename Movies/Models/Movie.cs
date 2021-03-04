using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public enum Genres { action, adventure, animation, comedy, crime, drama, fantasy, family, horror, scifi, thriller };
    public enum Certification {Universal, Twelve, Fifteen, Eighteen};

    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public String Title { get; set; }
        public Genres Genre { get; set; }
        public Certification Cert { get; set; }
        public DateTime ReleaseDate { get; set; }

        [Range(1, 10, ErrorMessage ="Rating must be 1 to 10")]
        public int AvgRating { get; set; }
    }
}
