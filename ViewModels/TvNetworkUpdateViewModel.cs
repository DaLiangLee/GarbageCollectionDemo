using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tv.ViewModels
{
    public class TvNetworkUpdateViewModel
    {
        [Display(Name = "电视台名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0}的长度范围是{2}到{1}")]
        public string Name { get; set; }

        public List<TvShowViewModel> TvShows { get; set; }
    }
}