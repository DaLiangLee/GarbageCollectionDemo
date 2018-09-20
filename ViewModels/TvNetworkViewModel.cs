using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tv.ViewModels
{
    public class TvNetworkViewModel
    {
        public TvNetworkViewModel()
        {
            TvShows = new Collection<TvShowViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TvShowViewModel> TvShows { get; set; }
    }
}