using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tv.Database;
using Garbage.Models;
using Garbage.ViewModels;

namespace Gc.Controllers
{
    public class GcController : Controller
    {
        private readonly ITvRepostitory repostiory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly TvContext _context;

        public GcController(ITvRepostitory repostiory, IUnitOfWork unitOfWork, IMapper mapper, TvContext context)
        {
            this.repostiory = repostiory;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._context = context;
        }

        [HttpGet("api/getAllGarbages")]
        public async Task<IEnumerable<GarbageViewModel>> GetAllGarbages()
        {
            var vms = await repostiory.GetAllGarbagesAsync();
            // var vms = mapper.Map<List<GarbageModel>, List<GarbageViewModel>>(models);
            return vms;
        }

        [HttpGet("api/getCategories")]
        public async Task<IEnumerable<GCCategoryViewModel>> GetGCCategories()
        {
            var models = await repostiory.GetGCCategoriesAsync();
            var vms = mapper.Map<List<GCCategory>, List<GCCategoryViewModel>>(models);
            return vms;
        }

        [HttpGet("api/getSuCategories/{cId}")]
        public async Task<IEnumerable<dynamic>> GetGCSubCategoriesById(int cId)
        {
            var models = await repostiory.GetGCSubCategoriesByIdAsync(cId);
            var vms = mapper.Map<List<GCSubCategory>, List<GCSubCategoryViewModel>>(models);
            var subList = new List<dynamic>();
            foreach (var item in vms)
            {
                var sub = new {
                    id = item.Sub_ID,
                    itemName = item.SubCategoryName
                };
                subList.Add(sub);
            }
            return subList;
        }

        [HttpPost("api/addNewGarbage")]
        public async Task<IActionResult> Post([FromBody]GarbageViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newGarbage = new GarbageModel();
                newGarbage.SubId = vm.SubId;
                newGarbage.CreatedTime = vm.CreatedTime;
                newGarbage.RecyclingQty = vm.RecyclingQty;
                repostiory.AddGarbage(newGarbage);
                await unitOfWork.SaveAsync();
                // var result = mapper.Map<GarbageModel, GarbageViewModel>(newGarbage);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, result = ex.Message});
            }
        }
        // Chart
        // histogram
        [HttpGet("api/getCountByDate/{createdTime}")]
        public async Task<List<HistogramChartViewModel>> GetCountByDate(string createdTime)
        {
            var vms = await repostiory.GetHistogrmChartCountAsync(createdTime);
            return vms;
        }
        [HttpGet("api/getLineChartByCategoryId/{categoryId}")]
        public async Task<List<LineChartViewModel>> GetLineChartCountByCategoryId(int categoryId)
        {
            var vms = await repostiory.GetLineChartCountAsync(categoryId);
            return vms;
        }
    }
}