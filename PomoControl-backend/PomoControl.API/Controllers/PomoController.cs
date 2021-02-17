using Microsoft.AspNetCore.Mvc;
using PomoControl.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.Controllers
{
    public class PomoController : ControllerBase
    {
        private const string HeaderSourceInfo = "PomoControl - API";
        public PomoController()
        {

        }

        public OkObjectResult Ok<T>(ResponseDTO<T> dto)
        {
            Response.Headers.Add(HeaderSourceInfo, dto.SourceResponseAsString);
            return base.Ok(dto.Data);
        }
        public CreatedResult Created<T>(string url, ResponseDTO<T> dto)
        {
            Response.Headers.Add(HeaderSourceInfo, dto.SourceResponseAsString);
            return base.Created(url, dto.Data);
        }
        public CreatedResult Created(string url, ResponseDTO dto)
        {
            Response.Headers.Add(HeaderSourceInfo, dto.SourceResponseAsString);
            return base.Created(url, dto);
        }

        public NoContentResult NoContent(ResponseDTO dto)
        {
            Response.Headers.Add(HeaderSourceInfo, dto.SourceResponseAsString);
            return base.NoContent();
        }
    }
}
