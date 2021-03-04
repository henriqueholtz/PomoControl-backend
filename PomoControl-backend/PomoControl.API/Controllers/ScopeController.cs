using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomoControl.API.ViewModels.Scope;
using PomoControl.Core;
using PomoControl.Core.Exceptions;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScopeController : PomoController
    {
        private readonly IScopeService _scopeService;
        private readonly IMapper _mapper;

        public ScopeController(IScopeService scopeService, IMapper mapper)
        {
            _scopeService = scopeService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/Create")]
        //[Authorize]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Create([FromBody] CreateScopeViewModel viewModel)
        {
            try
            {
                var scopeDTO = _mapper.Map<ScopeDTO>(viewModel);
                var scopeCreated = await _scopeService.Create(scopeDTO);
                return Ok(new ResponseDTO<dynamic>()
                {
                    Data = scopeCreated,
                    Message = "Success in create Scope.",
                    Success = true,
                    SourceResponseTime = new List<string>() { "xx", "yy" }
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
