using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using PomoControl.Service.ViewModels.Scope;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopeController : ControllerBase
    {
        private readonly IScopeService _scopeService;
        private readonly IMapper _mapper;

        public ScopeController(IScopeService scopeService, IMapper mapper)
        {
            _scopeService = scopeService;
            _mapper = mapper;
        }

        [Route("/Create")]
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody] CreateScopeViewModel viewModel)
        {
            var scopeDTO = _mapper.Map<ScopeDTO>(viewModel);
            var response = await _scopeService.Create(scopeDTO);
            return StatusCode(response.StatusCode, response.Data);
        }
    }
}
