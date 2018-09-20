using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tv.Database;
using Tv.Models;
using Tv.ViewModels;

namespace Tv.Controllers
{
    public class TvController : Controller
    {
        private readonly ITvRepostitory repostiory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TvController(ITvRepostitory repostiory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repostiory = repostiory;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("api/tvnetworks")]
        public async Task<IEnumerable<TvNetworkViewModel>> GetTvNetworks()
        {
            var models = await repostiory.GetTvNetworksAsync();
            var vms = mapper.Map<List<TvNetwork>, List<TvNetworkViewModel>>(models);
            return vms;
        }

        [HttpGet("api/tvnetworks/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await repostiory.GetTvNetworkByIdAsync(id);
            var vm = mapper.Map<TvNetwork, TvNetworkViewModel>(model);
            return Ok(vm);
        }

        [HttpPost("api/tvnetworks")]
        public async Task<IActionResult> Post([FromBody]TvNetworkUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newTvNetwork = new TvNetwork();
                // newTvNetwork.Id = 2008;
                newTvNetwork.Name = vm.Name;
                // var model = mapper.Map<TvNetworkUpdateViewModel, TvNetwork>(vm);
                repostiory.AddTvNetwork(newTvNetwork);
                await unitOfWork.SaveAsync();
                var result = mapper.Map<TvNetwork, TvNetworkViewModel>(newTvNetwork);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, result = ex.Message});
            }
        }

        [HttpPut("api/tvnetworks/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TvNetworkUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbModel = await repostiory.GetTvNetworkByIdAsync(id);
            if (dbModel == null)
            {
                return NotFound();
            }
            var model = mapper.Map<TvNetworkUpdateViewModel, TvNetwork>(vm, dbModel);
            await unitOfWork.SaveAsync();
            var result = mapper.Map<TvNetwork, TvNetworkViewModel>(model);
            return Ok(result);
        }

        [HttpDelete("api/tvnetworks/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await repostiory.GetTvNetworkByIdAsync(id, includeRelated: false);
            if (model == null)
            {
                return NotFound();
            }
            repostiory.RemoveTvNetwork(model);
            await unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}