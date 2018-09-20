using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Garbage.ViewModels
{
    public class GarbageViewModel
    {
        public GarbageViewModel() { }
        // public int Garbage_ID { get; set; }
        public int SubId { get; set; }
        public string SubCategoryName { get; set; }
        public DateTime CreatedTime { get; set; }
        public int RecyclingQty { get; set; }
    }
    public class HistogramChartViewModel
    {
        public int Qty { get; set; }
        public string CategoryName { get; set; }
        // 厨余垃圾
        // public int KitchenQty { get; set; }
        // // 有害垃圾
        // public int HarmfulQty { get; set; }
        // // 其他垃圾
        // public int OtherQty { get; set; }
    }
    public class LineChartViewModel
    {
        public string CreatedTime { get; set; }
        public int Qty { get; set; }
    }
}