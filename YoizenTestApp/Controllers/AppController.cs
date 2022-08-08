using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YoizenTestApp.Dto;
using YoizenTestApp.Models;
using YoizenTestApp.Repo;

namespace YoizenTestApp.Controllers
{
    [ApiController]
    [Route("app")]
    [Authorize]
    public class AppController : Controller
    {
        private IRepo<Client> _repositoryClient;
        private IRepo<Policy> _repositoryPolicy;

        public AppController(IRepo<Client> repositoryClient, IRepo<Policy> repositoryPolicy)
        {
            _repositoryClient = repositoryClient;
            _repositoryPolicy = repositoryPolicy;
        }

        [HttpGet("{id}"), Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = _repositoryClient.Get(id);
            if(client == null)
                return NotFound();
            var clientDto = (ClientDto)client;
            return Ok(clientDto);
        }

        [HttpGet("ClientByName/{name}"), Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetClientByName(string name)
        {
            var client = ((InMemClientRepo)_repositoryClient).GetByName(name);
            if (client == null)
                return NotFound();
            var clientDto = (ClientDto)client;
            return Ok(clientDto);
        }

        [HttpGet("PoliciesByClientName/{name}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> GetPoliciesByClientName(string name)
        {
            var client = ((InMemClientRepo)_repositoryClient).GetByName(name);
            if (client == null)
                return NotFound("Not found client");
            var policies = ((InMemPolicyRepo)_repositoryPolicy).GetByClient(client.Id).Select(policies => (PolicyDto)policies);
            if (policies == null)
                return NotFound("Not found policies for that client");

            return Ok(policies);
        }
    }
}
