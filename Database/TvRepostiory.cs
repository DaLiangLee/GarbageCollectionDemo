using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tv.Models;
using Garbage.Models;
using System.Linq;
using Garbage.ViewModels;
using System;

namespace Tv.Database
{
    public class TvRepository : ITvRepostitory
    {
        private readonly TvContext context;

        public TvRepository(TvContext context)
        {
            this.context = context;
        }

        public async Task<List<TvNetwork>> GetTvNetworksAsync()
        {
            return await context.TvNetworks.Include(x => x.TvShows).ToListAsync();
        }

        public async Task<TvNetwork> GetTvNetworkByIdAsync(int id, bool includeRelated = true)
        {
            if (includeRelated)
            {
                return await context.TvNetworks.Include(x => x.TvShows).SingleOrDefaultAsync(x => x.Id == id);
            }
            return await context.TvNetworks.FindAsync(id);
        }

        public void AddTvNetwork(TvNetwork model)
        {
            context.TvNetworks.Add(model);
        }

        public void RemoveTvNetwork(TvNetwork model)
        {
            context.TvNetworks.Remove(model);
        }
        // Garbage collection
        public async Task<List<GarbageViewModel>> GetAllGarbagesAsync()
        {
            var garbageQuery = await  context.Garbages.Include(sub => sub.GCSubCategories).ToListAsync();
            List<GarbageViewModel> garbageList = new List<GarbageViewModel>();
            if(garbageQuery.Any()) {
                foreach (var item in garbageQuery)
                {
                    garbageList.Add(new GarbageViewModel{
                        SubId = item.SubId,
                        SubCategoryName = item.GCSubCategories.SubCategoryName,
                        CreatedTime = item.CreatedTime,
                        RecyclingQty = item.RecyclingQty
                    });
                }
            }
            return garbageList;
        }
        public async Task<List<GCCategory>> GetGCCategoriesAsync()
        {
            return await context.GCCategories.ToListAsync();
        }
        // public async Task<List<GCSubCategory>> GetGCSubCategoriesAsync()
        // {
        //     return await context.GCSubCategories.ToListAsync();
        // }
        public async Task<List<GCSubCategory>> GetGCSubCategoriesByIdAsync(int cId)
        {
            return await context.GCSubCategories.Where(gc => gc.CategoryId == cId).ToListAsync();
        }
        public void AddGarbage(GarbageModel model)
        {
            context.Garbages.Add(model);
        }
        // Chart
        public async Task<List<HistogramChartViewModel>> GetHistogrmChartCountAsync(string createdTime)
        {
            List<HistogramChartViewModel> histogramCharts = new List<HistogramChartViewModel>();

            var query = from g in context.Garbages
                        join sub in context.GCSubCategories on g.SubId equals sub.SubId
                        join cate in context.GCCategories on sub.CategoryId equals cate.CategoryId
                        where g.CreatedTime.ToString("yyyy-MM-dd") == createdTime
                        group new {g.GCSubCategories.GCCategories, g} by new {
                            g.GCSubCategories.GCCategories.CategoryId,
                            g.GCSubCategories.GCCategories.CategoryName
                        } into g
                        select new HistogramChartViewModel{
                            Qty = g.Sum(p => p.g.RecyclingQty),
                            CategoryName = g.Key.CategoryName
                        };
            if(query.Any()) {
                foreach (var item in query)
                {
                    var histogram = new HistogramChartViewModel();
                    histogram.Qty = item.Qty;
                    histogram.CategoryName = item.CategoryName;
                    histogramCharts.Add(histogram);
                }
            }
            return histogramCharts;
        }
        public async Task<List<LineChartViewModel>> GetLineChartCountAsync(int categoryId)
        {
            
            List<LineChartViewModel> lineCharts = new List<LineChartViewModel>();
            var query = from g in context.Garbages
                        join sub in context.GCSubCategories on g.SubId equals sub.SubId
                        join cate in context.GCCategories on sub.CategoryId equals cate.CategoryId
                        where cate.CategoryId == categoryId
                        group new {g.GCSubCategories.GCCategories, g} by new {
                            g.GCSubCategories.GCCategories.CategoryId,
                            g.CreatedTime
                        } into g
                        select new LineChartViewModel{
                            Qty = g.Sum(p => p.g.RecyclingQty),
                            CreatedTime = g.Key.CreatedTime.ToShortDateString()
                        };
            if(query.Any()) {
                foreach (var item in query)
                {
                    var lineChart = new LineChartViewModel();
                    lineChart.Qty = item.Qty;
                    lineChart.CreatedTime = item.CreatedTime;
                    lineCharts.Add(lineChart);
                }
            }
            return lineCharts;
        }

    }
}