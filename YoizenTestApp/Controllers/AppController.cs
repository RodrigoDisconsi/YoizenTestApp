using Microsoft.AspNetCore.Mvc;
using YoizenTestApp.Models;
using YoizenTestApp.Repo;

namespace YoizenTestApp.Controllers
{
    [ApiController]
    [Route("app")]
    public class AppController : Controller
    {
        private IRepo<Client> _repositoryClient;
        private IRepo<Policy> _repositoryPolicy;

        public AppController(IRepo<Client> repositoryClient, IRepo<Policy> repositoryPolicy)
        {
            _repositoryClient = repositoryClient;
            _repositoryPolicy = repositoryPolicy;
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(Guid id)
        {
            var client = _repositoryClient.Get(id);
            if(client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpGet("ClientByName/{name}")]
        public IActionResult GetClientByName(string name)
        {
            var client = ((InMemClientRepo)_repositoryClient).GetByName(name);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpGet("PoliciesByClientName/{name}")]
        public IActionResult GetPoliciesByClientName(string name)
        {
            var client = ((InMemClientRepo)_repositoryClient).GetByName(name);
            if (client == null)
                return NotFound("Not found client");
            var policies = ((InMemPolicyRepo)_repositoryPolicy).GetByClient(client.Id);


            return Ok(policies);
        }
    }
}
