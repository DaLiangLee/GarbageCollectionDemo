using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garbage.Models
{
    [Table("SubCategory")]
    public class GCSubCategory
    {
        public GCSubCategory() {}
        [Key]
        public int SubId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual GCCategory GCCategories { get; set; }
    }
}