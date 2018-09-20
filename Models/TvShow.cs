using System.ComponentModel.DataAnnotations;

namespace Tv.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int TvNetworkId { get; set; }
        public TvNetwork TvNetwork { get; set; }
    }
}