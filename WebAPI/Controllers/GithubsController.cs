using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.DeleteGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos;
using Application.Features.Githubs.Models;
using Application.Features.Githubs.Queries.GetByIdGithub;
using Application.Features.Githubs.Queries.GetListGithub;
using Application.Features.Githubs.Queries.GetListGithubByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateGithubCommand createGithubCommand)
        {
            CreatedGithubDto createdGithubDto = await Mediator.Send(createGithubCommand);
            return Created("", createdGithubDto);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubCommand deleteGithubCommand)
        {
            DeletedGithubDto deletedGithubDto = await Mediator.Send(deleteGithubCommand);
            return Ok(deletedGithubDto);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGithubCommand updateGithubCommand)
        {
            UpdatedGithubDto updatedGithubDto = await Mediator.Send(updateGithubCommand);
            return Ok(updatedGithubDto);
        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetByIdGithubQuery getByIdGithubQuery)
        {
            GithubGetByIdDto githubGetByIdDto = await Mediator.Send(getByIdGithubQuery);

            return Ok(githubGetByIdDto);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubQuery getListGithubQuery = new() { PageRequest = pageRequest }; 
            GithubListModel result = await Mediator.Send(getListGithubQuery);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListGithubByDynamicQuery getListGithubByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic }; 
            GithubListModel result = await Mediator.Send(getListGithubByDynamicQuery);
            return Ok(result);
        }
    }
}
