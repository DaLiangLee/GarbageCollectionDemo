using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garbage.Models
{
    [Table("Garbage")]
    public class GarbageModel
    {
        public GarbageModel() {}
        [Key]
        public int GCId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int RecyclingQty { get; set; }
        public int SubId { get; set; }
        [ForeignKey("SubId")]
        public virtual GCSubCategory GCSubCategories { get; set;}
    }
}