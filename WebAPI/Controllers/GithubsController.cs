using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.DeleteGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos;
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
    }
}
