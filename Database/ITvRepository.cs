using System.Collections.Generic;
using System.Threading.Tasks;
using Tv.Models;
using Garbage.Models;
using Garbage.ViewModels;
using System;

namespace Tv.Database
{
    public interface ITvRepostitory
    {
        Task<List<TvNetwork>> GetTvNetworksAsync();
        Task<TvNetwork> GetTvNetworkByIdAsync(int id, bool includeRelated = true);
        void AddTvNetwork(TvNetwork model);
        void RemoveTvNetwork(TvNetwork model);
        Task<List<GarbageViewModel>> GetAllGarbagesAsync();
        Task<List<GCCategory>> GetGCCategoriesAsync();
        // Task<List<GCSubCategory>> GetGCSubCategoriesAsync();
        Task<List<GCSubCategory>> GetGCSubCategoriesByIdAsync(int cId);
        void AddGarbage(GarbageModel model);
        // void RemoveGCSubCategoryu(GCSubCategory model);
        // Chart
        Task<List<HistogramChartViewModel>> GetHistogrmChartCountAsync(string createdTime);
        Task<List<LineChartViewModel>> GetLineChartCountAsync(int categoryId);
    }
}