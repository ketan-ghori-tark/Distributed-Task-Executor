using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskExecutor.Models;
using TaskExecutor.NewFolder;

namespace TaskExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private NodeRepository _nodeRepository;

        public NodesController()
        {
            _nodeRepository = new NodeRepository();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterNode([FromBody] NodeRegistrationRequest node)
        {
            if (node == null || String.IsNullOrEmpty(node.Address) || String.IsNullOrEmpty(node.Name))
            {
                return BadRequest("Node has insufficent Information to Register. " + node?.ToString());
            }
            _nodeRepository.AddNode(new Node(node.Name, node.Address));
            return Ok();
        }

        [HttpDelete]
        [Route("unregister/{name}")]
        public IActionResult UnRegisterNode(string name)
        {
            Node removedNode = _nodeRepository.RemoveNode(name);
            if (removedNode != null)
            {
            }
            return Ok();
        }
    }
}
