using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Tv.Models
{
    public class TvNetwork
    {
        public TvNetwork()
        {
            TvShows = new Collection<TvShow>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<TvShow> TvShows { get; set; }
    }
}